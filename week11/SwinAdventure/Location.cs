using System;
using System.Collections.Generic;
namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }
        public Inventory Inventiry
        {
            get { return _inventory; }
        }
        public GameObject Locate(string id)
        {
            if (AreYou (id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }
        }
        public override string FullDescription
        {
            get
            {
                string nameDescription;
                string inventoryDescription;

                if (Name != null && Name != "")
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
                    inventoryDescription = "There are no items in this location. ";
                }

                return "You are in " + nameDescription + ". " +
                base.FullDescription + "\n Here, you can see :\n" + inventoryDescription;
            }
        }
    }
}