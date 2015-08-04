namespace TradingCardEngine
{
    public class Player : IPlayer
    {
        private int life;
        private int mana;
        private ICardCollection deck;
        private ICardCollection hand;

        public Player()
        {
            life = 30;
            mana = 0;
            hand = new CardCollection();
        }

        public void DamagePlayer(int damageaValue) => life -= damageaValue;
        public int Life => life;
        public int Mana => mana;

        public bool IsPlayerAlive() => life > 0;

        public void SetDeck(ICardCollection deck)
        {
            this.deck = deck;
        }

        public void AddCardToHand()
        {
            var card = deck.GetRandom();
            hand.AddCard(card);
            deck.RemoveCard(card);
        }

        public int HandCount => hand.Count;
        public int DeckCount => deck.Count;

        public void AddMana(int additional) => mana += additional;

        public void ReduceMana(int used) => mana -= used;

        public void ReduceLife(int burned) => life -= burned;

        public void AddLive(int healed) => life += healed;

        public void DiscardLastCardFromHand()
        {
            hand.RemoveLast();
        }

        public string ShowHandAsString()
        {
            return hand.ShowAsString();
        }

        public void RemoveCardFromHandWithValue(int value)
        {
            hand.RemoveCardWithValue(value);
        }
    }
}