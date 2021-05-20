using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceny.Models
{
    public class PriceChange
    {
        public PriceChange()
        {

        }

        public PriceChange(string id,string nazwa,double startPrice,double endPrice)
        {
            Id = id;
            Nazwa = nazwa;
            StartPrice = startPrice;
            EndPrice = endPrice;

        }
        public string Id { get; set; }
        public string Nazwa { get; set; }
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }

        public Double Change
        {
            get => 100 - (EndPrice / StartPrice) * 100;
        }
    }
}
