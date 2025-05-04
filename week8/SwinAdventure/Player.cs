using System;
namespace SwinAdventure
{
    public class Player : GameObject
    {
        public List<Item> Items => _inventory.Items;
        private Inventory _inventory;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }


        public Inventory Inventory
        {
            get {
                return _inventory;
            }
        }


        public GameObject? Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return Inventory.Fetch(id);
            }

        }
        public override string FullDescription
        {
            get
            {
                return $"You are {Name} {base.FullDescription}\n" + "You are carrying:\n" + _inventory.ItemList;
            }
        }
        public override void SaveTo(StreamWriter writer){
                base.SaveTo(writer);
                writer.WriteLine(_inventory.ItemList);

        }
        public void ListInventory()
        {
            Console.WriteLine("You are carrying:");
            foreach (Item item in _inventory.Items)
            {
                Console.WriteLine($" {item.Name} ");
            }
        }
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            string itemDescriptionList = reader.ReadLine();

            Console.WriteLine("Player information");
            Console.WriteLine(Name);
            Console.WriteLine($"{Name} (me)");
            Console.WriteLine(itemDescriptionList);
        }

    }
}
