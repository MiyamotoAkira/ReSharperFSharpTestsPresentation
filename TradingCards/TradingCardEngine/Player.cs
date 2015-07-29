using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace TradingCardEngine
{
    internal class Player
    {
        private int life;
        private int mana;
        private CardCollection deck;
        private CardCollection hand;

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

        public void SetDeck(CardCollection deck)
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