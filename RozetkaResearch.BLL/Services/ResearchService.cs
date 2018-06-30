using OpenQA.Selenium.PhantomJS;
using RozetkaResearch.BLL.Services.Selectors.XPath;
using System;

namespace RozetkaResearch.BLL.Services
{
    public class ResearchService : IDisposable
    {
        private readonly PhantomJSDriver _webClient;

        public ResearchService()
        {
            _webClient = new PhantomJSDriver();
        }

        public void Dispose()
        {
            _webClient.Dispose();
        }

        public void Research(string[] urls)
        {
            //Parallel.ForEach(urls, url =>
            //{
            //    var response = httpService.GetAsync(url).Result;
            //    var html = response.Content.ReadAsStringAsync().Result;

            //    //var doc = new HtmlDocument();
            //    //doc.LoadHtml(response.Content.ReadAsStringAsync().Result);
            //});

            foreach (var url in urls)
            {
                _webClient.Url = url;
                _webClient.Navigate();

                var priceBlock = _webClient.FindElementByXPath(RozetkaXPathSelectors.PriceBlock);
                var price = GetPrice(priceBlock.Text);
            }
        }

        private int GetPrice(string priceStr)
        {
            var price = string.Empty;
            foreach(var priceChar in priceStr)
            {
                if (char.IsNumber(priceChar))
                {
                    price += priceChar;
                }
            }
            return int.Parse(price);
        }
    }
}
