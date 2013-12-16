// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriorityQueueTests.cs" company="">
//   
// </copyright>
// <summary>
//   The priority queue tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.Test.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using Digitus.DataStructures;
    using Digitus.HelperClasses;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;

    /// <summary>
    /// The priority queue tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PriorityQueueTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The given default priority when dequeue expect correct order.
        /// </summary>
        [TestMethod]
        public void GivenDefaultPriorityWhenDequeueExpectCorrectOrder()
        {
            // arrange
            var fixture = new Fixture();
            const byte DefaultPriority = 2;
            var priorityQueue = new PriorityQueue<string>(DefaultPriority);
            var defaultPriEnqueue = fixture.Create<string>();
            var higherPriorityEnqueue = fixture.Create<string>();
            priorityQueue.Enqueue(defaultPriEnqueue);
            priorityQueue.Enqueue(0, higherPriorityEnqueue);

            // act
            string dequeue1 = priorityQueue.Dequeue();
            string dequeue2 = priorityQueue.Dequeue();

            // assert
            Assert.AreEqual(DefaultPriority, priorityQueue.DefaultPriority);
            Assert.AreSame(higherPriorityEnqueue, dequeue1);
            Assert.AreSame(defaultPriEnqueue, dequeue2);
        }

        /// <summary>
        /// The given empty queue when dequeue expect exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GivenEmptyQueueWhenDequeueExpectException()
        {
            // arrange
            var priorityQueue = new PriorityQueue<object>();

            // act
            priorityQueue.Dequeue();
        }

        /// <summary>
        /// The given empty queue when get enumerator expect null on first next.
        /// </summary>
        [TestMethod]
        public void GivenEmptyQueueWhenGetEnumeratorExpectNullOnFirstNext()
        {
            var priorityQueue = new PriorityQueue<object>();
            IEnumerator theEnumerator = priorityQueue.GetEnumerator();
            Assert.IsFalse(theEnumerator.MoveNext());
        }

        /// <summary>
        /// The given empty queue when peek expect exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GivenEmptyQueueWhenPeekExpectException()
        {
            // arrange
            var priorityQueue = new PriorityQueue<object>();

            // act
            priorityQueue.Peek();
        }

        /// <summary>
        /// The given enqueue dequeue when count expect number of objects.
        /// </summary>
        [TestMethod]
        public void GivenEnqueueDequeueWhenCountExpectNumberOfObjects()
        {
            // enqueue count test
            // arrange
            var fixture = new Fixture();
            var priorityQueue = new PriorityQueue<string>();
            var objectToEnqueue = fixture.Create<string>();
            priorityQueue.Enqueue(objectToEnqueue);

            // act
            int queueCount = priorityQueue.Count;

            // assert
            Assert.AreEqual(1, queueCount);

            // dequeue count test
            // act
            string dequeuedObject = priorityQueue.Dequeue();
            queueCount = priorityQueue.Count;

            // assert
            Assert.AreEqual(0, queueCount);
            Assert.AreSame(objectToEnqueue, dequeuedObject);
        }

        /// <summary>
        /// The given high index not enough room when copy to expect argument exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenHighIndexNotEnoughRoomWhenCopyToExpectArgumentException()
        {
            var fixture = new Fixture();
            var priorityQueue = new PriorityQueue<object>();
            IEnumerable<string> stringsToEnqueue = fixture.CreateMany<string>();
            int stringCount = 0;
            foreach (string fixtureString in stringsToEnqueue)
            {
                stringCount++;
                priorityQueue.Enqueue(fixtureString);
            }

            var theArray = new object[stringCount];
            priorityQueue.CopyTo(theArray, 1);
        }

        /// <summary>
        /// The given larger destination array when copy to expect success.
        /// </summary>
        [TestMethod]
        public void GivenLargerDestinationArrayWhenCopyToExpectSuccess()
        {
            var fixture = new Fixture();
            var priorityQueue = new PriorityQueue<string>();
            priorityQueue.Enqueue(fixture.Create<string>());
            var theArray = new string[2];
            priorityQueue.CopyTo(theArray, 0);
        }

        /// <summary>
        /// The given negative index when copy to argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GivenNegativeIndexWhenCopyToArgumentOutOfRangeException()
        {
            var priorityQueue = new PriorityQueue<object>();
            var theArray = new object[0];
            priorityQueue.CopyTo(theArray, -1);
        }

        /// <summary>
        /// The given new when count expect zero.
        /// </summary>
        [TestMethod]
        public void GivenNewWhenCountExpectZero()
        {
            // arrange
            var priorityQueue = new PriorityQueue<object>();

            // act
            int queueCount = priorityQueue.Count;

            // assert
            Assert.AreEqual(0, queueCount);
        }

        /// <summary>
        /// The given non prioritized enqueues when dequeued expect enqueue order.
        /// </summary>
        [TestMethod]
        public void GivenNonPrioritizedEnqueuesWhenDequeuedExpectEnqueueOrder()
        {
            // arrange
            var fixture = new Fixture();
            var priorityQueue = new PriorityQueue<string>();
            var obj1 = fixture.Create<string>();
            var obj2 = fixture.Create<string>();
            priorityQueue.Enqueue(obj1);
            priorityQueue.Enqueue(obj2);

            // act
            object dequeue1 = priorityQueue.Dequeue();
            object dequeue2 = priorityQueue.Dequeue();

            // assert
            Assert.AreSame(obj1, dequeue1);
            Assert.AreSame(obj2, dequeue2);
        }

        /// <summary>
        /// The given null array when copy to argument null exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullArrayWhenCopyToArgumentNullException()
        {
            var priorityQueue = new PriorityQueue<object>();
            priorityQueue.CopyTo(null, 0);
        }

        /// <summary>
        /// The given prioritized enqueues when dequeued expect ordered by priority.
        /// </summary>
        [TestMethod]
        public void GivenPrioritizedEnqueuesWhenDequeuedExpectOrderedByPriority()
        {
            // arrange
            var fixture = new Fixture();
            var priorityQueue = new PriorityQueue<string>();
            List<Tuple<byte, string>> orderedPriorityTuples;
            EnqueuePrioritizedObjects(priorityQueue, fixture, out orderedPriorityTuples);

            // assert that the objects are dequeue in the order
            foreach (var sortedObject in orderedPriorityTuples)
            {
                object theDequeued = priorityQueue.Dequeue();
                Assert.AreSame(sortedObject.Item2, theDequeued);
            }
        }

        /// <summary>
        /// The given prioritized enqueues when peek expect ordered by priority.
        /// </summary>
        [TestMethod]
        public void GivenPrioritizedEnqueuesWhenPeekExpectOrderedByPriority()
        {
            // arrange
            var fixture = new Fixture();
            var priorityQueue = new PriorityQueue<string>();
            List<Tuple<byte, string>> orderedPriorityTuples;
            EnqueuePrioritizedObjects(priorityQueue, fixture, out orderedPriorityTuples);

            Assert.AreSame(orderedPriorityTuples[0].Item2, priorityQueue.Peek());
        }

        /// <summary>
        /// The given prioritized queue when get enumerator expect correct order.
        /// </summary>
        [TestMethod]
        public void GivenPrioritizedQueueWhenGetEnumeratorExpectCorrectOrder()
        {
            // arrange
            var fixture = new Fixture();
            var priorityQueue = new PriorityQueue<string>();
            List<Tuple<byte, string>> orderedPriorityTuples;
            EnqueuePrioritizedObjects(priorityQueue, fixture, out orderedPriorityTuples);
            IEnumerator theEnumerator = priorityQueue.GetEnumerator();

            // assert that the objects are dequeue in the order
            int objectIndex = 0;
            while (theEnumerator.MoveNext())
            {
                Assert.AreSame(orderedPriorityTuples[objectIndex].Item2, theEnumerator.Current);
                objectIndex++;
            }

            Assert.AreEqual(objectIndex, orderedPriorityTuples.Count);
        }

        /// <summary>
        /// The given same size destination array when copy to expect success.
        /// </summary>
        [TestMethod]
        public void GivenSameSizeDestinationArrayWhenCopyToExpectSuccess()
        {
            var priorityQueue = new PriorityQueue<object>();
            priorityQueue.Enqueue(new object());
            var theArray = new object[1];
            priorityQueue.CopyTo(theArray, 0);
        }

        /// <summary>
        /// The given smaller destination array when copy to argument exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenSmallerDestinationArrayWhenCopyToArgumentException()
        {
            var priorityQueue = new PriorityQueue<object>();
            priorityQueue.Enqueue(new object());
            var theArray = new object[0];
            priorityQueue.CopyTo(theArray, 0);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The enqueue prioritized objects.
        /// </summary>
        /// <param name="priorityQueue">
        /// The priority queue.
        /// </param>
        /// <param name="fixture">
        /// The fixture.
        /// </param>
        /// <param name="priorityTuples">
        /// The priority tuples.
        /// </param>
        private static void EnqueuePrioritizedObjects(
            IPriorityQueue<string> priorityQueue, 
            ISpecimenBuilder fixture, 
            out List<Tuple<byte, string>> priorityTuples)
        {
            priorityTuples = fixture.CreateMany<Tuple<byte, string>>().ToList();

            // first lets shuffle them up 
            while (priorityTuples.ToList().IsSorted())
            {
                priorityTuples.Sort((tuple, tuple1) => Guid.NewGuid().CompareTo(Guid.NewGuid()));
            }

            // add to the priority queue in a shuffled state
            foreach (var tuple in priorityTuples)
            {
                priorityQueue.Enqueue(tuple.Item1, tuple.Item2);
            }

            // sort the objects
            priorityTuples.Sort((tuple, tuple1) => tuple.Item1.CompareTo(tuple1.Item1));
        }

        #endregion
    }
}