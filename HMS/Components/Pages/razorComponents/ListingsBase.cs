
//using HMS.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

#nullable enable
namespace HMS.Components.Pages.razorComponents
{
    public class ListingsBase : ComponentBase
    {
		public class Listing
		{
			public String Title {get; set;} 
            public String Description {get; set;} 
           	public int BedCount {get; set;} 
            public int BathCount {get; set;} 
            public int Price {get; set;} 
            public int Date {get; set;} 
            public String Picture {get; set;} 
		}
        private int listingCount { get; set; }
        public IEnumerable<Listing>? Listings { get; set; }
        public Listing[] Listings_Back = new Listing[5];
        protected override Task OnInitializedAsync()
        {
            LoadItems();
            return base.OnInitializedAsync();
        }

        private void LoadItems()
        {
            Listing l1 = new Listing
            {
                Title = "Test1 " + listingCount.ToString(),
                Description = "Description " + listingCount.ToString(),
                BedCount = listingCount,
                BathCount = listingCount,
                Price = listingCount,
                Date = 110224,
                Picture = "image"
            };

			Listing l2 = new Listing
			{
				Title = "Test2 " + listingCount.ToString(),
				Description = "Description " + listingCount.ToString(),
				BedCount = listingCount,
				BathCount = listingCount,
				Price = listingCount,
				Date = 110224,
				Picture = "image"
			};

			Listing l3 = new Listing
			{
				Title = "Test3 " + listingCount.ToString(),
				Description = "Description " + listingCount.ToString(),
				BedCount = listingCount,
				BathCount = listingCount,
				Price = listingCount,
				Date = 110224,
				Picture = "image"
			};

			Listing l4 = new Listing
			{
				Title = "Test4 " + listingCount.ToString(),
				Description = "Description " + listingCount.ToString(),
				BedCount = listingCount,
				BathCount = listingCount,
				Price = listingCount,
				Date = 110224,
				Picture = "image"
			};

			Listing l5 = new Listing
			{
				Title = "Test5 " + listingCount.ToString(),
				Description = "Description " + listingCount.ToString(),
				BedCount = listingCount,
				BathCount = listingCount,
				Price = listingCount,
				Date = 110224,
				Picture = "image"
			};

			Listing l6 = new Listing
			{
				Title = "Test6 " + listingCount.ToString(),
				Description = "Description " + listingCount.ToString(),
				BedCount = listingCount,
				BathCount = listingCount,
				Price = listingCount,
				Date = 110224,
				Picture = "image"
			};


			//Listings = new List<Listing>().Append(l1);
			Listings = new List<Listing> { l1, l2, l3, l4, l5, l6, };
		}

        public void AddItem()
        {

			Listings = new List<Listing>().Append(new Listing
            {
				Title = "Test " + listingCount.ToString(),
				Description = "Description " + listingCount.ToString(),
				BedCount = listingCount,
				BathCount = listingCount,
				Price = listingCount,
				Date = 110224,
				Picture = "image"
			});


			//Console.WriteLine("ok");
			//Listings = Listings.Append(new Listing
			//{
			//    Title = "Test " + listingCount.ToString(),
			//    Description = "Description " + listingCount.ToString(),
			//    BedCount = listingCount,
			//    BathCount = listingCount,
			//    Price = listingCount,
			//    Date = 110224,
			//    Picture = "image"
			//});
			//LoadItems();
		}

        private void RemoveItem()
        {

        }
    }
}

