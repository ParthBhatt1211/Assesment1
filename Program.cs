using System;
using System.Collections.Generic;


namespace PokerTest
{
    class Program
    {
        public static List<Player> players = new List<Player>();
        public static List<Card> communityCards = new List<Card>();
        public static int minimumBet;
        

        public static void Main(string[] args)
        {
            int playerCount;
            Console.WriteLine("How many players?: ");
            playerCount = Int16.Parse(Console.ReadLine());

            DeckOfCards deck = new DeckOfCards();
            deck.setUpDeck();

            // Initialize players
            for (int i = 0; i < playerCount; i++)
            {
                Player player = new Player();
                players.Add(player);

                // Deal 5 random cards
                players[i].unsortedHand.Add(deck.DealCard());
                players[i].unsortedHand.Add(deck.DealCard());
                players[i].unsortedHand.Add(deck.DealCard());
                players[i].unsortedHand.Add(deck.DealCard());
                players[i].unsortedHand.Add(deck.DealCard());                
                players[i].handEvaluator = new HandEvaluator(CardSort(players[i].unsortedHand));
                players[i].Name = (i + 1).ToString();
            }
            // Assign players with their best combinations
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("Player " + (i + 1) + "'s cards:");
                List<Card> c = CardSort(players[i].unsortedHand);
                PrintPlayerCards(c);
                Console.WriteLine();
                                          
            }

            // Check who wins best
            int winner=0;
            Player temp;
            for (int j = 1; j < players.Count; j++)
            {                
                    if (players[j].wins(players[winner]))
                    {
                        winner = j;
                    }
            }

            // Announce winner
            Console.WriteLine("Player " + players[winner].Name + " wins!!! - " + players[winner].handEvaluator.HandValues.Combination);            
            Console.WriteLine();
        }

        static public void PrintPlayerCards(List<Card> cards)
        {
            string[] chars = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
            for (int i = 0; i < cards.Count; i++)
            {
                Console.Write(chars[(int)cards[i].MyValue] + "" + cards[i].MySuit+", ");
            }
        }
        static public List<Card> CardSort(List<Card> playerCards)
        {
            List<Card> totalCards = playerCards;            
            totalCards.Sort((x, y) => x.MyValue.CompareTo(y.MyValue));            
            List<Card> sortedCards = totalCards;
            return sortedCards;
        }
    }
}
