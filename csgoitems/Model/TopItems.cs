using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace csgoitems.Model
{
    class TopItems
    {
        [DataContract]
        public class TopItem
        {
            [DataMember]
            public int rank { get; set; }
            [DataMember]
            public string market_hash_name { get; set; }
            [DataMember]
            public int volume { get; set; }
        }
        [DataContract]
        public class InnerItem
        {
            [DataMember]
            public bool success { get; set; }
            [DataMember]
            public List<TopItem> items { get; set; }
            [DataMember]
            public int build_time { get; set; }
            [DataMember]
            public int updated_at { get; set; }
        }
    }
}
