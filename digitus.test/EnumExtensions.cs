namespace digitus.test
{
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The enum extensions.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EnumExtensions
    {
        #region Constants

        /// <summary>
        /// The expected display name.
        /// </summary>
        private const string ExpectedDisplayName = "My A";

        #endregion

        #region Enums

        /// <summary>
        /// The my test enum.
        /// </summary>
        private enum MyTestEnum
        {
            /// <summary>
            /// The a.
            /// </summary>
            [EnumDisplayName(ExpectedDisplayName)]
            A, 

            /// <summary>
            /// The b.
            /// </summary>
            B
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The display name_ given display name_ return expected.
        /// </summary>
        [TestMethod]
        public void DisplayNameGivenDisplayNameReturnExpected()
        {
            // act
            string actualDisplayName = MyTestEnum.A.GetDisplayName();

            // assert
            Assert.AreEqual(ExpectedDisplayName, actualDisplayName);
        }

        /// <summary>
        /// The display name_ given no display name_ return enum to string.
        /// </summary>
        [TestMethod]
        public void DisplayNameGivenNoDisplayNameReturnEnumToString()
        {
            // arrange
            string expectedDisplayName = "B";

            // act
            string actualDisplayName = MyTestEnum.B.GetDisplayName();

            // assert
            Assert.AreEqual(expectedDisplayName, actualDisplayName);
        }

        #endregion
    }
}