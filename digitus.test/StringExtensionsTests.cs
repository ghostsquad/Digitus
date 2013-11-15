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
        public void WrapGivenLongWrapLengthExpectMinimalSplitting()
        {
            // arrange
            const string StartString = "the quick brown fox jumped over the lazy dog.";
            const int MaxLineLength = 10;
            string expectedString = string.Format(
                "the quick{0}brown fox{0}jumped{0}over the{0}lazy dog.", 
                Environment.NewLine);

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given possibility to split mid word_ expect split before.
        /// </summary>
        [TestMethod]
        public void WrapGivenPossibilityToSplitMidWordExpectSplitBefore()
        {
            // arrange
            const string StartString = "say hello to my little friend";
            const int MaxLineLength = 4;
            string expectedString = StartString.Replace(" ", Environment.NewLine);

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given string to wrap_ expect two lines.
        /// </summary>
        [TestMethod]
        public void WrapGivenStringToWrapExpectTwoLines()
        {
            // arrange
            const string StartString = "hello world";
            const int MaxLineLength = 5;
            string expectedString = StartString.Replace(" ", Environment.NewLine);

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given unevenly wrappable string_ expect split at minimum.
        /// </summary>
        [TestMethod]
        public void WrapGivenUnevenlyWrappableStringExpectSplitAtMinimum()
        {
            // arrange
            const string StartString = "say hello to my little friend";
            const int MaxLineLength = 6;
            const string ExpectedString = "say\r\nhello\r\nto my\r\nlittle\r\nfriend";

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(ExpectedString, actualString);
        }

        /// <summary>
        ///     The wrap_ given unwrappable string_ expect one line.
        /// </summary>
        [TestMethod]
        public void WrapGivenUnwrappableStringExpectOneLine()
        {
            // arrange
            const string StartString = "helloworld";
            const int MaxLineLength = 5;

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(StartString, actualString);
        }

        #endregion
    }
}