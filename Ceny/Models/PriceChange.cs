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

        public PriceChange(string id, string nazwa, double startPrice, double endPrice)
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
        private double change;
        private bool changeCalculated = false;
        public Double Change
        {
            get 
            {
                if (changeCalculated == false)
                {
                    change = (EndPrice - StartPrice) / StartPrice * 100;
                    changeCalculated = true;
                }
                return change;
            }
            
            
        }
    }
}
