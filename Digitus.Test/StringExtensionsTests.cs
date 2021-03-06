﻿namespace Digitus.Test
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ploeh.AutoFixture;

    /// <summary>
    ///     The string extensions tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StringExtensionsTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Given a null string,
        ///     When "WithNewLine()" invoked,
        ///     Expected null return.
        /// </summary>
        [TestMethod]
        public void WithNewLineGivenNullStringExpectNullReturn()
        {
            // arrange
            string startString = null;

            // act
            // ReSharper disable ExpressionIsAlwaysNull
            // This test is to validate that null stays null
            string actualString = startString.WithNewLine();

            // ReSharper restore ExpressionIsAlwaysNull

            // assert
            Assert.IsNull(actualString);
        }

        /// <summary>
        ///     Given random string,
        ///     When "WithNewLine()" invoked,
        ///     Expect New Line Appended.
        /// </summary>
        [TestMethod]
        public void WithNewLineGivenStringExpectNewLineAppended()
        {
            // arrange
            var fixture = new Fixture();
            var startString = fixture.Create<string>();
            string expectedString = startString + Environment.NewLine;

            // act
            string actualString = startString.WithNewLine();

            // assert
            Assert.AreEqual(expectedString, actualString);
        }

        /// <summary>
        ///     Given multiple words before required wrap,
        ///     When "Wrap()" invoked,
        ///     Expect minimal splitting.
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
        ///     Given a string with multiple consecutive spaces,
        ///     When "Wrap()" invoked,
        ///     Expect TrimLeft() after NewLine.
        /// </summary>
        [TestMethod]
        public void WrapGivenManySpacesExpectTrimLeftOnNewLine()
        {
            // arrange
            // to make it easier to count the spaces (replacing spaces with + (plus))
            // ----------------------->"this+is++++my+sentence++++w/+more+++spaces."
            const string StartString = "this is    my sentence    w/ more   spaces.";
            const int MaxLineLength = 8;
            const string ExpectedString = "this is \r\nmy\r\nsentence\r\nw/ more \r\nspaces.";

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(ExpectedString, actualString);
        }

        /// <summary>
        ///     Given a string with a NewLine between many spaces,
        ///     When "Wrap()" invoked,
        ///     Expect TrimLeft() after NewLine.
        /// </summary>
        [TestMethod]
        public void WrapGivenNewLineBetweenManySpacesExpectTrimLeftAfterNewline()
        {
            // arrange
            // to make it easier to count the spaces (replacing spaces with + (plus))
            // ----------------------->"hello++\r\n++world"
            const string StartString = "hello  \r\n  world";
            const int MaxLineLength = 7;
            const string ExpectedString = "hello  \r\nworld";

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(ExpectedString, actualString);
        }

        /// <summary>
        ///     Given a string with NewLine instead of Space (between words),
        ///     When "Wrap()" invoked,
        ///     Expected NewLine to be detected, and Wrap reset when found.
        /// </summary>
        [TestMethod]
        public void WrapGivenNewLineMidStringExpectWrapResetAfterNewLine()
        {
            // arrange
            const string StartString = "houston we\r\nhave a newline";
            const int MaxLineLength = 10;
            const string ExpectedString = "houston we\r\nhave a\r\nnewline";

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(ExpectedString, actualString);
        }

        /// <summary>
        ///     Given max line length that is shorter than shortest word,
        ///     When "Wrap()" invoked,
        ///     Expect NewLine before every word.
        /// </summary>
        [TestMethod]
        public void WrapGivenShortMaxLineLengthExpectWordsNotSplit()
        {
            // arrange
            const string StartString = "hello world stuff things";
            const int MaxLineLength = 4;
            const string ExpectedString = "hello\r\nworld\r\nstuff\r\nthings";

            // act
            string actualString = StartString.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(ExpectedString, actualString);
        }

        /// <summary>
        ///     Given an unwrappable string,
        ///     When "Wrap()" invoked,
        ///     Expect single line
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

        /// <summary>
        ///     Given perfectly wrappable string,
        ///     When "Wrap()" invoked,
        ///     Expect 2 lines, no spaces.
        /// </summary>
        [TestMethod]
        public void WrapGivenWrappableStringExpectTwoLines()
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

        [TestMethod]
        public void WrapGivenManySpacesExpectWrapInMiddle()
        {
            // arrange
            var value = new string(' ', 7);           
            var expected = new string(' ', 3) + Environment.NewLine;
            const int MaxLineLength = 3;

            // act
            var actual = value.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WrapGivenManySpacesAndNewLineExpectNoWrap()
        {
            // arrange
            var expectedPart = new string(' ', 3);
            var expected = expectedPart + Environment.NewLine;
            var value = expected + expectedPart;
            const int MaxLineLength = 3;

            // act
            var actual = value.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}