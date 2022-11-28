using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // unsorted cards
        public List<Card> unsortedHand = new List<Card>();

        public int Money { get; set; }
        public int Bet { get; set; }
        public bool PlayerIngame { get; set; } = true;
        public HandEvaluator handEvaluator = null;

        public bool wins(Player oponent)
        {
            this.handEvaluator.EvaluateHand();
            oponent.handEvaluator.EvaluateHand();

            if (this.handEvaluator.HandValues.Combination > oponent.handEvaluator.HandValues.Combination)
                return true;
            if (this.handEvaluator.HandValues.Combination < oponent.handEvaluator.HandValues.Combination)
                return false;
            if (this.handEvaluator.HandValues.Total > oponent.handEvaluator.HandValues.Total)
                return true;
            if (this.handEvaluator.HandValues.Total < oponent.handEvaluator.HandValues.Total)
                return false;
            if (this.handEvaluator.HandValues.HighCard > oponent.handEvaluator.HandValues.HighCard )
                return true;
            return false;
        }
    }
}

