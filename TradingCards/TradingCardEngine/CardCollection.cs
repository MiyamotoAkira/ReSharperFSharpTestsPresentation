using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TradingCardEngine
{
    internal class CardCollection
    {
        private readonly List<Card> _cards;

        public CardCollection()
        {
        }

        public CardCollection(IEnumerable<Card> cards)
        {
            _cards = cards.ToList();
        }

        public int Count => _cards.Count;

        public void AddCard(Card card) => _cards.Add(card);

        public void RemoveCard(Card card) => _cards.Remove(card);

        public Card GetRandom()
        {
            var rand = new Random();
            var position = rand.Next(_cards.Count);
            return _cards[position];
        }

        public void RemoveLast()
        {
            _cards.RemoveAt(_cards.Count -1);
        }

        public string ShowAsString()
        {
            return String.Join(",", _cards);
        }

        public void RemoveCardWithValue(int value)
        {
            _cards.Remove(_cards.First(x => x.Cost == value));
        }
    }
}