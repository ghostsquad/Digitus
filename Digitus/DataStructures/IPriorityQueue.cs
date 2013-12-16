// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPriorityQueue.cs" company="">
//   
// </copyright>
// <summary>
//   The PriorityQueue interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.DataStructures
{
    /// <summary>
    /// The PriorityQueue interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IPriorityQueue<T> : IQueue<T>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the default priority.
        /// </summary>
        byte DefaultPriority { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The enqueue.
        /// </summary>
        /// <param name="priority">
        /// The priority.
        /// </param>
        /// <param name="obj">
        /// The obj.
        /// </param>
        void Enqueue(byte priority, T obj);

        #endregion
    }
}