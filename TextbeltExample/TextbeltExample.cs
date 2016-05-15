using System;
using System.Collections.Generic;
using TextbeltClient;

namespace TextbeltExample
{
    public class TextbeltExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Textbelt.sendMessage("5555555555", "This is a test message").ToString());
            Console.Read();
        }
    }
}
