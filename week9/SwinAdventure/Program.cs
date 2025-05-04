using System;
using SwinAdventure;

namespace MainProgram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Player _testPlayer = new Player("John", "an explorer");

            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A Torch to light the path");
            Item item3 = new Item(new string[] { "gold", "ring" }, "A Gold Ring", "A very shiny gold ring");
            Item item4 = new Item(new string[] { "sword", "blade" }, "A Sword", "A very sharp sword");

            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);
            _testPlayer.Inventory.Put(item3);
            _testPlayer.Inventory.Put(item4);

            Console.WriteLine("\nIs player identifiable as 'me'? " + _testPlayer.AreYou("me"));
            Console.WriteLine("Is player identifiable as 'inventory'? " + _testPlayer.AreYou("inventory"));

            if (_testPlayer.Locate("torch") != null)
            {
                Console.WriteLine("\nThe object 'torch' exists!");
                Console.WriteLine("Is 'torch' in inventory? " + _testPlayer.Inventory.HasItem("torch"));
            }
            else
            {
                Console.WriteLine("\nThe object 'torch' does not exist.");
            }
            
            _testPlayer.ListInventory();

             StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try {
                _testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }
            
            //read from the file
            StreamReader reader = new StreamReader("TestPlayer.txt");

            try {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {
                writer.Close();
            }

            List<IHaveInventory> myContainers = new List<IHaveInventory>();
            Player player = new Player("James", "an explorer");
            myContainers.Add(_testPlayer);
            Bag _testToolBag;
            _testToolBag = new Bag(new string[] { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            Item _testItem2;
            _testItem2 = new Item(new string[] { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");
            _testToolBag.Inventory.Put(_testItem2);
            myContainers.Add(_testToolBag);

            for (int i = 0; i < myContainers.Count; i++)
            {
                IHaveInventory holder = myContainers[i];

                if (holder is Player p)
                {
                    Console.WriteLine("\n[Player Info]");
                    Console.WriteLine(p.FullDescription);
                }
                else if (holder is Bag b)
                {
                    Console.WriteLine("\n[Bag Info]");
                    Console.WriteLine(b.FullDescription);
                }
            }
        }
    }
}
