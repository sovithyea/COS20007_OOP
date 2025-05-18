using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _listpath = new List<Path>();

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            GameObject item = _inventory.Fetch(id);
            if (item != null)
            {
                return item;
            }

            foreach (Path path in _listpath)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }

            return null;
        }

        public override string FullDescription
        {
            get
            {
                string nameDescription;
                string inventoryDescription;

                if (!string.IsNullOrEmpty(Name))
                {
                    nameDescription = Name;
                }
                else
                {
                    nameDescription = "an Unknown location";
                }

                if (_inventory != null && _inventory.ItemList != "")
                {
                    inventoryDescription = _inventory.ItemList;
                }
                else
                {
                    inventoryDescription = "There are no items in this location.";
                }

                return "You are in " + nameDescription + ". " +
                       base.FullDescription + "\nHere, you can see:\n" + inventoryDescription;
            }
        }

        public string ListPath()
        {
            string lReturn = "Possible path(s):\n";
            foreach (Path path in _listpath)
            {
                lReturn += path.Name;
            }
            return lReturn;
        }

        public void AddPath(Path path)
        {
            _listpath.Add(path);
        }

        public Path? GetPath(string id)
        {
            foreach (Path path in _listpath)
            {
                if (path.AreYou(id))
                    return path;
            }
            return null;
        }
    }
}
