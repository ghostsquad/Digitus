// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoxStyleBuilderTests.cs" company="">
//   
// </copyright>
// <summary>
//   The box decorator tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.Test.PlainTextStyling
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Digitus.PlainTextStyling;
    using Digitus.PlainTextStyling.Components;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    /// <summary>
    ///     The box decorator tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BoxStyleBuilderTests
    {
        #region Fields

        /// <summary>
        ///     The random.
        /// </summary>
        private readonly Random random = new Random();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The given all borders and single line string.
        /// </summary>
        [TestMethod]
        public void GivenAllBordersAndSingleLineString()
        {
            // arrange
            var fixture = new Fixture();
            var borders = fixture.Create<Borders>();
            var value = fixture.Create<string>();
            var expectedBuilder = new StringBuilder();

            expectedBuilder.AppendLine(new string(borders.Top.Char, borders.Top.Size));
            expectedBuilder.Append(borders.Left.Char.ToString(CultureInfo.InvariantCulture))
                .Append(value)
                .AppendLine(borders.Right.Char.ToString(CultureInfo.InvariantCulture));
            expectedBuilder.Append(new string(borders.Bottom.Char, borders.Bottom.Size));

            // act
            string actual = new BoxStyleBuilder(value).WithBorders(borders).ToString();

            // assert
            Assert.AreEqual(expectedBuilder.ToString(), actual);
        }

        /// <summary>
        ///     The given padding.
        /// </summary>
        [TestMethod]
        public void GivenBoxSpacing()
        {
            // arrange
            var fixture = new Fixture();
            var value = fixture.Create<string>();
            var expectedSb = new StringBuilder();
            var topBottomPadding = new string(' ', value.Length + 2);
            expectedSb.AppendLine(topBottomPadding)
                .Append(' ')
                .Append(value)
                .Append(' ')
                .AppendLineBefore(topBottomPadding);
            string expected = expectedSb.ToString();

            // act
            string actual =
                new BoxStyleBuilder(value).WithPadding(new BoxSpacing { Top = 1, Bottom = 1, Left = 1, Right = 1 })
                    .ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     The given multi line string when add padding expect even left right padding with spaces.
        /// </summary>
        [TestMethod]
        public void GivenMultiLineStringWhenAddBoxSpacingExpectEvenLeftRightPaddingWithSpaces()
        {
            // arrange
            var fixture = new Fixture();
            var valueList = new List<string>();
            fixture.AddManyTo(valueList, this.GetRandomLengthString);
            string value = string.Join(Environment.NewLine, valueList);
            var boxSpacing = fixture.Create<BoxSpacing>();

            string expected;
            this.SetupBoxSpacing(fixture, valueList, boxSpacing, out expected);

            // act
            string actualWithPadding = new BoxStyleBuilder(value).WithPadding(boxSpacing).ToString();
            string actualWithMargins = new BoxStyleBuilder(value).WithMargins(boxSpacing).ToString();

            // assert
            Assert.AreEqual(expected, actualWithPadding);
            Assert.AreEqual(expected, actualWithMargins);
        }

        /// <summary>
        ///     The given negative border length expect top bottom same size as string plus left right.
        /// </summary>
        [TestMethod]
        public void GivenNegativeBorderLengthExpectTopBottomSameSizeAsStringPlusLeftRight()
        {
            // arrange
            var fixture = new Fixture();
            var fullLengthBorder = new Border(fixture.Create<char>(), -1);
            var borders = new Borders { Top = fullLengthBorder, Bottom = fullLengthBorder };

            var value = fixture.Create<string>();

            var expectedTopBorder = new string(borders.Top.Char, value.Length);
            var expectedBottomBorder = new string(borders.Bottom.Char, value.Length);

            // act
            string actual = new BoxStyleBuilder(value).WithBorders(borders).ToString();
            string[] actualLines = actual.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string actualTopBorder = actualLines[actualLines.GetLowerBound(0)];
            string actualBottomBorder = actualLines[actualLines.GetUpperBound(0)];

            // assert
            Assert.AreEqual(expectedTopBorder, actualTopBorder);
            Assert.AreEqual(expectedBottomBorder, actualBottomBorder);
        }

        /// <summary>
        ///     The given null borders expect no change.
        /// </summary>
        [TestMethod]
        public void GivenNullBordersExpectNoChange()
        {
            // arrange
            var fixture = new Fixture();
            var expected = fixture.Create<string>();

            // act
            string actual = new BoxStyleBuilder(expected).ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     The given padding expect add box spacing called.
        /// </summary>
        [TestMethod]
        public void GivenPaddingExpectAddBoxSpacingCalled()
        {
            // arrange
            var fixture = new Fixture();
            var builderMock = new Mock<BoxStyleBuilder> { CallBase = true };
            var boxSpacing = fixture.Create<BoxSpacing>();

            // act
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The get random length string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        private string GetRandomLengthString()
        {
            return this.RandomString(this.random.Next(5, 30));
        }

        /// <summary>
        /// The random string.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string RandomString(int size)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor((26 * this.random.NextDouble()) + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        /// <summary>
        /// The setup box spacing.
        /// </summary>
        /// <param name="fixture">
        /// The fixture.
        /// </param>
        /// <param name="valueList">
        /// The value list.
        /// </param>
        /// <param name="boxSpacing">
        /// The box spacing.
        /// </param>
        /// <param name="expected">
        /// The expected.
        /// </param>
        private void SetupBoxSpacing(
            Fixture fixture, 
            IList<string> valueList, 
            BoxSpacing boxSpacing, 
            out string expected)
        {
            boxSpacing.Top = 0;
            boxSpacing.Bottom = 0;
            int maxValueLength = valueList.Select(x => x.Length).Max();
            var expectedSb = new StringBuilder();
            for (int i = 0; i < valueList.Count; i++)
            {
                valueList[i] = valueList[i].PadLeft(valueList[i].Length + boxSpacing.Left);
                valueList[i] = valueList[i].PadRight(maxValueLength + boxSpacing.Left + boxSpacing.Right);
                expectedSb.Append(valueList[i]);

                if (i + 1 < valueList.Count)
                {
                    expectedSb.AppendLine();
                }
            }

            expected = expectedSb.ToString();
        }

        #endregion
    }
}