using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgoitems.Model
{
    class TopItems
    {
        public class TopItem
        {
            public int rank { get; set; }
            public string market_hash_name { get; set; }
            public int volume { get; set; }
        }

        public class InnerItem
        {
            public bool success { get; set; }
            public List<TopItem> items { get; set; }
            public int build_time { get; set; }
            public int updated_at { get; set; }
        }
    }
}
