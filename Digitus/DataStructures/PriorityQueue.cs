// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriorityQueue.cs" company="">
//   
// </copyright>
// <summary>
//   The priority queue.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// The priority queue.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        #region Fields

        /// <summary>
        /// The object storage.
        /// </summary>
        private readonly Dictionary<byte, Queue<T>> objectStorage;

        /// <summary>
        /// The priority index.
        /// </summary>
        private readonly List<byte> priorityIndex;

        /// <summary>
        /// The is sorted.
        /// </summary>
        private bool isSorted = true;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue{T}"/> class.
        /// </summary>
        /// <param name="defaultPriority">
        /// The default priority.
        /// </param>
        public PriorityQueue(byte defaultPriority)
        {
            this.priorityIndex = new List<byte>();
            this.objectStorage = new Dictionary<byte, Queue<T>>();
            this.DefaultPriority = defaultPriority;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue{T}"/> class.
        /// </summary>
        public PriorityQueue()
            : this(0)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets or sets the default priority.
        /// </summary>
        public byte DefaultPriority { get; set; }

        /// <summary>
        /// Gets a value indicating whether is synchronized.
        /// </summary>
        public bool IsSynchronized { get; private set; }

        /// <summary>
        /// Gets the sync root.
        /// </summary>
        public object SyncRoot { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The copy to.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        /// <exception cref="ArgumentException">
        /// </exception>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null.");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index is less than 0.");
            }

            int spaceRemaining = array.Length - index;

            if (spaceRemaining < this.Count)
            {
                throw new ArgumentException("not enough space in array.");
            }

            this.GetAllQueueObjectsInOrder().ToArray().CopyTo(array, index);
        }

        /// <summary>
        /// The dequeue.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Dequeue()
        {
            Queue<T> prioritizedQueue = this.GetHighestPrioritizedQueue();
            T theDequeued = prioritizedQueue.Dequeue();

            this.Count--;

            if (prioritizedQueue.Count == 0)
            {
                this.objectStorage.Remove(this.priorityIndex[0]);
                this.priorityIndex.RemoveAt(0);
            }

            return theDequeued;
        }

        /// <summary>
        /// The enqueue.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public void Enqueue(T obj)
        {
            this.Enqueue(this.DefaultPriority, obj);
        }

        /// <summary>
        /// The enqueue.
        /// </summary>
        /// <param name="priority">
        /// The priority.
        /// </param>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public void Enqueue(byte priority, T obj)
        {
            this.Count++;
            Queue<T> thePrioritizedQueue;
            if (this.objectStorage.TryGetValue(priority, out thePrioritizedQueue))
            {
                thePrioritizedQueue.Enqueue(obj);
            }
            else
            {
                this.priorityIndex.Add(priority);
                thePrioritizedQueue = new Queue<T>();
                thePrioritizedQueue.Enqueue(obj);
                this.objectStorage.Add(priority, thePrioritizedQueue);
            }

            this.isSorted = false;
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return this.GetAllQueueObjectsInOrder().GetEnumerator();
        }

        /// <summary>
        /// The peek.
        /// </summary>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Peek()
        {
            Queue<T> prioritizedQueue = this.GetHighestPrioritizedQueue();
            return prioritizedQueue.Peek();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get all queue objects in order.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<T> GetAllQueueObjectsInOrder()
        {
            var queuedObjects = new List<T>();
            this.SortPriorityIndexIfNecessary();
            foreach (byte priority in this.priorityIndex)
            {
                queuedObjects.AddRange(this.objectStorage[priority]);
            }

            return queuedObjects;
        }

        /// <summary>
        /// The get highest prioritized queue.
        /// </summary>
        /// <returns>
        /// The <see cref="Queue"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        private Queue<T> GetHighestPrioritizedQueue()
        {
            if (this.priorityIndex.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            this.SortPriorityIndexIfNecessary();

            byte highestPriority = this.priorityIndex[0];
            return this.objectStorage[highestPriority];
        }

        /// <summary>
        /// The sort priority index if necessary.
        /// </summary>
        private void SortPriorityIndexIfNecessary()
        {
            if (!this.isSorted)
            {
                this.priorityIndex.Sort();
                this.isSorted = true;
            }
        }

        #endregion
    }
}