using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgoitems.Model
{
    public class Items
    {
        public string Name { get; set; }
        public string Price { get; set; }

        public Items(string name, string price)
        {
            Name = name;
            Price = price;
        }
    }
}
