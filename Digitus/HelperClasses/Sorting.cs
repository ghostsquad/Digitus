// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Sorting.cs">
//   
// </copyright>
// <summary>
//   The sorting.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------
namespace Digitus.HelperClasses
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The sorting.
    /// </summary>
    public static class Sorting
    {
        #region Public Methods and Operators

        /// <summary>
        /// The is sorted.
        /// </summary>
        /// <param name="this">
        /// The this.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsSorted<T>(this IEnumerable<T> @this, Comparison<T> comparison = null)
        {
            if (comparison == null)
            {
                comparison = Comparer<T>.Default.Compare;
            }

            using (IEnumerator<T> e = @this.GetEnumerator())
            {
                if (!e.MoveNext())
                {
                    return true;
                }

                T prev = e.Current;
                while (e.MoveNext())
                {
                    T current = e.Current;
                    if (comparison(prev, current) > 0)
                    {
                        return false;
                    }

                    prev = current;
                }
            }

            return true;
        }

        #endregion
    }
}