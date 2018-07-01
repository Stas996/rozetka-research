using System;

namespace RozetkaResearch.BLL.Models
{
    public class ResearchOffer
    {
        public string Name { get; set; }

        public string OfferUrl { get; set; }

        public string RozetkaUrl { get; set; }

        public decimal MyPrice { get; set; }

        public decimal ConcurPrice { get; set; }

        public string Html()
        {
            return
$@"<p>
Название товара: <strong>{Name}</strong>;<br/>
Ссылка товара в вашем магазине: <a href='{OfferUrl}' target='_blank'>{OfferUrl}</a>; <br/>
Ссылка на товар конкурента на Rozetka.ua: <a href='{RozetkaUrl}' target='_blank'>{RozetkaUrl}</a>; <br/>
Ваша цена: {MyPrice} грн; <br/>
Цена у конкурента: {ConcurPrice} грн; <br/>
Разница: {Math.Abs(ConcurPrice - MyPrice)} грн <br/>
</p>";
        }
    }
}
