using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterThanNull
{
    public struct Definitely<T>
    {
        public readonly T Value;

        public Definitely(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "Value can't be null.");

            Value = value;
        }

        public static implicit operator Definitely<T>(T value)
        {
            return new Definitely<T>(value);
        }

        public static implicit operator T(Definitely<T> definitely)
        {
            return definitely.Value;
        }
    }
}