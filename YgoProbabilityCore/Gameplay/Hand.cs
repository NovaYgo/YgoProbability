using System;
using System.Collections.Generic;
using System.Text;
using YgoProbabilityCore.Abstractions;

namespace YgoProbabilityCore.Gameplay
{
    public class Hand<T> : IHand<T>
    {
        private int _idx;
        private IDeck<T> _deck;
        private Dictionary<T, int> _hand;

        internal Hand(IDeck<T> deck)
        {
            _idx = 0;
            _deck = deck;
            _hand = new Dictionary<T, int>(_deck.Cards.Capacity);
        }

        public void Reset()
        {
            _idx = 0;
            _hand.Clear();
        }

        public void Draw(int count)
        {
            int stop = Math.Min(_idx + count, _deck.Cards.Count);

            for (; _idx < stop; _idx++)
            {
                T id = _deck.Cards[_idx];

                if (_hand.ContainsKey(id))
                    _hand[id]++;
                else
                    _hand[id] = 1;
            }
        }

        public bool Has(T id)
        {
            return _hand.ContainsKey(id);
        }

        public int Count(T id)
        {
            return _hand.ContainsKey(id) ? _hand[id] : 0;
        }
    }
}
