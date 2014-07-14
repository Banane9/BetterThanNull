using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterThanNull
{
    /// <summary>
    /// Contains a Value that is guaranteed to be not null.
    /// <para/>
    /// Don't try to use the default constructor, it will throw a NotSupportedException.
    /// </summary>
    /// <typeparam name="T">The type of the Value.</typeparam>
    public struct Definitely<T>
    {
        /// <summary>
        /// The contained Value. Guaranteed to be not null.
        /// </summary>
        public readonly T Value;

        /// <summary>
        /// Creates a new instance of the <see cref="BetterThanNull.Definitely&lt;T&gt;"/> struct with the given value.
        /// </summary>
        /// <param name="value">The not null value.</param>
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