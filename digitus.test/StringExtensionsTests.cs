namespace digitus.test
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     The string extensions tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StringExtensionsTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The wrap_ given long wrap length_ expect minimal splitting.
        /// </summary>
        [TestMethod]
        public void Wrap_GivenLongWrapLength_ExpectMinimalSplitting()
        {
            // arrange
            string startString = "the quick brown fox jumped over the lazy dog.";
            int maxLineLength = 10;
            string expectedString = string.Format(
                "the quick{0}brown fox{0}jumped{0}over the{0}lazy dog.", 
                Environment.NewLine);

            // act
            string actualString = startString.Wrap(maxLineLength);

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given possibility to split mid word_ expect split before.
        /// </summary>
        [TestMethod]
        public void Wrap_GivenPossibilityToSplitMidWord_ExpectSplitBefore()
        {
            // arrange
            string startString = "say hello to my little friend";
            int maxLineLength = 4;
            string expectedString = startString.Replace(" ", Environment.NewLine);

            // act
            string actualString = startString.Wrap(maxLineLength);

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given string to wrap_ expect two lines.
        /// </summary>
        [TestMethod]
        public void Wrap_GivenStringToWrap_ExpectTwoLines()
        {
            // arrange
            string startString = "hello world";
            int maxLineLength = 5;
            string expectedString = startString.Replace(" ", Environment.NewLine);

            // act
            string actualString = startString.Wrap(maxLineLength);

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given unevenly wrappable string_ expect split at minimum.
        /// </summary>
        [TestMethod]
        public void Wrap_GivenUnevenlyWrappableString_ExpectSplitAtMinimum()
        {
            // arrange
            string startString = "say hello to my little friend";
            int maxLineLength = 6;
            string expectedString = "say\r\nhello\r\nto my\r\nlittle\r\nfriend";

            // act
            string actualString = startString.Wrap(maxLineLength);

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given unwrappable string_ expect one line.
        /// </summary>
        [TestMethod]
        public void Wrap_GivenUnwrappableString_ExpectOneLine()
        {
            // arrange
            string startString = "helloworld";
            int maxLineLength = 5;

            // act
            string actualString = startString.Wrap(maxLineLength);

            // assert
            Assert.AreEqual(startString, actualString);
        }

        #endregion
    }
}