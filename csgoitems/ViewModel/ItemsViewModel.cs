using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using csgoitems.Model;
using csgoitems.Command;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;

namespace csgoitems.ViewModel
{
    class CharactersViewModel : MainViewModel
    {
        private String name;
        private String lowestPrice = "";
        private String averagePrice = "";
        private String highestPrice = "";

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

        public String LowestPrice
        {
            get
            {
                return lowestPrice;
            }
            set
            {
                lowestPrice = value;
                OnPropertyChanged("LowestPrice");
            }
        }

        public String AveragePrice
        {
            get
            {
                return averagePrice;
            }
            set
            {
                averagePrice = value;
                OnPropertyChanged("AveragePrice");
            }
        }

        public String HighestPrice
        {
            get
            {
                return highestPrice;
            }
            set
            {
                highestPrice = value;
                OnPropertyChanged("HighestPrice");
            }
        }

        public ICommand GetItemCommand
        {
            get
            {
                return new GetItemCommand(FindItem);
            }
        }
        public async void FindItem()
        {
            var http = new HttpClient();
            var url = String.Format("http://api.csgo.steamlytics.xyz/v1/prices/{0}?key=8d800960760fe478c06f3d90e4dcee7a", name);
            Debug.WriteLine(url);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Items));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Items)serializer.ReadObject(ms);
            LowestPrice = data.lowest_price;
            AveragePrice = data.average_price;
            HighestPrice = data.highest_price;

        }

    }

}