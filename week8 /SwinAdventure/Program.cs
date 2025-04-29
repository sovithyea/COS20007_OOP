using System;
using SwinAdventure;

namespace MainProgram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Player _testPlayer = new Player("James", "an explorer");

            Item item1 = new Item(new string[] { "silver", "hat" }, "A Silver Hat", "A very shiny silver hat");
            Item item2 = new Item(new string[] { "light", "torch" }, "A Torch", "A Torch to light the path");

            _testPlayer.Inventory.Put(item1);
            _testPlayer.Inventory.Put(item2);

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
        }
    }
}
