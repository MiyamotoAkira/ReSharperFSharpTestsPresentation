using System.CodeDom;

namespace TradingCardEngine
{
    internal class Card
    {
        public Card(int cost, int damage)
        {
            Cost = cost;
            Damage = damage;
        }

        public int Cost { get; }

        public int Damage { get; }

        public override string ToString()
        {
            return $"Cost: {Cost}, Damage: {Damage}";
        }
    }
}