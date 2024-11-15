using HMS.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

#nullable enable
namespace HMS.Components.Pages.razorComponents
{
	public class ListingsBase : ComponentBase
	{
		private int listingCount { get; set; } = 0;
		public IEnumerable<Listing>? Listings { get; set; }
		public List<Listing> Listings_DB { get; set; } = new List<Listing>();



		[Parameter] public string value { get; set; } = "";




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

        public void RemoveItem(string getID)
        {
			int index = 0;
			int iter = 0;
			bool rm = false;

			foreach (Listing listing in Listings)
			{
				if (listing.ID == getID) { index = iter; rm = true; }
				iter++;
			}

			if(rm == true) { 
				Listings_DB.RemoveAt(index); 
				value = "";
				listingCount--;
			}

			LoadItems();
			StateHasChanged();

		}
	}
}