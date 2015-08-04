namespace TradingCardEngine
{
    public interface IPlayer
    {
        void DamagePlayer(int damageaValue);
        int Life { get; }
        int Mana { get; }
        int HandCount { get; }
        int DeckCount { get; }
        bool IsPlayerAlive();
        void SetDeck(ICardCollection deck);
        void AddCardToHand();
        void AddMana(int additional);
        void ReduceMana(int used);
        void ReduceLife(int burned);
        void AddLive(int healed);
        void DiscardLastCardFromHand();
        string ShowHandAsString();
        void RemoveCardFromHandWithValue(int value);
    }
}