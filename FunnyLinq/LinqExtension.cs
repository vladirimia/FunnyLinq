using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyLinq
{
    public static class LinqExtension
    {
        /// <summary>
        /// Get a random element from an IEnumerable of generics
        /// </summary>
        /// <typeparam name="T">Generic parameter</typeparam>
        /// <param name="source">The source as an IEnumerable</param>
        /// <returns>Random object of type T</returns>
        public static T Whatever<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new NullReferenceException();

            return source.RandomElement();
        }

        /// <summary>
        /// Get a random list of generic objects from an IEnumerable of generics
        /// </summary>
        /// <typeparam name="T">Generic parameter</typeparam>
        /// <param name="source">The source as an IEnumerable</param>
        /// <returns>List of dandom objects of type T</returns>
        public static IEnumerable<T> WhateverMultiple<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new NullReferenceException();

            // how many items the extension method will return
            var returnCount = new Random().Next(0, source.Count());
            ICollection<T> result = new List<T>();

            for(int i = 0; i < returnCount; i++)
            {
                result.Add(source.RandomElement());
            }

            return result;
        }

        /// <summary>
        /// Get a random list of unique generic objects from an IEnumerable of generics
        /// </summary>
        /// <typeparam name="T">Generic parameter</typeparam>
        /// <param name="source">The source as an IEnumerable</param>
        /// <returns>List of dandom objects of type T</returns>
        public static IEnumerable<T> WhateverMultipleButDistinct<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new NullReferenceException();

            // how many items the extension method will return
            var returnCount = new Random().Next(0, source.Count());
            Dictionary<int, T> keyValues = new Dictionary<int, T>();

            int i = 0;
            while (i < returnCount)
            {
                // crate a temporary key (the index) to ensure that only only unique items will be returned
                int tempKey = new Random().Next(0, source.Count());
                if (!keyValues.ContainsKey(tempKey))
                {
                    keyValues.Add(tempKey, source.ElementAt(tempKey));
                    i++;
                }
            }

            return keyValues.Values.ToList();
        }



        /// <summary>
        /// Get a random element from a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        private static T RandomElement<T>(this IEnumerable<T> source)
        {
            return source.ElementAt(new Random().Next(0, source.Count()));
        }
    }
}
