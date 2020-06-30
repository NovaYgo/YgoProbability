using System;
using System.Collections.Generic;
using System.Text;

namespace YgoProbabilityCore.Abstractions
{
    public interface IHand<T>
    {
        void Reset();

        void Draw(int count);

        bool Has(T id);

        int Count(T id);
    }
}
