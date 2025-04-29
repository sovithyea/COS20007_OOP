using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public string ItemList
        {
            get
            {
                string list = String.Empty;
                
                foreach (Item itm in _items)
                {
                    list = list + "\t" + itm.ShortDescription + "\n";
                }
                List<string> ItemDescriptionList = new List<string>();
                foreach (Item itm in _items)
                {
                    ItemDescriptionList.Add(itm.ShortDescription);
                }
                list = string.Join(",", ItemDescriptionList);

                return list;
            }
        }

        public bool HasItem(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                    return true;
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }
        public Item? Fetch(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                    return item;
            }
            return null;
        }

        public Item? Take(string id)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(id))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }
    }
}
