using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            //Default
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


        public Card SetRS(Rank rank, Suit suit)
        {
            this.pRank = rank;
            this.pSuit = suit;
            return this;
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
            Program p = new Program();
            Console.WriteLine("Draw How Many?");
            int input = int.Parse(Console.ReadLine());
            for (int i = input; i >= 0; --i)
            {
                hand.Add(deck[i]);
                deck.Remove(deck[i]);
            }
            //p.Order(deck);
            p.Shuffle(deck);
            return hand;
        }

        public List<Card> Draw(List<Card> hand, List<Card> deck, int howMany)
        {
            Program p = new Program();
            if (deck.Count > 0)
            {
                Console.WriteLine($"{Name} Draws!");
                for (int i = howMany; i >= 0; --i)
                {
                    hand.Add(deck[i]);
                    deck.Remove(deck[i]);
                }
                //p.Order(deck);
                p.Shuffle(deck);
                return hand;
            }
            else
            {
                Console.WriteLine("Deck Empty");
                return hand;
            }
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
            int pairCount;
            int p1BookCount = 0;
            int p2BookCount = 0;
            Card checkCard = new Card();
            //Game Loop
            List<Card> deck = new List<Card>();
            deck = CreateDeck();
            //P1 Books
            List<Card> p1aceBook = new List<Card>();
            List<Card> p1twoBook = new List<Card>();
            List<Card> p1threeBook = new List<Card>();
            List<Card> p1fourBook = new List<Card>();
            List<Card> p1fiveBook = new List<Card>();
            List<Card> p1sixBook = new List<Card>();
            List<Card> p1sevenBook = new List<Card>();
            List<Card> p1eightBook = new List<Card>();
            List<Card> p1nineBook = new List<Card>();
            List<Card> p1tenBook = new List<Card>();
            List<Card> p1jackBook = new List<Card>();
            List<Card> p1queenBook = new List<Card>();
            List<Card> p1kingBook = new List<Card>();
            //P2 Books
            List<Card> p2aceBook = new List<Card>();
            List<Card> p2twoBook = new List<Card>();
            List<Card> p2threeBook = new List<Card>();
            List<Card> p2fourBook = new List<Card>();
            List<Card> p2fiveBook = new List<Card>();
            List<Card> p2sixBook = new List<Card>();
            List<Card> p2sevenBook = new List<Card>();
            List<Card> p2eightBook = new List<Card>();
            List<Card> p2nineBook = new List<Card>();
            List<Card> p2tenBook = new List<Card>();
            List<Card> p2jackBook = new List<Card>();
            List<Card> p2queenBook = new List<Card>();
            List<Card> p2kingBook = new List<Card>();

            List<List<Card>> p1Books = new List<List<Card>>() { p1aceBook, p1twoBook, p1threeBook, p1fourBook, p1fiveBook, p1sixBook, p1sevenBook, p1eightBook, p1nineBook, p1tenBook, p1jackBook, p1queenBook, p1kingBook };
            List<List<Card>> p2Books = new List<List<Card>>() { p2aceBook, p2twoBook, p2threeBook, p2fourBook, p2fiveBook, p2sixBook, p2sevenBook, p2eightBook, p2nineBook, p2tenBook, p2jackBook, p2queenBook, p2kingBook };

            //int cards = 0;
            //foreach (Card card in deck)
            //{
            //    cards++;
            //    Console.WriteLine($"{card}[{cards}]");
            //}

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
            /* Debug Code */
            //Card c1 = new Card();
            //Card c2 = new Card();
            //Card c3 = new Card();
            //Card c4 = new Card();
            //c1.SetRS(Card.Rank.Seven, Card.Suit.Clubs);
            //p1.Hand.Add(c1);
            //c2.SetRS(Card.Rank.Seven, Card.Suit.Diamonds);
            //p1.Hand.Add(c2);
            //c3.SetRS(Card.Rank.Seven, Card.Suit.Spades);
            //p1.Hand.Add(c3);
            //for (int i = 0; i < 3; i++)
            //{
            //    p1.Hand.Add(c1);
            //}
            /* Debug Code */

            Player p2 = new Player("Comp", 5);
            Console.WriteLine("=========================");

            //cards = 0;
            //foreach (Card card in deck)
            //{
            //    cards++;
            //    Console.WriteLine($"{card}[{cards}]");
            //}

            p2.Hand = deck;
            /* Debug Code */
            //c4.SetRS(Card.Rank.Seven, Card.Suit.Hearts);
            //p2.Hand.Add(c4);
            /* Debug Code */

            while (gameLoop == true)
            {
                //Player 1 turn
                Console.WriteLine($"{p1.Name}'s Turn");
                Console.WriteLine(p1);
                Console.WriteLine($"\n\nFor Debugging:\n{p2}");
                Console.WriteLine("What card rank are you asking for?");
                input = Console.ReadLine();
                checkCard.pRank = (Card.Rank)Enum.Parse(typeof(Card.Rank), input);
                pairCount = 0;
                foreach (var card in p2.Hand)
                {
                    if (checkCard.pRank == card.pRank)
                    {
                        pairCount++;
                    }
                }
                if (pairCount > 0)
                {
                    Console.WriteLine($"You took {p2.Name}'s card(s)!");
                    for (int i = p2.Hand.Count - 1; i >= 0; --i)
                    {
                        if (p2.Hand[i].pRank == checkCard.pRank)
                        {
                            p1.Hand.Add(p2.Hand[i]);
                            p2.Hand.Remove(p2.Hand[i]);
                        }
                    }
                }
                //Turn End / Draw Phase(If "Go Fished")
                else
                {
                    Console.WriteLine("Go Fish!");
                    p1.Draw(p1.Hand, deck, 1);
                }


                int dupeCard = 0;
                for (int i = p1.Hand.Count - 1; i >= 0; --i)
                {
                    Console.WriteLine($"Value of i: {i}");
                    Console.WriteLine($"Index of p1 hand: {p1.Hand.Count}");
                    if (i >= p1.Hand.Count && i != 0)
                    {
                        if (p1.Hand.Count > 0)
                        {
                            i = p1.Hand.Count - 1;
                        }
                    }
                    if (p1.Hand.Count == 0)
                    {
                        Console.WriteLine("Hand Empty");
                        break;
                    }
                    switch (p1.Hand[i].pRank)
                        {
                            case Card.Rank.Ace:
                                if (p1aceBook.Count == 0)
                                {
                                    p1aceBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1aceBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1aceBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1aceBook.Add(p1.Hand[i]);
                                }

                                if (p1aceBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Ace)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Two:
                                if (p1twoBook.Count == 0)
                                {
                                    p1twoBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1twoBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1twoBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1twoBook.Add(p1.Hand[i]);
                                }

                                if (p1twoBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Two)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Three:
                                if (p1threeBook.Count == 0)
                                {
                                    p1threeBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1threeBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1threeBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1threeBook.Add(p1.Hand[i]);
                                }

                                if (p1threeBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Three)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }

                                }
                                break;

                            case Card.Rank.Four:
                                if (p1fourBook.Count == 0)
                                {
                                    p1fourBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1fourBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1fourBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1fourBook.Add(p1.Hand[i]);
                                }

                                if (p1fourBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Four)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Five:
                                if (p1fiveBook.Count == 0)
                                {
                                    p1fiveBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1fiveBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1fiveBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1fiveBook.Add(p1.Hand[i]);
                                }

                                if (p1fiveBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Five)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Six:
                                if (p1sixBook.Count == 0)
                                {
                                    p1sixBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1sixBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1sixBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1sixBook.Add(p1.Hand[i]);
                                }

                                if (p1sixBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Six)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Seven:
                                if (p1sevenBook.Count == 0)
                                {
                                    p1sevenBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1sevenBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1sevenBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1sevenBook.Add(p1.Hand[i]);
                                }

                                if (p1sevenBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Seven)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Eight:
                                if (p1eightBook.Count == 0)
                                {
                                    p1eightBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1eightBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1eightBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1eightBook.Add(p1.Hand[i]);
                                }

                                if (p1eightBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Eight)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Nine:
                                if (p1nineBook.Count == 0)
                                {
                                    p1nineBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1nineBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1nineBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1nineBook.Add(p1.Hand[i]);
                                }

                                if (p1nineBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Nine)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Ten:
                                if (p1tenBook.Count == 0)
                                {
                                    p1tenBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1tenBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1tenBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1tenBook.Add(p1.Hand[i]);
                                }

                                if (p1tenBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Ten)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Jack:
                                if (p1jackBook.Count == 0)
                                {
                                    p1jackBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1jackBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1jackBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1jackBook.Add(p1.Hand[i]);
                                }

                                if (p1jackBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Jack)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.Queen:
                                if (p1queenBook.Count == 0)
                                {
                                    p1queenBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1queenBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1queenBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1queenBook.Add(p1.Hand[i]);
                                }

                                if (p1queenBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.Queen)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            case Card.Rank.King:
                                if (p1kingBook.Count == 0)
                                {
                                    p1kingBook.Add(p1.Hand[i]);
                                }

                                dupeCard = 0;
                                for (int k = 0; k < p1kingBook.Count; k++)
                                {
                                    if (p1.Hand[i].pSuit == p1kingBook[k].pSuit)
                                    {
                                        dupeCard++;
                                    }
                                }

                                if (dupeCard == 0)
                                {
                                    p1kingBook.Add(p1.Hand[i]);
                                }

                                if (p1kingBook.Count == 4)
                                {
                                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                                    {
                                        if (p1.Hand[j].pRank == Card.Rank.King)
                                        {
                                            p1.Hand.Remove(p1.Hand[j]);
                                        }
                                    }
                                }
                                break;

                            default:
                                break;

                        }
                }


                foreach (var card in p1Books[0])
                {
                    Console.WriteLine(card);
                }
                foreach (var book in p1Books)
                {
                    if (book.Count == 4)
                    {
                        Console.WriteLine($"{p1.Name} has a book of {book[0].pRank}s");
                        Console.WriteLine($"{book[0].pRank} Amount: {book.Count}");
                        //foreach (Card card in book)
                        //{
                        //    Console.WriteLine(card);
                        //}
                    }
                }

                if (!deck.Any() && !p1.Hand.Any() && !p2.Hand.Any())
                {
                    foreach (var book in p1Books)
                    {
                        p1BookCount++;
                    }
                    foreach (var book in p2Books)
                    {
                        p2BookCount++;
                    }
                    break;
                }


                //Console.WriteLine($"{p1}\n\n");                


                //Player 2 turn //update variables!!!!!!!!!!
                Console.WriteLine($"{p2.Name}'s Turn");
                Console.WriteLine(p2);
                Console.WriteLine($"\n\nFor Debugging:\n{p1}");
                Console.WriteLine("What card rank are you asking for?");
                input = Console.ReadLine();
                checkCard.pRank = (Card.Rank)Enum.Parse(typeof(Card.Rank), input);
                pairCount = 0;
                foreach (var card in p1.Hand)
                {
                    if (checkCard.pRank == card.pRank)
                    {
                        pairCount++;
                    }
                }
                if (pairCount > 0)
                {
                    Console.WriteLine($"You took {p1.Name} cards!");
                    for (int j = p1.Hand.Count - 1; j >= 0; --j)
                    {
                        if (p1.Hand[j].pRank == checkCard.pRank)
                        {
                            p2.Hand.Add(p1.Hand[j]);
                            p1.Hand.Remove(p1.Hand[j]);
                        }
                    }
                }
                //Turn End / Draw Phase(If "Go Fished")
                else
                {
                    Console.WriteLine("Go Fish!");
                    p2.Draw(p2.Hand, deck, 1);
                }
                //Console.WriteLine($"{p1}\n\n");

                for (int i = p2.Hand.Count - 1; i >= 0; --i)
                {
                    Console.WriteLine($"Value of i: {i}");
                    Console.WriteLine($"Index of p2 hand: {p2.Hand.Count}");
                    if (i >= p2.Hand.Count && i != 0)
                    {
                        if (p2.Hand.Count > 0)
                        {
                            i = p2.Hand.Count - 1;
                        }
                    }
                    if (p2.Hand.Count == 0)
                    {
                        break;
                    }
                    switch (p2.Hand[i].pRank)
                    {
                        case Card.Rank.Ace:
                            if (p2aceBook.Count == 0)
                            {
                                p2aceBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2aceBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2aceBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2aceBook.Add(p2.Hand[i]);
                            }

                            if (p2aceBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Ace)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Two:
                            if (p2twoBook.Count == 0)
                            {
                                p2twoBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2twoBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2twoBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2twoBook.Add(p2.Hand[i]);
                            }

                            if (p2twoBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Two)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Three:
                            if (p2threeBook.Count == 0)
                            {
                                p2threeBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2threeBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2threeBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2threeBook.Add(p2.Hand[i]);
                            }

                            if (p2threeBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Three)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }

                            }
                            break;

                        case Card.Rank.Four:
                            if (p2fourBook.Count == 0)
                            {
                                p2fourBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2fourBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2fourBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2fourBook.Add(p2.Hand[i]);
                            }

                            if (p2fourBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Four)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Five:
                            if (p2fiveBook.Count == 0)
                            {
                                p2fiveBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2fiveBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2fiveBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2fiveBook.Add(p2.Hand[i]);
                            }

                            if (p2fiveBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Five)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Six:
                            if (p2sixBook.Count == 0)
                            {
                                p2sixBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2sixBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2sixBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2sixBook.Add(p2.Hand[i]);
                            }

                            if (p2sixBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Six)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }

                            }
                            break;

                        case Card.Rank.Seven:
                            if (p2sevenBook.Count == 0)
                            {
                                p2sevenBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2sevenBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2sevenBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2sevenBook.Add(p2.Hand[i]);
                            }

                            if (p2sevenBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Seven)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Eight:
                            if (p2eightBook.Count == 0)
                            {
                                p2eightBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2eightBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2eightBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2eightBook.Add(p2.Hand[i]);
                            }

                            if (p2eightBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Eight)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Nine:
                            if (p2nineBook.Count == 0)
                            {
                                p2nineBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2nineBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2nineBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2nineBook.Add(p2.Hand[i]);
                            }

                            if (p2nineBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Nine)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Ten:
                            if (p2tenBook.Count == 0)
                            {
                                p2tenBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2tenBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2tenBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2tenBook.Add(p2.Hand[i]);
                            }

                            if (p2tenBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Ten)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Jack:
                            if (p2jackBook.Count == 0)
                            {
                                p2jackBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2jackBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2jackBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2jackBook.Add(p2.Hand[i]);
                            }

                            if (p2jackBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Jack)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.Queen:
                            if (p2queenBook.Count == 0)
                            {
                                p2queenBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2queenBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2queenBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2queenBook.Add(p2.Hand[i]);
                            }

                            if (p2queenBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.Queen)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        case Card.Rank.King:
                            if (p2kingBook.Count == 0)
                            {
                                p2kingBook.Add(p2.Hand[i]);
                            }

                            dupeCard = 0;
                            for (int k = 0; k < p2kingBook.Count; k++)
                            {
                                if (p2.Hand[i].pSuit == p2kingBook[k].pSuit)
                                {
                                    dupeCard++;
                                }
                            }

                            if (dupeCard == 0)
                            {
                                p2kingBook.Add(p2.Hand[i]);
                            }

                            if (p2kingBook.Count == 4)
                            {
                                for (int j = p2.Hand.Count - 1; j >= 0; --j)
                                {
                                    if (p2.Hand[j].pRank == Card.Rank.King)
                                    {
                                        p2.Hand.Remove(p2.Hand[j]);
                                    }
                                }
                            }
                            break;

                        default:
                            break;

                    }        
                }

                foreach (var book in p2Books)
                {
                    if (book.Count == 4)
                    {
                        Console.WriteLine($"{p2.Name} has a book of {book[0].pRank}s");
                        foreach (Card card in book)
                        {
                            Console.WriteLine(card);
                        }
                    }
                }
                
                if (!p1.Hand.Any() && !p2.Hand.Any())
                {
                    if (!deck.Any())
                    {
                        foreach (var book in p1Books)
                        {
                            p1BookCount++;
                        }
                        foreach (var book in p2Books)
                        {
                            p2BookCount++;
                        }
                        break;
                    }
                    else
                    {
                        //
                    }
                }
            }
            if (p1BookCount > p2BookCount)
            {
                Console.WriteLine($"{p1.Name} Wins!");
            }
            else if (p2BookCount > p1BookCount)
            {
                Console.WriteLine($"{p2.Name} Wins!");
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

        public List<Card> Shuffle(List<Card> deck)
        {
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

        public List<Card> Order(List<Card> deck)
        {
            int sorter = 0;
            for (int n = deck.Count - 1; n > 0; --n)
            {
                sorter++;
                int k = sorter;
                deck.Insert(sorter, deck[n]);
                //Card temp = deck[n];
                //deck[n] = deck[k];
                //deck[k] = temp;
            }
            return deck;
        }




        static void Main(string[] args)
        {

            GoFish(); //Current Issue: Sometimes when its announced that a player has a book of cards, that player will still have their cards. Need to find out when this happens and why. Possibly in switch case
            /*
             * TODO LIST
             * 1) Check rules for how many books needed to win (Win Condition, All 13 books have been collected.)
             * 2) Create a check for the win condition (Whoever has the most books wins)
             * 3) PROFIT$$$$$$$$$$$$$
             */



            //Console.SetWindowSize(80, 20);
            //List<Card> deck = CreateDeck();
            //Console.WriteLine("=========================");
            //int count = 0;
            //foreach (Card card in deck)
            //{
            //    count++;
            //    Console.WriteLine($"[{count}] {card}");
            //}







            /*
             Reccomended by Antonio to parse values(ints & strings) to enums:
                Rank rank;
                Card newCard = new Card();
                if (Enum.TryParse(input, out Rank rank))
                {
                    if (Enum.IsDefined(typeof(Rank), rank))
                    {
                        newCard.pRank = rank;

                        Console.WriteLine($"((((( new card rank: {newCard.pRank} )))))");
                    }
                    else
                    {
                        Console.WriteLine("whoa you entered a number which is fine, but it was too big or too small");
                    }
                }
                else
                {
                    Console.WriteLine("SUper bad input!!");
                }
             If possible implement this to GoFish() for efficient card checking
             */
        }
    }
}


