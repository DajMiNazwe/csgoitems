using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csgoitems.Model
{
    public class ItemsManager
    {
        public static void GetAllItems(ObservableCollection<Items> items)
        {
            var allItems = getItems();
            items.Clear();
            allItems.ForEach(p => items.Add(p));
        }

        public static void GetItemsByName(ObservableCollection<Items> items, string name)
        {
            var allItems = getItems();
            var filteredItems = allItems.Where(p => p.Name == name).ToList();
            items.Clear();
            filteredItems.ForEach(p => items.Add(p));
        }
        private static List<Items> getItems()
        {
            var items = new List<Items>();

            items.Add(new Items("Vulcan", "100$"));
            return items;
        }
    }
}
