using System;
using System.Collections.Generic;
using System.Text;

namespace YgoProbabilityCore.Gameplay
{
    public class CardCount<T>
    {
        private int _count;

        public CardCount(T id)
        {
            this.Id = id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public T Id { get; private set; }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException();

                _count = value;
            }
        }
    }
}
