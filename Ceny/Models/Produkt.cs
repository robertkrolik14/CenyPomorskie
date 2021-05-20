using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ceny.Extensions;
namespace Ceny.Models
{
    public class Produkt : IComparable<Produkt>,IEquatable<Produkt>
    {
        public string Id { get; init; }
        public DateTime Data { get; set; }

        public string Nazwa { get; set; }


        public double Cena { get; set; }


        public Produkt(string wiersz)
        {
            var arr = wiersz.Replace("\"",null).Split(';');
            //przetwarzanie daty
           

            //arr[2]-mieisąc
            //arr[5]-rok
            Data = new DateTime(Int32.Parse(arr[5]), arr[2].MonthToInt(), 1);

            //przetwaranie nazwy-arr[3]
            Nazwa = arr[3];
            //przetwarzanie ceny -arr[6]
            Cena = Double.Parse(arr[6]);
            //Losujemy ID
            Id = Guid.NewGuid().ToString();
        }

        public int CompareTo(Produkt other)
        => Cena.CompareTo(other.Cena);

        public override string ToString()
            => $"{Nazwa} {Cena } zł ({Data:MMMM yyyy})";

        public bool Equals(Produkt other)
        => other.Nazwa == Nazwa;
        public override int GetHashCode()
        => Nazwa.GetHashCode();
    }
}
