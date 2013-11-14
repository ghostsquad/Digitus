namespace digitus
{
    using System;
    using System.Text;

    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        #region Constants

        /// <summary>
        /// The default wrap on.
        /// </summary>
        private const char DefaultWrapOn = ' ';

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The wrap.
        /// </summary>
        /// <param name="theString">
        /// The the string.
        /// </param>
        /// <param name="maxLineLength">
        /// The max line length.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Wrap(this string theString, int maxLineLength)
        {
            return theString.Wrap(DefaultWrapOn, maxLineLength);
        }

        /// <summary>
        /// The wrap.
        /// </summary>
        /// <param name="theString">
        /// The the string.
        /// </param>
        /// <param name="wrapOn">
        /// The wrap on.
        /// </param>
        /// <param name="maxLineLength">
        /// The max line length.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Wrap(this string theString, char wrapOn, int maxLineLength)
        {
            var wrappedStringBuilder = new StringBuilder();

            int startIndex = 0;
            int lastIndexOfWrapOnCharacter = -1;

            for (int i = 0; i < theString.Length; i++)
            {
                if (theString[i] == wrapOn)
                {
                    lastIndexOfWrapOnCharacter = i;
                }

                if (maxLineLength - (i - startIndex) <= 0 && lastIndexOfWrapOnCharacter > 0)
                {
                    wrappedStringBuilder.Append(
                        theString.Substring(startIndex, lastIndexOfWrapOnCharacter - startIndex));
                    wrappedStringBuilder.Append(Environment.NewLine);
                    startIndex = lastIndexOfWrapOnCharacter + 1;
                    lastIndexOfWrapOnCharacter = -1;
                }
            }

            wrappedStringBuilder.Append(theString.Substring(startIndex, theString.Length - startIndex));

            return wrappedStringBuilder.ToString();
        }

        #endregion
    }
}