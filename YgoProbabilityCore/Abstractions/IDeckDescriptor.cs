using System;
using System.Collections.Generic;
using System.Text;
using YgoProbabilityCore.Gameplay;

namespace YgoProbabilityCore.Abstractions
{
    public interface IDeckDescriptor<T>
    {
        int DeckSize { get; }

        int IterationCount { get; }

        T FillerCard { get; }

        HashSet<CardCount<T>> CardCounts { get; }

        bool HasCombo(IHand<T> drawer);
    }
}
