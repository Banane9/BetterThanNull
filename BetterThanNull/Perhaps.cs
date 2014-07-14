using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterThanNull
{
    public struct Perhaps<T>
    {
        public readonly bool HasValue;
        private readonly T value;

        public T Value
        {
            get
            {
                if (!HasValue)
                    throw new InvalidOperationException("There's no value.");

                return value;
            }
        }

        public Perhaps(T value)
        {
            this.value = value;
            HasValue = value != null;
        }

        public static explicit operator T(Perhaps<T> perhaps)
        {
            if (!perhaps.HasValue)
                throw new InvalidCastException("Can't cast an empty Perhaps to its value.");

            return perhaps.Value;
        }

        public static implicit operator Perhaps<T>(T value)
        {
            return new Perhaps<T>(value);
        }

        public Perhaps<TReturn> Select<TReturn>(Func<T, TReturn> selector)
        {
            return HasValue ? selector(Value) : new Perhaps<TReturn>();
        }

        public T ValueOrElse(T @default)
        {
            return HasValue ? Value : @default;
        }
    }
}