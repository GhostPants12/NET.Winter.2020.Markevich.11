using System;
using System.Collections.Generic;
using System.Text;
using GenericsDemo;
using NumberExtension;

namespace GenericDemo.ConsoleClient
{
    class DigitPredicateAdapty : IPredicate<int>
    {
        private readonly PredicateDigit predicate;

        public DigitPredicateAdapty(PredicateDigit predicate)
        {
            this.predicate = predicate ?? throw new ArgumentNullException($"{nameof(predicate)} is null");
        }

        public bool IsMatch(int value)
        {
            return this.predicate.ContainsKey(value);
        }
    }
}
