using System;
using System.Collections.Generic;
using System.Text;
using DoubleManipulation;
using GenericsDemo;

namespace GenericDemo.ConsoleClient
{
    class DoubleExtensionTransformer : ITransformer<double, string>
    {
        public string Transform(double value)
        {
            return value.TransformToIEEE754();
        }
    }
}
