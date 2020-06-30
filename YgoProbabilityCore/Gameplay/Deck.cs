using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using YgoProbabilityCore.Abstractions;

namespace YgoProbabilityCore.Gameplay
{
    internal class Deck<T> : IDeck<T>
    {
        private bool _disposed;
        private List<T> _cards;
        private byte[] _shuffleData;
        private RNGCryptoServiceProvider _rng;

        public Deck(IDeckDescriptor<T> config)
        {
            _disposed = false;
            _cards = new List<T>(config.DeckSize);
            _shuffleData = new byte[1000];
            _rng = new RNGCryptoServiceProvider();
            BuildDeck(config.CardCounts, config.FillerCard);
        }

        private void BuildDeck(HashSet<CardCount<T>> cardCounts, T fillerCard)
        {
            foreach (CardCount<T> c in cardCounts)
            {
                int count = Math.Min(c.Count, 3);

                for (int j = 0; j < count; j++)
                    _cards.Add(c.Id);
            }

            while (_cards.Count < _cards.Capacity)
                _cards.Add(fillerCard);
        }

        public void Shuffle()
        {
            _rng.GetBytes(_shuffleData);

            for (int i = 0; i < _shuffleData.Length; i++)
            {
                int cardIdx = _shuffleData[i] % _cards.Count;
                T id = _cards[cardIdx];

                _cards.RemoveAt(cardIdx);
                _cards.Add(id);
            }
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _rng.Dispose();
            _disposed = true;
        }

        public List<T> Cards { get { return _cards; } }
    }
}
