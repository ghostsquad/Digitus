// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueue.cs" company="">
//   
// </copyright>
// <summary>
//   The Queue interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.DataStructures
{
    using System.Collections;

    /// <summary>
    /// The Queue interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IQueue<T> : ICollection
    {
        #region Public Methods and Operators

        /// <summary>
        /// The dequeue.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Dequeue();

        /// <summary>
        /// The enqueue.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        void Enqueue(T obj);

        /// <summary>
        /// The peek.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Peek();

        #endregion
    }
}