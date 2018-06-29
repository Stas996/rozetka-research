using System;

namespace RozetkaResearch.BLL.Models
{
    [Serializable]
    public class Offer
    {
        public string Name { get; set; }

        public string Vendor { get; set; }

        public bool Available { get; set; }
    }
}
