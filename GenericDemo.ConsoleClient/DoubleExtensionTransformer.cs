using System;
using System.Collections.Generic;
using System.Text;
using DoubleManipulation;
using GenericsDemo;

namespace GenericDemo.ConsoleClient
{
    public class DoubleExtensionTransformer : ITransformer<double, string>
    {
        /// <summary>Transforms the specified value to the another value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>Transformed value.</returns>
        public string Transform(double value)
        {
            return value.TransformToIEEE754();
        }
    }
}
