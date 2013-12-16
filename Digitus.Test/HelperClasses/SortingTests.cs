// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortingTests.cs" company="">
//   
// </copyright>
// <summary>
//   The sorting tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.Test.HelperClasses
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Digitus.HelperClasses;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The sorting tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SortingTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The given empty list when is sorted expect true.
        /// </summary>
        [TestMethod]
        public void GivenEmptyListWhenIsSortedExpectTrue()
        {
            var emptyList = new List<int>();
            Assert.IsTrue(emptyList.IsSorted());
        }

        /// <summary>
        /// The given sorted list when is sorted expect true.
        /// </summary>
        [TestMethod]
        public void GivenSortedListWhenIsSortedExpectTrue()
        {
            var sortedList = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                sortedList.Add(i);
            }

            Assert.IsTrue(sortedList.IsSorted());
        }

        /// <summary>
        /// The given un sorted list when is sorted expect false.
        /// </summary>
        [TestMethod]
        public void GivenUnSortedListWhenIsSortedExpectFalse()
        {
            var unSortedList = new List<int>();
            for (int i = 3; i >= 0; i--)
            {
                unSortedList.Add(i);
            }

            Assert.IsFalse(unSortedList.IsSorted());
        }

        #endregion
    }
}