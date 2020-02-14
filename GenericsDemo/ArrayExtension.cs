using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using GenericsDemo;

namespace GenericsDemo
{
    public static class ArrayExtension
    {
        /// <summary>Filters array by filter.</summary>
        /// <typeparam name="TSource">Type of source array.</typeparam>
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

        /// <summary>Transforms source array into array of the specified type following specified rule.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Transformed array.</returns>
        /// <exception cref="ArgumentNullException">Source array is null or transforming rule is null.</exception>
        /// <exception cref="ArgumentException">Source array is empty.</exception>
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

        /// <summary>Orders the array according to some rule.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparing rule.</param>
        /// <returns>Transformed array.</returns>
        /// <exception cref="ArgumentNullException">Source array is null or comparing rule is null.</exception>
        /// <exception cref="ArgumentException">Source array is empty.</exception>
        public static TSource[] OrderAccordingTo<TSource>(this TSource[] source, IComparer<TSource> comparer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (comparer is null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} cannot be null.");
            }

            TSource[] returnArray = new TSource[source.Length];
            source.CopyTo(returnArray, 0);
            TSource element;
            for (int i = 0; i < source.Length; i++)
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

        /// <summary>  Returns source array's elements of the specified type.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Returns the array of specified type.</returns>
        /// <exception cref="ArgumentNullException">Source is null.</exception>
        public static TSource[] TypeOf<TSource>(this object[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

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

        /// <summary>Reverses the specified source.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Reversed array.</returns>
        /// <exception cref="ArgumentNullException">Source array is null.</exception>
        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            TSource[] returnArray = new TSource[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                returnArray[i] = source[source.Length - 1 - i];
            }

            return returnArray;
        }
    }
}