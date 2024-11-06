﻿using HMS.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace HMS.Components.Pages.razorComponents
{
    public class ListingsBase : ComponentBase
    {
        private int listingCount = 0;
        public IEnumerable<Listing>? Listings { get; set; }
		public List<Listing> Listings_DB = new List<Listing>();
		public Listing[] listHolder = Array.Empty<Listing>();
        protected override Task OnInitializedAsync()
        {
            LoadItems();
            return base.OnInitializedAsync();
        }

        private void LoadItems()
        {
			Listings = Listings_DB;
		}

		//Add items to Listings_DB
        public void AddItem()
        {
			Listings_DB.Add(new Listing
			{
				Title = "Test Listing " + listingCount.ToString(),
				Description = "Description " + listingCount.ToString(),
				BedCount = listingCount,
				BathCount = listingCount,
				Price = listingCount,
				Date = 110224,
				Picture = "image",
				ID = "89" + listingCount.ToString()
			});

			listingCount++;
			LoadItems();
			StateHasChanged();
		}

        private void RemoveItem()
        {















































        }
	}
}