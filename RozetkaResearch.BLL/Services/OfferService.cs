using HtmlAgilityPack;
using OpenQA.Selenium.PhantomJS;
using RozetkaResearch.BLL.Models;
using RozetkaResearch.BLL.Services.Selectors.XPath;
using RozetkaResearch.BLL.Services.Urls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RozetkaResearch.BLL.Services
{
    public class OfferService : IDisposable
    {
        private readonly PhantomJSDriver _webClient;

        public OfferService()
        {
            _webClient = new PhantomJSDriver();
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }

        public IEnumerable<Offer> Research(IEnumerable<Offer> offers)
        {
            var result = new List<Offer>();
            foreach (var offer in offers)
            {
                var offerName = RozetkaUrls.GetSearchUrl(offer.Name);
                _webClient.Url = offerName;
                _webClient.Navigate();

                var priceBlock = _webClient.FindElementByXPath(RozetkaXPathSelectors.PriceBlock);
                var offerHref = _webClient.FindElementByXPath(RozetkaXPathSelectors.OfferHref).GetAttribute("href");

                var price = GetPrice(priceBlock.Text);
                if (price < offer.Price)
                {
                    offer.RozetkaUrl = offerHref;
                    result.Add(offer);
                }
            }
            return result;
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
                OfferUrl = node.ChildNodes["url"].InnerText,
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
            return decimal.Parse(price);
        }
    }
}
