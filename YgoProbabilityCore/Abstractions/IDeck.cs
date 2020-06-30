using System;
using System.Collections.Generic;
using System.Text;

namespace YgoProbabilityCore.Abstractions
{
    internal interface IDeck<T> : IDisposable
    {
        void Shuffle();

        List<T> Cards { get; }
    }
}
