using System;

namespace TradingCardEngine
{
    public class Card : IComparable<Card>
    {
        public Card(int cost, int damage)
        {
            Cost = cost;
            Damage = damage;
        }

        public int Cost { get; }

        public int Damage { get; }

        public int CompareTo(Card other)
        {
            if (this.Cost == other.Cost && this.Damage == other.Damage)
            {
                return 0;
            }
            else if (this.Cost > other.Cost || this.Damage > other.Damage)
            {
                return 1;
            }

            return -1;
        }

        public override string ToString()
        {
            return $"Cost: {Cost}, Damage: {Damage}";
        }
    }
}