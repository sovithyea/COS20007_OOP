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
        public List<Item> Items
        {
            get
            {
                return _items;
            }
        }

        public string ItemList
{
    get
    {
        List<string> itemDescriptions = new List<string>();
        foreach (Item itm in _items)
        {
            itemDescriptions.Add($"{itm.Name} ({itm.FirstId})");
        }
        return string.Join(",", itemDescriptions);
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
