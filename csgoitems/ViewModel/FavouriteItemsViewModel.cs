using csgoitems.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using static csgoitems.Model.TopItems;

namespace csgoitems.ViewModel
{
 class FavouriteItemsViewModel : MainViewModel
    {
        private String name;
        private String place;
        private List<TopItem> items;

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


        public ICommand GetFavouriteItemCommand
        {
            get
            {
                return new GetFavouriteItemCommand(FindFavouriteItems);
            }
        }
        public async void FindFavouriteItems()
        {
            var http = new HttpClient();
            var url = String.Format("http://api.csgo.steamlytics.xyz/v1/items/popular?limit=3&key=8d800960760fe478c06f3d90e4dcee7a");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(TopItem));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (TopItem)serializer.ReadObject(ms);
            Name = data.market_hash_name;

        }

    }

}
