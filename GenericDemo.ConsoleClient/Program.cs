using System;
using GenericDemo.Tests.Predicates;
using GenericsDemo;
using NumberExtension;

namespace GenericDemo.ConsoleClient
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var source = new int[] { 12, 35, -65, 543, 23 };
            source.FilterBy(new DigitPredicateAdapty(new PredicateDigit() { Digit = 5 })).FilterBy(new OddPredicate());
            var doubleSource = new double[] { 12.5, 13.4, 19.3 };
            var stringSource = doubleSource.Transform(new DoubleExtensionTransformer());
        }
    }
}