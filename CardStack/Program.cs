using System;
using System.Collections.Generic;

namespace CardStack
{
    class Program
    {
        public static Model table = new Model();
        
        static void Main(string[] args)
        {
            ShowInstructions();
        }

        public static void ShowInstructions()
        {
            Console.WriteLine("Press 1 to create new deck");
            Console.WriteLine("Press 2 to delete deck");
            Console.WriteLine("Press 3 to get all decks names");
            Console.WriteLine("Press 4 to see deck");
            Console.WriteLine("Press 5 to randomly shuffle deck");
            Console.WriteLine("Press 6 to hand emulate shuffle deck");
            Console.WriteLine("Press 7 to reset instructions");
            ReadInstructions();
        }

        public static void ReadInstructions()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    CreateDeck();
                    break;
                case "2":
                    DeleteDeck();
                    break;
                case "3": 
                    GetNames();
                    break;
                case "4":
                    ShowDeck();
                    break;
                case "5":
                    ShuffleDeck(false);
                    break;
                case "6":
                    ShuffleDeck(true);
                    break;
                case "7":
                    Console.Clear();
                    ShowInstructions();
                    break;
            }
        }
        public static void CreateDeck()
        {
            Console.WriteLine("Enter name of a deck");
            table.CreateDeck(Console.ReadLine());
            ReadInstructions();
        }
        
        public static void DeleteDeck()
        {
            Console.WriteLine("Enter name of a deck you wanted deleted");
            table.DeleteDeck(Console.ReadLine());
            ReadInstructions();
        }
        
        public static void GetNames()
        {
            foreach (var i in table.GetAllDecksNames())
            {
                Console.WriteLine(i);
            }
            ReadInstructions();
        }
        
        public static void ShowDeck()
        {
            Console.WriteLine("Enter name of a deck you wanted to see");
            foreach (var i in table.GetDeck(Console.ReadLine()).cardDeck)
            {
                Console.WriteLine(i.suit.ToString() + "  " + i.value.ToString());
            }

            Console.WriteLine(table.GetString("will"));
            ReadInstructions();
        }
        
        public static void ShuffleDeck(bool handEmulate)
        {
            Console.WriteLine("Enter name of a deck you wanted to get shuffled");
            table.ShuffleDeck(Console.ReadLine(), handEmulate);
            ReadInstructions();
        }
        
    }
}
