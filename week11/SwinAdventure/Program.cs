using System;
using System.IO;
using SwinAdventure;
using System.Collections.Generic;

namespace MainProgram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your player's name:");
            string playerName = Console.ReadLine();

            Console.WriteLine("Enter your player's description:");
            string playerDesc = Console.ReadLine();

            Player _testPlayer = new Player(playerName, playerDesc);

            Item item1 = new Item(new[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new[] { "light", "torch" }, "A Torch", "A Torch to light the path");
            Item item3 = new Item(new[] { "gold", "ring" }, "A Gold Ring", "A very shiny gold ring");
            Item item4 = new Item(new[] { "sword", "blade" }, "A Sword", "A very sharp sword");

            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);
            _testPlayer.Inventory.Put(item3);
            _testPlayer.Inventory.Put(item4);

            _testPlayer.ListInventory();

            List<IHaveInventory> myContainers = new List<IHaveInventory>();
            myContainers.Add(_testPlayer);

            Bag _testToolBag = new Bag(new[] { "bag", "tool" }, "Tools Bag", "A bag that contains tools");
            Item _testItem2 = new Item(new[] { "stew", "beef" }, "A Beef Stew", "A hearty beef stew");
            Item _testItem3 = new Item(new[] { "axe", "tool" }, "Axe", "A sharp axe");
            Item _testItem4 = new Item(new[] { "screwdriver", "tool" }, "Screwdriver", "A flathead screwdriver");

            _testToolBag.Inventory.Put(_testItem3);
            _testToolBag.Inventory.Put(_testItem2);
            _testPlayer.Inventory.Put(_testToolBag);
            myContainers.Add(_testToolBag);

            StreamWriter writer = new StreamWriter("TestPlayer.txt");
            try
            {
                _testPlayer.SaveTo(writer);
            }
            finally
            {
                writer.Close();
            }

            StreamReader reader = new StreamReader("TestPlayer.txt");
            try
            {
                _testPlayer.LoadFrom(reader);
            }
            finally
            {
                reader.Close();
            }

            for (int i = 0; i < myContainers.Count; i++)
            {
                IHaveInventory holder = myContainers[i];

                if (holder is Player p)
                {
                    Console.WriteLine("\n[Player Info]");
                    Console.WriteLine(p.FullDescription);
                    Console.WriteLine($"Item count: {p.Inventory.Items.Count}");
                }
                else if (holder is Bag b)
                {
                    Console.WriteLine("\n[Bag Info]");
                    Console.WriteLine(b.FullDescription);
                    Console.WriteLine($"Item count: {b.Inventory.Items.Count}");
                }
            }

            LookCommand cmd = new LookCommand(new[] { "look" });

            bool finished = false;
            Console.WriteLine("\nEnter a command (e.g., 'look at hat', 'look at stew in bag'). Type 'exit' to quit.");
            while (!finished)
            {
                Console.Write("\n> ");
                string command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    finished = true;
                    continue;
                }

                string[] split = command.Split(" ");

                Console.WriteLine(cmd.Execute(_testPlayer, split));
            }
        }
    }
}
