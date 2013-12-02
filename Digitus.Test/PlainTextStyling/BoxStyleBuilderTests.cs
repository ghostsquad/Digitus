namespace Digitus.Test.PlainTextStyling
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Digitus.PlainTextStyling;
    using Digitus.PlainTextStyling.Components;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ploeh.AutoFixture;

    using Ploeh.AutoFixture.AutoMoq;

    /// <summary>
    /// The box decorator tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BoxStyleBuilderTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The given all borders and single line string.
        /// </summary>
        [TestMethod]
        public void GivenAllBordersAndSingleLineString()
        {
            // arrange
            var fixture = new Fixture();
            var borders = fixture.Create<Borders>();
            var stringToStylize = fixture.Create<string>();
            var expectedBuilder = new StringBuilder();

            expectedBuilder.AppendLine(new string(borders.Top.Char, borders.Top.Size));
            expectedBuilder.Append(borders.Left.Char.ToString(CultureInfo.InvariantCulture))
                .Append(stringToStylize)
                .AppendLine(borders.Right.Char.ToString(CultureInfo.InvariantCulture));
            expectedBuilder.Append(new string(borders.Bottom.Char, borders.Bottom.Size));

            // act
            var actual = new BoxStyleBuilder(stringToStylize).WithBorders(borders).ToString();

            // assert
            Assert.AreEqual(expectedBuilder.ToString(), actual);
        }

        [TestMethod]
        public void GivenNegativeBorderLengthExpectTopBottomSameSizeAsStringPlusLeftRight()
        {
            // arrange
            var fixture = new Fixture();                        
            var fullLengthBorder = new Border(fixture.Create<char>(), -1);
            var borders = new Borders
                              {
                                  Top = fullLengthBorder,
                                  Bottom = fullLengthBorder
                              };

            var stringToStylize = fixture.Create<string>();

            var expectedTopBorder = new string(borders.Top.Char, stringToStylize.Length);
            var expectedBottomBorder = new string(borders.Bottom.Char, stringToStylize.Length);
            
            // act
            var actual = new BoxStyleBuilder(stringToStylize).WithBorders(borders).ToString();
            var actualLines = actual.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var actualTopBorder = actualLines[actualLines.GetLowerBound(0)];
            var actualBottomBorder = actualLines[actualLines.GetUpperBound(0)];

            // assert
            Assert.AreEqual(expectedTopBorder, actualTopBorder);
            Assert.AreEqual(expectedBottomBorder, actualBottomBorder);
        }

        #endregion
    }
}