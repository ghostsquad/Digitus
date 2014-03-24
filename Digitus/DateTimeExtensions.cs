namespace Digitus
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The date time extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        // http://www.w3.org/TR/NOTE-datetime
        #region Constants

        /// <summary>
        /// The iso 8601 date format.
        /// </summary>
        public const string Iso8601DateFormat = "yyyy'-'MM'-'dd";

        /// <summary>
        /// The iso 8601 date time format.
        /// </summary>
        public const string Iso8601DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The to iso 8601.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToUtcIso8601(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                // If we don't know what the DateTime kind is, pretend it's UTC.
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }

            return dateTime.ToUniversalTime().ToString(Iso8601DateTimeFormat, CultureInfo.InvariantCulture);
        }

        #endregion
    }
}