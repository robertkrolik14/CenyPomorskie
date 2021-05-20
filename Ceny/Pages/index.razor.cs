using Ceny.Models;
using Ceny.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceny.Pages
{
    partial class Index : ComponentBase
    {
        private List<Produkt> _produkty;
        private string productDetailsId = String.Empty;
        [Inject] PricesProvider pricesProvider { get; init; }
        [Inject] NavigationManager navigator { get; init; }



        protected override async Task OnInitializedAsync()
        {
            _produkty = await pricesProvider.GetAll();
        }

        private void NavigateToProductDetails(string id) => navigator.NavigateTo($"/ProductDetails/{id}");


        private PriceChange BiggestIncrease
        {
            get => /*_produkty.Where(e => e.Nazwa == _produkty.GroupBy(g => g.Nazwa)
.Select(e => new
{
    Nazwa = e.Key,
    Zmiana = 100 - (e.OrderByDescending(o => o.Data).First().Cena / e.OrderBy(o => o.Data).First().Cena) * 100
}).OrderByDescending(o => o.Zmiana).FirstOrDefault().Nazwa).FirstOrDefault();
                */

                _produkty.GroupBy(g => g.Nazwa).Select(s => new PriceChange(s.First().Id, s.Key, s.OrderByDescending(o => o.Data).First().Cena, s.OrderBy(o => o.Data).First().Cena)).OrderByDescending(o => o.Change).FirstOrDefault();
        }
    }

}