// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMap.cs" company="">
//   
// </copyright>
// <summary>
//   The Map interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.DataStructures
{
    using System.Collections.Generic;

    /// <summary>
    /// The Map interface.
    /// </summary>
    /// <typeparam name="T1">
    /// </typeparam>
    /// <typeparam name="T2">
    /// </typeparam>
    public interface IMap<T1, T2>
    {
        #region Public Properties

        /// <summary>
        ///     Gets the count.
        /// </summary>
        int Count { get; }

        /// <summary>
        ///     Gets the keys.
        /// </summary>
        ICollection<T1> Keys { get; }

        /// <summary>
        ///     Gets the values.
        /// </summary>
        ICollection<T2> Values { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The contains key.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool ContainsKey(T1 t1);

        /// <summary>
        /// The contains value.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool ContainsValue(T2 t2);

        /// <summary>
        /// The forward add.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        void ForwardAdd(T1 t1, T2 t2);

        /// <summary>
        /// The forward item.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <returns>
        /// The <see cref="T2"/>.
        /// </returns>
        T2 ForwardItem(T1 t1);

        /// <summary>
        /// The forward remove.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        void ForwardRemove(T1 t1);

        /// <summary>
        /// The reverse add.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        void ReverseAdd(T2 t2, T1 t1);

        /// <summary>
        /// The reverse item.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <returns>
        /// The <see cref="T1"/>.
        /// </returns>
        T1 ReverseItem(T2 t2);

        /// <summary>
        /// The reverse remove.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        void ReverseRemove(T2 t2);

        /// <summary>
        /// The try forward lookup.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool TryForwardLookup(T1 t1, out T2 t2);

        /// <summary>
        /// The try reverse lookup.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool TryReverseLookup(T2 t2, out T1 t1);

        #endregion
    }
}