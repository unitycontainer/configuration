using System;
using System.Collections.Generic;

namespace Unity.Configuration.Extensions
{
    /// <summary>
    /// A couple of useful extension methods on IDictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Gets the value from a dictionary, or default (null in most cases) if there is no value.
        /// </summary>
        /// <typeparam name="TKey">Key type of dictionary.</typeparam>
        /// <typeparam name="TValue">InjectionParameterValue type of dictionary.</typeparam>
        /// <param name="dictionary">Dictionary to search.</param>
        /// <param name="key">Key to look up.</param>
        /// <returns>The value at the key or null (default) if not in the dictionary.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (null == dictionary) throw new ArgumentNullException(nameof(dictionary));

            TValue value;
            if (dictionary.TryGetValue(key, out value))
            {
                return value;
            }

            return default;
        }
    }
}
