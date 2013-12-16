// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BordersTests.cs" company="">
//   
// </copyright>
// <summary>
//   The borders builder tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.Test.PlainTextStyling
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using Digitus.PlainTextStyling.Components;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ploeh.AutoFixture;

    /// <summary>
    ///     The borders builder tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BordersTests
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The given borders expect correct placement.
        /// </summary>
        [TestMethod]
        public void GivenBorderBuilderExpectCorrectPlacement()
        {
            var fixture = new Fixture();

            foreach (FourSidedSide side in (FourSidedSide[])Enum.GetValues(typeof(FourSidedSide)))
            {
                AssertBorderBuilderSide(side, fixture.Create<Border>());
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The assert border.
        /// </summary>
        /// <param name="borders">
        /// The borders.
        /// </param>
        /// <param name="side">
        /// The side.
        /// </param>
        /// <param name="expectedBorder">
        /// The expected border.
        /// </param>
        private static void AssertBorder(Borders borders, FourSidedSide side, Border expectedBorder)
        {
            PropertyInfo propertyInfo = typeof(Borders).GetProperty(side.ToString());
            var actualBorder = (Border)propertyInfo.GetGetMethod().Invoke(borders, null);

            Assert.AreEqual(expectedBorder.Char, actualBorder.Char);
            Assert.AreEqual(expectedBorder.Size, actualBorder.Size);
        }

        /// <summary>
        /// The assert border.
        /// </summary>
        /// <param name="side">
        /// The side.
        /// </param>
        /// <param name="expectedBorder">
        /// The expected border.
        /// </param>
        private static void AssertBorderBuilderSide(FourSidedSide side, Border expectedBorder)
        {
            var bordersBuilder = new BordersBuilder();
            string methodName = "With" + side + "Border";

            MethodInfo methodTakesBorder = typeof(BordersBuilder).GetMethod(methodName, new[] { typeof(Border) });
            MethodInfo methodTakesBorderParts = typeof(BordersBuilder).GetMethod(
                methodName, 
                new[] { typeof(char), typeof(int) });

            var builderResultFromBorder =
                (BordersBuilder)methodTakesBorder.Invoke(bordersBuilder, new object[] { expectedBorder });
            var builderResultFromParts =
                (BordersBuilder)
                methodTakesBorderParts.Invoke(bordersBuilder, new object[] { expectedBorder.Char, expectedBorder.Size });

            AssertBorder(builderResultFromBorder.ToBorders(), side, expectedBorder);
            AssertBorder(builderResultFromParts.ToBorders(), side, expectedBorder);
        }

        #endregion
    }
}