// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="">
//   
// </copyright>
// <summary>
//   The map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.DataStructures
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The map.
    /// </summary>
    /// <typeparam name="T1">
    /// </typeparam>
    /// <typeparam name="T2">
    /// </typeparam>
    public class Map<T1, T2> : IMap<T1, T2>
    {
        #region Fields

        /// <summary>
        /// The forward dictionary.
        /// </summary>
        private readonly Dictionary<T1, T2> forwardDictionary;

        /// <summary>
        /// The reverse dictionary.
        /// </summary>
        private readonly Dictionary<T2, T1> reverseDictionary;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Map{T1,T2}"/> class.
        /// </summary>
        public Map()
        {
            this.forwardDictionary = new Dictionary<T1, T2>();
            this.reverseDictionary = new Dictionary<T2, T1>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        public ICollection<T1> Keys
        {
            get
            {
                return this.forwardDictionary.Keys;
            }
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        public ICollection<T2> Values
        {
            get
            {
                return this.reverseDictionary.Keys;
            }
        }

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
        public bool ContainsKey(T1 t1)
        {
            return this.forwardDictionary.ContainsKey(t1);
        }

        /// <summary>
        /// The contains value.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ContainsValue(T2 t2)
        {
            return this.reverseDictionary.ContainsKey(t2);
        }

        /// <summary>
        /// The forward add.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        public void ForwardAdd(T1 t1, T2 t2)
        {
            this.AddItem(t1, t2);
        }

        /// <summary>
        /// The forward item.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <returns>
        /// The <see cref="T2"/>.
        /// </returns>
        public T2 ForwardItem(T1 t1)
        {
            return this.forwardDictionary[t1];
        }

        /// <summary>
        /// The forward remove.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        public void ForwardRemove(T1 t1)
        {
            T2 t2 = this.forwardDictionary[t1];
            this.forwardDictionary.Remove(t1);
            this.reverseDictionary.Remove(t2);
        }

        /// <summary>
        /// The reverse add.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        public void ReverseAdd(T2 t2, T1 t1)
        {
            this.AddItem(t1, t2);
        }

        /// <summary>
        /// The reverse item.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <returns>
        /// The <see cref="T1"/>.
        /// </returns>
        public T1 ReverseItem(T2 t2)
        {
            return this.reverseDictionary[t2];
        }

        /// <summary>
        /// The reverse remove.
        /// </summary>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        public void ReverseRemove(T2 t2)
        {
            T1 t1 = this.reverseDictionary[t2];
            this.forwardDictionary.Remove(t1);
            this.reverseDictionary.Remove(t2);
        }

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
        public bool TryForwardLookup(T1 t1, out T2 t2)
        {
            bool keyFound = this.forwardDictionary.ContainsKey(t1);

            t2 = keyFound ? this.forwardDictionary[t1] : default(T2);

            return keyFound;
        }

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
        public bool TryReverseLookup(T2 t2, out T1 t1)
        {
            bool keyFound = this.reverseDictionary.ContainsKey(t2);

            t1 = keyFound ? this.reverseDictionary[t2] : default(T1);

            return keyFound;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="t1">
        /// The t 1.
        /// </param>
        /// <param name="t2">
        /// The t 2.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        private void AddItem(T1 t1, T2 t2)
        {
            if (this.forwardDictionary.ContainsKey(t1))
            {
                throw new ArgumentException("Key already exists.");
            }

            if (this.reverseDictionary.ContainsKey(t2))
            {
                throw new ArgumentException("Value already exists.");
            }

            this.forwardDictionary.Add(t1, t2);
            this.reverseDictionary.Add(t2, t1);
        }

        #endregion
    }
}