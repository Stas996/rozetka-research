using HtmlAgilityPack;
using Newtonsoft.Json;
using RozetkaResearch.BLL.Models;
using RozetkaResearch.BLL.Services.Selectors.XPath;
using RozetkaResearch.BLL.Services.Urls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RozetkaResearch.BLL.Services
{
    public class OfferService : IDisposable
    {
        private readonly HttpClient _webClient;

        public OfferService()
        {
            _webClient = new HttpClient();
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }

        public async Task ResearchAsync(IEnumerable<Offer> offers, Action<int, int, bool> iterationCallback, ICollection<ResearchOffer> researchOffers)
        {
            var i = 0;
            foreach (var offer in offers)
            {
                var offerSearchUrl = RozetkaUrls.GetSearchUrl(offer.Name);
                var response = await _webClient.GetAsync(offerSearchUrl);
                var offerPageHtml = await response.Content.ReadAsStringAsync();

                var doc = new HtmlDocument();
                doc.LoadHtml(offerPageHtml);
                var offerHrefNode = doc.DocumentNode.SelectSingleNode(RozetkaXPathSelectors.OfferHref);
                var offerHref = offerHrefNode != null 
                    ? offerHrefNode.GetAttributeValue("href", string.Empty)
                    : string.Empty;

                var price = GetPriceJsonFromHtml(offerPageHtml);
                if (price < offer.Price)
                {
                    researchOffers.Add(new ResearchOffer
                    {
                        OfferUrl = offer.Url,
                        RozetkaUrl = offerHref,
                        MyPrice = offer.Price,
                        ConcurPrice = price,
                        Name = offer.Name
                    });
                }
                iterationCallback(++i, researchOffers.Count, false);
            }
            iterationCallback(i, researchOffers.Count, true);
        }

        public IEnumerable<Offer> GetOffersFromXml(string xml)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(xml);

            var offers = doc.DocumentNode.SelectNodes(OfferXpathSelectors.Offers)
                .Select(x => GetOfferFromNode(x));

            return offers.ToList();
        }

        private Offer GetOfferFromNode(HtmlNode node)
        {
            return new Offer
            {
                Url = node.ChildNodes["url"].InnerText,
                Name = node.ChildNodes["name"].InnerText,
                Price = GetPrice(node.ChildNodes["price"].InnerText)
            };
        }

        private decimal GetPrice(string priceStr)
        {
            var price = string.Empty;
            foreach (var priceChar in priceStr)
            {
                if (char.IsNumber(priceChar) || priceChar == '.')
                {
                    price += priceChar;
                }
            }
            decimal result;
            return decimal.TryParse(price, out result) 
                ? result 
                : decimal.Parse(price.Replace('.', ','));
        }

        private decimal GetPriceJsonFromHtml(string html)
        {
            var startIndex = html.IndexOf("var pricerawjson");
            if (startIndex == -1)
            {
                return 0;
            }
            var beginJson = html.IndexOf('\'', startIndex);
            var endJson = html.IndexOf('\'', beginJson + 1);

            var json = WebUtility.UrlDecode(html.Substring(beginJson + 1, endJson - beginJson - 1));
            var obj = JsonConvert.DeserializeObject<RozetkaJsonOffer>(json);
            return GetPrice(obj.Price);
        }
    }
}
