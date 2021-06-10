﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Ceny.Models;

namespace Ceny.Services
{
    public class PricesProvider

    {
        private HttpClient httpClient;
        private List<Produkt> _produkty;
        public PricesProvider(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        // TODO: https://refactoring.guru/pl/design-patterns/singleton/csharp/example#example-1

        public async Task<List<Produkt>> GetAll()
        {
            if (_produkty is null)
            {
                var lista = new List<Produkt>();

                for (var rok = 2006; rok <= 2019; rok++)
                {
                    var file = await httpClient.GetAsync($"/ceny/{rok}.csv");
                    var str = await file.Content.ReadAsStringAsync();
                    var lines = str.Split("\n");

                    for (var wiersz = 1; wiersz < lines.Length; wiersz++)
                    {
                        if (!String.IsNullOrEmpty(lines[wiersz]))
                            lista.Add(new(lines[wiersz]));

                    }

                }
                _produkty = lista.Where(e => e.Cena > 0.00).ToList();
                return _produkty;
            }
            return _produkty;
        }



    }
}
