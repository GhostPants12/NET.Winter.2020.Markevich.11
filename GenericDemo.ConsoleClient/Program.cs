using System;
using GenericsDemo;
using NumberExtension;
using GenericDemo.Tests.Predicates;

namespace GenericDemo.ConsoleClient
{
    static class Program
    {
        static void Main(string[] args)
        {
            var source = new int[] {12, 35, -65, 543, 23};
            source.FilterBy(new DigitPredicateAdapty(new PredicateDigit() {Digit = 5})).FilterBy(new OddPredicate());
            var doubleSource = new Double[] {12.5, 13.4, 19.3};
            var stringSource = doubleSource.Transform(new DoubleExtensionTransformer());
        }
    }
}