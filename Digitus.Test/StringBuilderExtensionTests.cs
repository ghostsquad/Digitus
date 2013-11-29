namespace digitus.test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    using Digitus;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ploeh.AutoFixture;

    /// <summary>
    /// The string builder extension tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StringBuilderExtensionTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The append collection function delegate.
        /// </summary>
        [TestMethod]
        public void AppendCollectionFunctionDelegate()
        {
            // arrange
            var fixture = new Fixture();
            IEnumerable<string> collection = fixture.CreateMany<string>();
            var expected = new StringBuilder();
            var sb = new StringBuilder();

            // ReSharper disable PossibleMultipleEnumeration
            foreach (string x in collection)
            {
                expected.Append(x.ToUpper());
            }

            // act
            string actual = sb.AppendCollection(collection, s => s.ToUpper()).ToString();

            // ReSharper restore PossibleMultipleEnumeration

            // assert
            Assert.AreEqual(expected.ToString(), actual);
        }

        /// <summary>
        /// The append collection given collection to append expect appended.
        /// </summary>
        [TestMethod]
        public void AppendCollectionGivenCollectionToAppendExpectAppended()
        {
            // arrange
            var fixture = new Fixture();
            IEnumerable<string> collection = fixture.CreateMany<string>();

            // ReSharper disable PossibleMultipleEnumeration          
            string expected = string.Concat(collection);
            var sb = new StringBuilder();

            // act
            string actual = sb.AppendCollection(collection).ToString();

            // ReSharper restore PossibleMultipleEnumeration

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// The append collection given empty collection expect empty string.
        /// </summary>
        [TestMethod]
        public void AppendCollectionGivenEmptyCollectionExpectEmptyString()
        {
            // arrange
            var collection = new List<string>();
            var sb = new StringBuilder();

            // act
            string actual = sb.AppendCollection(collection).ToString();

            // assert
            Assert.AreEqual(string.Empty, actual);
        }

        /// <summary>
        /// The prepend given string expect new line before string.
        /// </summary>
        [TestMethod]
        public void PrependGivenStringExpectNewLineBeforeString()
        {
            // arrange
            var fixture = new Fixture();
            var value = fixture.Create<string>();
            string expected = Environment.NewLine + value;
            var sb = new StringBuilder();

            // act
            string actual = sb.PrependLine(value).ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}