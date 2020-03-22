using System;
using System.Collections.Generic;

namespace Microsoft.Practices.Unity.Configuration.ConfigurationHelpers
{
    /// <summary>
    /// A couple of useful extension methods on IDictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// GetOrDefault the value from a dictionary, or null if there is no value.
        /// </summary>
        /// <typeparam name="TKey">Key type of dictionary.</typeparam>
        /// <typeparam name="TValue">InjectionParameterValue type of dictionary.</typeparam>
        /// <param name="dictionary">Dictionary to search.</param>
        /// <param name="key">Key to look up.</param>
        /// <returns>The value at the key or null if not in the dictionary.</returns>
        public static TValue GetOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return (dictionary ?? throw new ArgumentNullException(nameof(dictionary))).TryGetValue(key, out TValue value) 
                ? value : (default);
        }
    }
}
