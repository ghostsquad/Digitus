// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringBuilderExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The string builder extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     The string builder extensions.
    /// </summary>
    public static class StringBuilderExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The append collection.
        /// </summary>
        /// <param name="sb">
        /// The string builder.
        /// </param>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <typeparam name="T">
        /// The collection type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        public static StringBuilder AppendCollection<T>(
            this StringBuilder sb, 
            IEnumerable<T> collection, 
            Func<T, string> method)
        {
            foreach (T x in collection)
            {
                sb.Append(method(x));
            }

            return sb;
        }

        /// <summary>
        /// Appends a collection to a string, using a string builder.
        /// </summary>
        /// <param name="sb">
        /// The string builder.
        /// </param>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <typeparam name="T">
        /// The collection type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        public static StringBuilder AppendCollection<T>(this StringBuilder sb, IEnumerable<T> collection)
        {
            foreach (T x in collection)
            {
                sb.Append(x);
            }

            return sb;
        }

        /// <summary>
        /// The prepend line.
        /// </summary>
        /// <param name="sb">
        /// The string builder.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        public static StringBuilder AppendLineBefore(this StringBuilder sb, string value)
        {
            return sb.AppendLine().Append(value);
        }

        #endregion
    }
}