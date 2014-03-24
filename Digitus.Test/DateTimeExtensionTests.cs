namespace Digitus.Test
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;

    /// <summary>
    /// The date time extension tests.
    /// </summary>
    [TestClass]
    public class DateTimeExtensionTests
    {        
        #region Public Methods and Operators

        /// <summary>
        /// The given local time expect utc time.
        /// </summary>
        [TestMethod]
        public void GivenLocalTimeExpectUtcTime()
        {
            var fixture = new Fixture();


            // arrange
            var datetime = new DateTime(2014, 1, 1, 1, 1, 1, DateTimeKind.Local);
            DateTime dateTimeUtc = datetime.ToUniversalTime();
            string expectedDateTimeString = string.Format(
                "{0}-{1}-{2}T{3}:{4}:{5}Z", 
                dateTimeUtc.Year.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'),
                dateTimeUtc.Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'),
                dateTimeUtc.Day.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'),
                dateTimeUtc.Hour.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'),
                dateTimeUtc.Minute.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'),
                dateTimeUtc.Second.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'));

            // act
            string actualDateTimeString = datetime.ToUtcIso8601();

            // assert
            Assert.AreEqual(expectedDateTimeString, actualDateTimeString);
        }

        /// <summary>
        /// The given unspecified date time expect same time.
        /// </summary>
        [TestMethod]
        public void GivenUnspecifiedDateTimeExpectSameTime()
        {
            // arrange
            var datetime = new DateTime(2014, 1, 1, 1, 1, 1, DateTimeKind.Unspecified);
            const string ExpectedDateTimeString = "2014-01-01T01:01:01Z";

            // act
            string actualDateTimeString = datetime.ToUtcIso8601();

            // assert
            Assert.AreEqual(ExpectedDateTimeString, actualDateTimeString);
        }

        /// <summary>
        /// The given utc date time expect same time.
        /// </summary>
        [TestMethod]
        public void GivenUtcDateTimeExpectSameTime()
        {
            // arrange
            var datetime = new DateTime(2014, 1, 1, 1, 1, 1, DateTimeKind.Utc);
            const string ExpectedDateTimeString = "2014-01-01T01:01:01Z";

            // act
            string actualDateTimeString = datetime.ToUtcIso8601();

            // assert
            Assert.AreEqual(ExpectedDateTimeString, actualDateTimeString);
        }

        #endregion
    }
}