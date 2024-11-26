using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

#nullable enable
namespace HMS.Components.Pages
{
    public class LP : ComponentBase
    {
        // Set up an instance of the firebase
        FirestoreDb db = FirestoreDb.Create("hotelmanagementsystem-3f342");
        public int i_resultCount;
        public bool b_filter1 = false;
        public bool b_filter2 = false;
        public bool b_filter3 = false;
        public bool b_filter4 = false;
        public bool b_filter5 = false;
        public bool stopping_filter = false;


        public class c_hotelInfo {
            public string s_id {get; set;} = string.Empty;
            public string s_name {get; set;} = string.Empty;
            public string s_hotelImgPath {get; set;} = string.Empty;
            public double d_rating {get; set;} = 0.0;
            public double d_price {get; set;} = 0.0;
            public int i_reviewCount {get; set;} = 0;
            public string s_slogan {get; set;} = string.Empty;
            public string s_description {get; set;} = string.Empty;
            public string s_startDate {get; set;} = string.Empty;
            public string s_endDate {get; set;} = string.Empty;
            public int i_maxGuests {get; set;} = 0;
        }

        public IEnumerable<c_hotelInfo> hotelInfo = Array.Empty<c_hotelInfo>();

        protected override async Task OnInitializedAsync() {
                await refreshList();
        }

        public async Task refreshList() {

            // List of colection references to be able to access different parts of the database
            CollectionReference cr_hotels =  db.Collection("Hotels");
            QuerySnapshot qs_hotelDocs = await cr_hotels.GetSnapshotAsync();

            var lst = new List<c_hotelInfo>();
                foreach (var doc in qs_hotelDocs.Documents)
                {
                    DocumentReference cr_hotelImg = cr_hotels.Document(doc.Id).Collection("images").Document("0");
                    DocumentSnapshot hotelImgs = await cr_hotelImg.GetSnapshotAsync();
                    lst.Add(new c_hotelInfo{s_id = doc.Id, 
                    s_name = doc.GetValue<string>("name"), 
                    s_hotelImgPath = hotelImgs.GetValue<string>("path"),
                    d_rating = doc.GetValue<double>("rating"),
                    d_price = doc.GetValue<double>("price"),
                    i_reviewCount = doc.GetValue<int>("review_count"),
                    s_slogan = doc.GetValue<string>("slogan"),
                    s_description = doc.GetValue<string>("description")
                    });
                }
            hotelInfo = lst;
        }

        public bool b_Filter1Function(double x) {
            if(b_filter1 == true) {
                if(x >= 0 && x < 200) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool b_Filter2Function(double x) {
            if(b_filter2 == true) {
                if(x >= 200 && x < 400) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool b_Filter3Function(double x) {
            if(b_filter3) {
                if(x >= 400 && x < 1000) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool b_Filter4Function(double x) {
            if(b_filter4) {
                if(x >= 1000 && x < 2000) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool b_Filter5Function(double x) {
            if(b_filter5) {
                if(x >= 2000 && x <= 5000) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool b_noFiltersChecked() {
            if(b_filter1 == false && b_filter2 == false && b_filter3 == false && b_filter4 == false && b_filter5 == false && stopping_filter == false) {
                return true;
            } else {
                return false;
            }
        }

        //Search Bar stuff
        public string query { get; set; }= "";
	    public string guests { get; set; }= "";
        public DateOnly date1 = DateOnly.FromDateTime(DateTime.Now.AddDays(0));
	    public DateOnly date2 = DateOnly.FromDateTime(DateTime.Now.AddDays(4));
        public DateOnly strtestd { get; set; }
	    public DateOnly strtestd1 { get; set; }
        [Parameter]
	    public EventCallback OnSearch {get; set;}
        public void Searched(IEnumerable<c_hotelInfo> htinfo)
        {
            IEnumerable<c_hotelInfo> tmpenum = (IEnumerable<c_hotelInfo>)htinfo;
            //c_hotelInfo[] tmparr = (c_hotelInfo[])htinfo;
            hotelInfo = htinfo;
            StateHasChanged();
        }

        public void SearchUsed()
        {
            OnSearch.InvokeAsync(hotelInfo);
        }

        public async void search(string qry)
        {
            CollectionReference cr_hotels = db.Collection("Hotels");
            QuerySnapshot qs_hotelDocs = await cr_hotels.GetSnapshotAsync();
            
            Query allHotels = db.Collection("Hotels");
            QuerySnapshot qs_allHotels = await allHotels.GetSnapshotAsync();

            List<c_hotelInfo> results = new List<c_hotelInfo>();

            foreach (DocumentSnapshot doc in qs_allHotels.Documents)
            {
                DocumentReference cr_hotelImg = cr_hotels.Document(doc.Id).Collection("images").Document("0");
                DocumentSnapshot hotelImgs = await cr_hotelImg.GetSnapshotAsync();

                string start = doc.GetValue<string>("start_date");
                string end = doc.GetValue<string>("end_date");

                strtestd = DateOnly.Parse(start);
                strtestd1 = DateOnly.Parse(end);
                //make a int, add to condtions, display guests
                int mguests = doc.GetValue<int>("max_guests");
                int inttmp = 0;

                if(int.TryParse(guests, out inttmp))
                    {
                        if((doc.GetValue<string>("location").Contains(qry) || (date1 < strtestd && date2 >strtestd1)) && (inttmp < mguests))
                            {
                                results.Add(new c_hotelInfo{s_id = doc.Id, 
                                    s_name = doc.GetValue<string>("name"),
                                    s_hotelImgPath = hotelImgs.GetValue<string>("path"),
                                    d_rating = doc.GetValue<double>("rating"),
                                    d_price = doc.GetValue<double>("price"),
                                    i_reviewCount = doc.GetValue<int>("review_count"),
                                    s_slogan = doc.GetValue<string>("slogan"),
                                    s_description = doc.GetValue<string>("description"),
                                    s_startDate = start,
                                    s_endDate = end,
                                    i_maxGuests = mguests
                                    });
                        }
                    }
            }
            hotelInfo = results;
            //SearchUsed();
            Console.WriteLine("Searched\n");
            foreach (var HI in hotelInfo){
                Console.WriteLine(HI.s_name);
            }
            StateHasChanged();
		    await Task.Yield();
        }

    


        public string test = "AHHHHHHHH";

    }
}

