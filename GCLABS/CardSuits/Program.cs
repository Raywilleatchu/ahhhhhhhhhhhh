using System;
using System.Collections;
using System.Collections.Generic;

namespace CardSuits
{
    class Card
    {
        public Card(Suit _suit, Rank _rank)
        {
            pRank = _rank;
            pSuit = _suit;
        }

        public Card()
        {

        }

        public enum Suit
        {
            Diamonds = 1,
            Hearts = 2,
            Clubs = 3,
            Spades = 4
        }
        public enum Rank
        {
            King = 13,
            Queen = 12,
            Jack = 11,
            Ten = 10,
            Nine = 9,
            Eight = 8,
            Seven = 7,
            Six = 6,
            Five = 5,
            Four = 4,
            Three = 3,
            Two = 2,
            Ace = 1
        }
        private Rank rank;
        private Suit suit;

        public Rank pRank
        {
            get
            {
                return rank;
            }
            set
            {
                rank = value;
            }
        }

        public Suit pSuit
        {
            get
            {
                return suit;
            }
            set
            {
                suit = value;
            }
        }





        public override string ToString()
        {
            return $"{pRank} of {pSuit}";
        }


    }
    class Player
    {
        private string pName;
        private int pSscore;
        private int pHandSize;
        private List<Card> pHand = new List<Card>();

        public Player(string _name, int _HandSize)
        {
            Name = _name;
            HandSize = _HandSize;
            pSscore = 0;

        }
        public Player(string _name)
        {
            Name = _name;
            pSscore = 0;
        }

        public string Name
        {
            get
            {
                return pName;
            }
            set
            {
                pName = value;
            }
        }

        public int HandSize
        {
            get
            {
                return pHandSize;
            }
            set
            {
                pHandSize = value;
            }
        }

        public List<Card> Hand
        {
            get
            {
                return pHand;
            }
            set
            {
                pHand = Draw(pHand, value);
            }
        }

        public int GetScore()
        {
            return pSscore;
        }

        public List<Card> Draw(List<Card> hand, List<Card> deck)
        {
            Console.WriteLine("Draw How Many?");
            int input = int.Parse(Console.ReadLine());
            for (int i = 0; i < input; i++)
            {
                hand.Add(deck[i]);
                deck.Remove(deck[i]);
            }
            return hand;
        }

        public override string ToString()
        {
            Console.WriteLine($"{Name}'s Hand: ");
            foreach (Card card in pHand)
            {
                Console.WriteLine(card);
            }

            return null;
        }

    }



    class Program
    {

        /* Go Fish Rules & Logic
        Players should have 5 cards in hand
        Player 1 asks Player 2 if they have a specific rank
        Check if Player 2 has rank, if yes then give the card(s) to Player 1
        If no then Player 2 calls go fish and Player 1 draws from the deck.
        When 4 cards of the same rank are in a Players hand, it creates a book.
        When all books have been created for each rank, the Player with the most books win.
        */
        public static void GoFish()
        {
            bool gameLoop = true;
            string input;
            //Game Loop
            while (gameLoop == true)
            {
                List<Card> deck = CreateDeck();
                Console.WriteLine("Shuffling Cards");
                for (int i = 0; i <= 10; i++)
                {
                    deck = ShuffleDeck(deck);
                }
                Console.WriteLine("Cards Shuffled");
                //Draw Phase for both players
                Player p1 = new Player("Ray", 5);
                Console.WriteLine("=========================");
                p1.Hand = deck;
                Player p2 = new Player("Comp", 5);
                Console.WriteLine("=========================");
                p2.Hand = deck;
                //Player 1 turn
                Console.WriteLine($"{p1.Name}'s Turn");
                Console.WriteLine(p1);
                Console.WriteLine("What card rank are you asking for?");
                input = Console.ReadLine();
                //Turn End / Draw Phase(If "Go Fished")
                //Player 2 turn
                Console.WriteLine(p2);
                //Turn End / Draw Phase(If "Go Fished")
            }
        }
        public static List<Card> CreateDeck()
        {
            Card card = new Card();
            List<Card> deck = new List<Card>();
            //Add a loop that creates
            //unique cards that equal a deck of 52
            Random num1 = new Random();
            Random num2 = new Random();

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    card = new Card((Card.Suit)i, (Card.Rank)j);
                    deck.Add(card);
                }
            }
            return deck;
        }

        public static List<Card> ShuffleDeck(List<Card> deck)
        {
            Card c = new Card();
            Random rand = new Random();

            for (int n = deck.Count - 1; n > 0; --n)
            {
                int k = rand.Next(n + 1);
                Card temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
            return deck;
        }





        static void Main(string[] args)
        {

            GoFish();

            //Console.SetWindowSize(80, 20);
            //List<Card> deck = CreateDeck();
            //Console.WriteLine("=========================");
            //int count = 0;
            //foreach (Card card in deck)
            //{
            //    count++;
            //    Console.WriteLine($"[{count}] {card}");
            //}
        }
    }
}


