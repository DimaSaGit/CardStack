using System;
using System.Collections.Generic;
using System.Linq;

namespace CardStack
{
    /*
     * Класс Deck
     * Содержит поля name и List из Card
     * Реализует интерфейс IDeck описывающий методы 
     * •	Создать именованную колоду карт (колода создаётся упорядоченной)
     * •	Удалить именованную колоду
     * •	Получить список названий колод
     * •	Перетасовать колоду
     * •	Получить колоду по имени (в её текущем упорядоченном/перетасованном состоянии)
     */
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

        /*
         * Метод для перетасовки колоды по имени.
         * Делит колоду пополам, после берёт случайную карту из правой половины и из левой, и меняет их местами
         */
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

        /*
         * Метод для эмуляции ручной перетасовки колоды.
         * Берёт случайное количество карт из конца и ставит их в начало колоды, и так 1000 раз
         *
         * Алгоритм был взят из ТЗ, и при любом количестве итераций колода будет выглядеть словно была только одна итерация
         * 
         */
        public Deck HandShuffleDeck()
        {
            var rand = new Random();
            int randNumber;
            var l = new List<Card>();
            for (int i = 0; i < 1000; i++)
            {
                randNumber = rand.Next(0, cardDeck.Count);
                cardDeck.AddRange(cardDeck.GetRange(0,randNumber));
                cardDeck.RemoveRange(0,randNumber);
                
            }
            return new Deck(name, cardDeck);
        }


        /*
         * Метод для перебора значений enum в foreach
         */
        private static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /*
         * Заготовка метода для преобразования типа данных Deck в строку для записи в БД
         */
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
            var temp = strArray[1].Split('/');
            for (var i=1;i<strArray.Length;i++)
            {
                temp=strArray[i].Split('/');
                cardDeck.Add(new Card());
            }
        }*/

        


    }
}
