using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterThanNull
{
    /// <summary>
    /// Contains a Value that may or may not be null.
    /// </summary>
    /// <typeparam name="T">The type of the Value.</typeparam>
    public struct Perhaps<T>
    {
        /// <summary>
        /// Whether there's a Value or not.
        /// </summary>
        public readonly bool HasValue;

        /// <summary>
        /// Backing field for the Value property. May be null.
        /// </summary>
        private readonly T value;

        /// <summary>
        /// Gets the Value contained in this struct.
        /// <para/>
        /// Will throw an InvalidOperationException when accessed when there's no Value.
        /// </summary>
        public T Value
        {
            get
            {
                if (!HasValue)
                    throw new InvalidOperationException("There's no value.");

                return value;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BetterThanNull.Perhaps&lt;T&gt;"/> struct with the given Value.
        /// </summary>
        /// <param name="value">The value.</param>
        public Perhaps(T value)
        {
            this.value = value;
            HasValue = value != null;
        }

        public static explicit operator T(Perhaps<T> perhaps)
        {
            if (!perhaps.HasValue)
                throw new InvalidCastException("Can't cast an empty Perhaps to its Value.");

            return perhaps.Value;
        }

        public static implicit operator Perhaps<T>(T value)
        {
            return new Perhaps<T>(value);
        }

        /// <summary>
        /// Projects the contained value into a new format.
        /// </summary>
        /// <typeparam name="TReturn">The type returned by the selector.</typeparam>
        /// <param name="selector">Projects the contained Value into a new format.</param>
        /// <returns>The projected Value.</returns>
        public Perhaps<TReturn> Select<TReturn>(Func<T, TReturn> selector)
        {
            return HasValue ? selector(Value) : new Perhaps<TReturn>();
        }

        /// <summary>
        /// Returns the Value contained by this Perhaps, or the given default, if it's empty.
        /// </summary>
        /// <param name="default">The Value returned in case the Perhaps is empty.</param>
        /// <returns>The Value contained by this Perhaps, or the given default.</returns>
        public T ValueOrElse(T @default)
        {
            return HasValue ? Value : @default;
        }
    }
}