using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using GenericsDemo;

namespace GenericsDemo
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Filters array by filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <returns>Filtered array.</returns>
        public static TSource[] FilterBy<TSource>(this TSource[] source, IPredicate<TSource> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            var filteredSource = new List<TSource>();

            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    filteredSource.Add(item);
                }
            }

            return filteredSource.ToArray();
        }

        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null.");
            }

            var filteredSource = new TResult[source.Length];

            for (int i = 0; i < source.Length; i++)
            {
                filteredSource[i] = transformer.Transform(source[i]);
            }

            return filteredSource;
        }

        public static TSource[] OrderAccordingTo<TSource>(this TSource[] source, IComparer<TSource> comparer)
        {
            TSource[] returnArray = new TSource[source.Length];
            source.CopyTo(returnArray, 0);
            TSource element;
            for(int i=0; i < source.Length; i++)
            {
                for (int j = i; j < source.Length; j++)
                {
                    if (comparer.Compare(returnArray[i], returnArray[j]) < 0)
                    {
                        element = returnArray[i];
                        returnArray[i] = returnArray[j];
                        returnArray[j] = element;
                    }
                }
            }

            return returnArray;
        }

        public static TSource[] TypeOf<TSource>(this object[] source)
        {
            TSource[] returnArray = new TSource[source.Length];
            int returnArrayLength = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (ReferenceEquals(source[i].GetType(), typeof(TSource)))
                {
                    returnArray[returnArrayLength] = (TSource)source[i];
                    returnArrayLength++;
                }
            }
            Array.Resize(ref returnArray, returnArrayLength);
            return returnArray;
        }

        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            TSource[] returnArray = new TSource[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                returnArray[i] = source[source.Length - 1 - i];
            }

            return returnArray;
        }
    }
}