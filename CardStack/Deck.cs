using System;
using System.Collections.Generic;
using System.Linq;

namespace CardStack
{
    public class Deck
    {
        public string name;
        public List<Card> cardDeck;

        public Deck()
        {
            
        }

        public Deck(string name, List<Card> cardDeck)
        {
            this.name = name;
            this.cardDeck = cardDeck;
        }

        //public Deck(string name)
        //{
        //    this.name = name;
        //    cardDeck = new List<Card>();

        //    foreach (int val in Enum.GetValues(typeof(Values)))
        //    {
        //        foreach (int sui in Enum.GetValues(typeof(Suits)))
        //        {
        //            cardDeck.Add(new Card((Suits)Enum.GetValues(typeof(Suits)).GetValue(sui), (Values)Enum.GetValues(typeof(Values)).GetValue(val)));
        //            //Console.WriteLine(tem);
        //        }
        //    }
        //}

        public Deck(string name)
        {
            this.name = name;
            cardDeck = new List<Card>();

            foreach (var val in GetEnumValues<Values>())
            {
                foreach (var sui in GetEnumValues<Suits>())
                {
                    cardDeck.Add(new Card(sui, val));
                }
            }
        }

        public Deck ShuffleDeck()
        {
            var arr = cardDeck.ToArray();
            var card = new Card();
            for (var i = 1; i < arr.Length; i+=2)
            {
                card = arr[i];
                arr[i] = arr[i-1];
                arr[i - 1] = card;

            }
            return new Deck(name,arr.ToList());
        }

        public Deck ShuffleDeck2()
        {
            var rand = new Random();
            var card = new Card();
            int leftRand, rightRand;
            var arr = cardDeck.ToArray();
            for (int i = 0; i < (int) arr.Length / 2; i++)
            {
                leftRand = rand.Next(0, (int) arr.Length / 2);
                rightRand = rand.Next((int) arr.Length / 2, arr.Length);
                card = arr[rightRand];
                arr[rightRand] = arr[leftRand];
                arr[leftRand] = card;
            }

            return new Deck(name, arr.ToList());
        }

        public Deck HandShuffleDeck()
        {
            var rand = new Random();
            int randNumber;
            for (int i = 0; i < 1000; i++)
            {
                randNumber = rand.Next(0, cardDeck.Count);
                cardDeck.AddRange(cardDeck.GetRange(0,randNumber));
                cardDeck.RemoveRange(0,randNumber);
            }
            return new Deck(name, cardDeck);
        }


        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public string ConvertDeckToString()
        {
            string result="";
            result += name + ' ';
            foreach (var i in cardDeck)
            {
                result += i.suit.ToString() + '/' + i.value.ToString()+' ';
            }

            return result;
        }

        /*public Deck ConvertStringToDeck(string str)
        {
            var strArray = str.Split(' ');
            var cardDeck = new List<Card>();
            
            for (var i=1;i<strArray.Length;i++)
            {
                cardDeck.Add(new Card());
            }
        }*/


    }
}
