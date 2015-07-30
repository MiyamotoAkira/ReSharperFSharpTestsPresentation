namespace TradingCardEngine
{
    public interface ICardCollection
    {
        int Count { get; }
        void AddCard(Card card);
        void RemoveCard(Card card);
        Card GetRandom();
        void RemoveLast();
        string ShowAsString();
        void RemoveCardWithValue(int value);
    }
}