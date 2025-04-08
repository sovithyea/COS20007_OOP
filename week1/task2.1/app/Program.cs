// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Wassup gang!");
using System;
namespace HelloWorld
{
    class Program{
        public static void Main(string[] arg)
        {
            Message myMessage1 = new Message("Hello - first message object ID is 001");
            myMessage1.Print();

            Message myMessage2 = new Message("Hello - second Message object ID is 002");
            myMessage2.Print();

            int a = 10;
            int b = 20;
            int c = a + b;
            string prefix_string = "COS20007";
            string suffix_string = "hello1";

            Console.WriteLine(prefix_string + " " + suffix_string);
        }
    }
}
