using System;
using System.Collections.Generic;
using System.Text;
using GenericsDemo;
using NumberExtension;

namespace GenericDemo.ConsoleClient
{
    public class DigitPredicateAdapty : IPredicate<int>
    {
        private readonly PredicateDigit predicate;

        /// <summary>Initializes a new instance of the <see cref="DigitPredicateAdapty"/> class.</summary>
        /// <param name="predicate">The predicate.</param>
        /// <exception cref="ArgumentNullException">predicate is null.</exception>
        public DigitPredicateAdapty(PredicateDigit predicate)
        {
            this.predicate = predicate ?? throw new ArgumentNullException($"{nameof(predicate)} is null");
        }

        /// <summary>Determines whether an integer number matches a specific condition.</summary>
        /// <param name="value">Integer number.</param>
        /// <returns>true if an integer number matches a specific condition; otherwise, false.</returns>
        public bool IsMatch(int value)
        {
            return this.predicate.ContainsKey(value);
        }
    }
}
