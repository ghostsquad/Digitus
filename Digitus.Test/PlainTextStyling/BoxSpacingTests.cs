namespace Digitus.Test.PlainTextStyling
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Digitus.PlainTextStyling.Components;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ploeh.AutoFixture;

    /// <summary>
    ///     The box spacing tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BoxSpacingTests
    {
        #region Public Methods and Operators

        /// <summary>
        /// The given box spacing builder expect correct placement.
        /// </summary>
        [TestMethod]
        public void GivenBoxSpacingBuilderExpectCorrectPlacement()
        {
            var fixture = new Fixture();

            foreach (var side in (FourSidedSide[])Enum.GetValues(typeof(FourSidedSide)))
            {
                AssertBoxSpacingBuilderSide(side, fixture.Create<int>());
            }
        }      

        #endregion

        #region Methods

        /// <summary>
        /// The assert border.
        /// </summary>
        /// <param name="boxSpacing">
        /// The box spacing.
        /// </param>
        /// <param name="side">
        /// The side.
        /// </param>
        /// <param name="expectedSpacing">
        /// The expected spacing.
        /// </param>
        private static void AssertBoxSpacingSide(BoxSpacing boxSpacing, FourSidedSide side, int expectedSpacing)
        {
            var propertyInfo = typeof(BoxSpacing).GetProperty(side.ToString());
            var actualSpacing = (int)propertyInfo.GetGetMethod().Invoke(boxSpacing, null);

            Assert.AreEqual(expectedSpacing, actualSpacing);
        }

        /// <summary>
        /// The assert box spacing builder side.
        /// </summary>
        /// <param name="side">
        /// The side.
        /// </param>
        /// <param name="expectedSpacing">
        /// The expected spacing.
        /// </param>
        private static void AssertBoxSpacingBuilderSide(FourSidedSide side, int expectedSpacing)
        {
            var boxSpacingBuilder = new BoxSpacingBuilder();
            var methodName = "With" + side + "Spacing";

            var methodInfo = typeof(BoxSpacingBuilder).GetMethod(methodName);

            var builderResult = (BoxSpacingBuilder)methodInfo.Invoke(boxSpacingBuilder, new object[] { expectedSpacing });

            AssertBoxSpacingSide(builderResult.ToBoxSpacing(), side, expectedSpacing);
        }

        #endregion
    }
}