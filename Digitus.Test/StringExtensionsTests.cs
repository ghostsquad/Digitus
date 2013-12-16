// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensionsTests.cs" company="">
//   
// </copyright>
// <summary>
//   The string extensions tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.Test
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
        ///     The picky replace given exclude expect inside untouched.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenExcludeExpectInsideUntouched()
        {
            // arrange
            const string Value = "aaa<aaa>aaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = "bbb<aaa>bbb";

            // act
            string actual = Value.PickyReplace(Search, Replacement, Start, End, PickyReplaceOptions.ExcludeBetween);

            // assert
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        ///     The picky replace given include expect outside untouched.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenIncludeExpectOutsideUntouched()
        {
            // arrange
            const string Value = "aaa<aaa>aaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = "aaa<bbb>aaa";

            // act
            string actual = Value.PickyReplace(Search, Replacement, Start, End, PickyReplaceOptions.IncludeBetween);

            // assert
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// The picky replace given no end exclude end not required expect all after start not applicable for replacement.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenNoEndExcludeEndNotRequiredExpectAllAfterStartNotApplicableForReplacement()
        {
            // arrange
            const string Value = "aaa<aaaaaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = "bbb<aaaaaa";

            // act
            string actual = Value.PickyReplace(
                Search, 
                Replacement, 
                Start, 
                End, 
                PickyReplaceOptions.ExcludeBetween | PickyReplaceOptions.EndNotRequired);

            // assert
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// The picky replace given no end exclude expect all applicable for replacement.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenNoEndExcludeExpectAllApplicableForReplacement()
        {
            // arrange
            const string Value = "aaa<aaaaaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = "bbb<bbbbbb";

            // act
            string actual = Value.PickyReplace(Search, Replacement, Start, End, PickyReplaceOptions.ExcludeBetween);

            // assert
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// The picky replace given no end include end not required expect all after start applicable for replacement.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenNoEndIncludeEndNotRequiredExpectAllAfterStartApplicableForReplacement()
        {
            // arrange
            const string Value = "aaa<aaaaaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = "aaa<bbbbbb";

            // act
            string actual = Value.PickyReplace(
                Search, 
                Replacement, 
                Start, 
                End, 
                PickyReplaceOptions.IncludeBetween | PickyReplaceOptions.EndNotRequired);

            // assert
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// The picky replace given no end include expect all applicable for replacement.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenNoEndIncludeExpectAllApplicableForReplacement()
        {
            // arrange
            const string Value = "aaa<aaaaaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = "aaa<aaaaaa";

            // act
            string actual = Value.PickyReplace(Search, Replacement, Start, End, PickyReplaceOptions.IncludeBetween);

            // assert
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        /// The picky replace given no start exclude expect nothing applicable for replacement.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenNoStartExcludeExpectNothingApplicableForReplacement()
        {
            // arrange
            const string Value = "aaaaaa>aaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = Value;

            // act
            string actual = Value.PickyReplace(Search, Replacement, Start, End, PickyReplaceOptions.ExcludeBetween);

            // assert
            Assert.AreEqual(Expected, actual);
        }

        /// <summary>
        ///     The picky replace given no start include expect nothing applicable for replacement.
        /// </summary>
        [TestMethod]
        public void PickyReplaceGivenNoStartIncludeExpectNothingApplicableForReplacement()
        {
            // arrange
            const string Value = "aaaaaa>aaa";
            const char Search = 'a';
            const char Replacement = 'b';
            const char Start = '<';
            const char End = '>';
            const string Expected = Value;

            // act
            string actual = Value.PickyReplace(Search, Replacement, Start, End, PickyReplaceOptions.IncludeBetween);

            // assert
            Assert.AreEqual(Expected, actual);
        }

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
        /// The wrap given many spaces and new line expect no wrap.
        /// </summary>
        [TestMethod]
        public void WrapGivenManySpacesAndNewLineExpectNoWrap()
        {
            // arrange
            var expectedPart = new string(' ', 3);
            string expected = expectedPart + Environment.NewLine;
            string value = expected + expectedPart;
            const int MaxLineLength = 3;

            // act
            string actual = value.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(expected, actual);
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
        /// The wrap given many spaces expect wrap in middle.
        /// </summary>
        [TestMethod]
        public void WrapGivenManySpacesExpectWrapInMiddle()
        {
            // arrange
            var value = new string(' ', 7);
            string expected = new string(' ', 3) + Environment.NewLine;
            const int MaxLineLength = 3;

            // act
            string actual = value.Wrap(MaxLineLength);

            // assert
            Assert.AreEqual(expected, actual);
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

        #endregion
    }
}