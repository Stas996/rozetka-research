using System;

namespace RozetkaResearch.BLL.Services.Urls
{
    public static class RozetkaUrls
    {
        private const string SearchUrl = "https://rozetka.com.ua/search/?text={0}&redirected=1&view=list";

        public static string GetSearchUrl(string data)
        {
            var searchStr = string.Join("+", data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            return string.Format(SearchUrl, searchStr);
        }
    }
}
