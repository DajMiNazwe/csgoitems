using csgoitems.Command;
using csgoitems.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static csgoitems.Model.TopItems;

namespace csgoitems.ViewModel
{
 class FavouriteItemsViewModel : MainViewModel
    {
        private String name;
        private String place;
        private String first;
        private String second;
        private String third;
        private String fourth;
        private String fifth;
        private String sixth;
        private String seventh;
        private String eight;
        private String ninth;
        private String tenth;

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public String Place
        {
            get
            {
                return place;
            }
            set
            {
                place = value;
                OnPropertyChanged("Place");
            }
        }

        public String First
        {
            get
            {
                return first;
            }
            set
            {
                first = value;
                OnPropertyChanged("First");
            }
        }
        public String Second
        {
            get
            {
                return second;
            }
            set
            {
                second = value;
                OnPropertyChanged("Second");
            }
        }
        public String Third
        {
            get
            {
                return third;
            }
            set
            {
                third = value;
                OnPropertyChanged("Third");
            }
        }
        public String Fourth
        {
            get
            {
                return fourth;
            }
            set
            {
                fourth = value;
                OnPropertyChanged("Fourth");
            }
        }

        public String Fifth
        {
            get
            {
                return fifth;
            }
            set
            {
                fifth = value;
                OnPropertyChanged("Fifth");
            }
        }
        public String Sixth
        {
            get
            {
                return sixth;
            }
            set
            {
                sixth = value;
                OnPropertyChanged("Sixth");
            }
        }
        public String Seventh
        {
            get
            {
                return seventh;
            }
            set
            {
                seventh = value;
                OnPropertyChanged("Seventh");
            }
        }
        public String Eight
        {
            get
            {
                return eight;
            }
            set
            {
                eight = value;
                OnPropertyChanged("Eight");
            }
        }
        public String Ninth
        {
            get
            {
                return ninth;
            }
            set
            {
                ninth = value;
                OnPropertyChanged("Ninth");
            }
        }

        public String Tenth
        {
            get
            {
                return tenth;
            }
            set
            {
                tenth = value;
                OnPropertyChanged("Tenth");
            }
        }

        public ICommand GetTopItemsCommand
        {
            get
            {
                return new GetTopItemsCommand(FindFavouriteItems);
            }
        }
        public async void FindFavouriteItems()
        {
            List<String> items = new List<string>();
            var http = new HttpClient();
            var url = String.Format("http://api.csgo.steamlytics.xyz/v1/items/popular?limit=10&key=8d800960760fe478c06f3d90e4dcee7a");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(InnerItem));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (InnerItem)serializer.ReadObject(ms);
            var i = 0;
            foreach (TopItem element in data.items)
            {
                Debug.WriteLine(data.items[i].market_hash_name);
                items.Add(data.items[i].market_hash_name);
                i++;
            }
            Debug.WriteLine(items);
            First = data.items[0].market_hash_name;
            Second = data.items[1].market_hash_name;
            Third = data.items[2].market_hash_name;
            Fourth = data.items[3].market_hash_name;
            Fifth = data.items[4].market_hash_name;
            Sixth = data.items[5].market_hash_name;
            Seventh = data.items[6].market_hash_name;
            Eight = data.items[7].market_hash_name;
            Ninth = data.items[8].market_hash_name;
            Tenth = data.items[9].market_hash_name;

        }

    }

}
