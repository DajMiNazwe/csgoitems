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
