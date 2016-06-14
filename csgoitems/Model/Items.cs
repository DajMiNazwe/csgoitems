using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;

namespace csgoitems.Model
{
    public class ItemsLogic
    {
        public async static Task<Items> GetItems(String name)
        {
            var http = new HttpClient();
            var url = String.Format("http://api.csgo.steamlytics.xyz/v1/prices/{0}?key=8d800960760fe478c06f3d90e4dcee7a",name);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(Items));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (Items)serializer.ReadObject(ms);

            return data;

        }
    }
    [DataContract]
    public class Items
    {
        [DataMember]
        public bool success { get; set; }
        [DataMember]
        public string median_price { get; set; }
        [DataMember]
        public string median_net_price { get; set; }
        [DataMember]
        public string average_price { get; set; }
        [DataMember]
        public string average_net_price { get; set; }
        [DataMember]
        public string lowest_price { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string lowest_net_price { get; set; }
        [DataMember]
        public string highest_price { get; set; }
        [DataMember]
        public string highest_net_price { get; set; }
        [DataMember]
        public string mean_absolute_deviation { get; set; }
        [DataMember]
        public double deviation_percentage { get; set; }
        [DataMember]
        public int volume { get; set; }
        [DataMember]
        public int first_seen { get; set; }
    }
}
