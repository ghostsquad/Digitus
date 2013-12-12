namespace Digitus
{
    using System;
    using System.Text;

    using Digitus.PlainTextStyling;
    using Digitus.PlainTextStyling.Components;

    /// <summary>
    ///     The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        #region Constants

        /// <summary>
        ///     The default wrap on.
        /// </summary>
        private const char DefaultWrapOn = ' ';

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The with new line.
        /// </summary>
        /// <param name="value">
        /// The the string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string WithNewLine(this string value)
        {
            return value == null ? null : new StringBuilder(2).Append(value).Append(Environment.NewLine).ToString();
        }

        /// <summary>
        /// The wrap.
        /// </summary>
        /// <param name="value">
        /// The the string.
        /// </param>
        /// <param name="maxLineLength">
        /// The max line length.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Wrap(this string value, int maxLineLength)
        {
            return value.Wrap(DefaultWrapOn, maxLineLength);
        }

        /// <summary>
        /// Wraps a string, using the wrapOn character as applicable position to wrap.
        ///     Wraps occur as close to the maxLineLength without going over.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="wrapOn">
        /// The wrap on character.
        /// </param>
        /// <param name="maxLineLength">
        /// The max line length.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Wrap(this string value, char wrapOn, int maxLineLength)
        {
            var wrappedStringBuilder = new StringBuilder();

            int startIndex = 0;
            int lastIndexOfWrapOnCharacter = -1;

            for (int i = 0; i < value.Length; i++)
            {
                // check if the current character matches the character we can wrap on (replace with newline)
                if (value[i] == wrapOn)
                {
                    lastIndexOfWrapOnCharacter = i;
                }

                // before checking if we need to manually wrap the string (see below)
                // we need to check if we are at a new line (pre wrapped)
                // example                
                // maxlength = 2
                // wrapOn = ' '; (space)
                // string = "hi\r\nmy name is"
                // when we get to index 2 (\r)
                // we need to look ahead (if it's safe to do so), ensure it matches the environment newline
                // then we should simple append startIndex (0), length = ++index(2 + 1) - startIndex(0) = 3
                // this will move our index forward to the (\n), then forward again when we start the loop over
                // we also need to reset our lastIndexOfWrapChar back to -1 to indicate we have not yet stumbled across a new wrapOn char (space)
                // finally, startIndex should be currentIndex + 2 (or +1 if it's after the increment above)
                // then we "continue" to avoid executing the remaining checks in the loop
                if (i + 1 < value.Length && value.Substring(i, 2) == Environment.NewLine)
                {
                    wrappedStringBuilder.Append(value.Substring(startIndex, (++i + 1) - startIndex));
                    lastIndexOfWrapOnCharacter = -1;
                    while (i + 1 < value.Length && value[i + 1] == ' ')
                    {
                        i++;
                    }

                    startIndex = i + 1;
                    continue;
                }

                // if our current substring length (current location - start index) is greater than or equal                
                // to the maxlineLength, and we found a wrap character prior (keeps from wrapping mid word)
                // we must WRAP at the last known wrap character
                // by appending a new line to our string builder
                // which extends from the start index, for the length of wrapCharIndex - start index
                // example
                // maxlength = 2
                // wrapOn = ' '; //(space)
                // string = "hi my name is"
                // when i == 2, currentCharacter will be a space
                // 2 - 0 >= 2 (true), lastIndexOfWrapChar > 0 (true)
                // appendline with the string builder
                // startindex (0), length 2 (which is lastIndexOfWrapChar (2) - startIndex (0))
                // which is "hi"
                if ((i - startIndex) >= maxLineLength && lastIndexOfWrapOnCharacter > 0)
                {
                    wrappedStringBuilder.AppendLine(
                        value.Substring(startIndex, lastIndexOfWrapOnCharacter - startIndex));

                    // then we need to set our start index to the character after our lastIndexOfWrapChar
                    // at lastIndexOfWrapChar 2 (the space)
                    // our newStart becomes 3 (the "m")
                    // we set lastIndexOfWrapChar back to -1 to indicate we have not yet stumbled across a new wrapOn char (space)
                    startIndex = lastIndexOfWrapOnCharacter + 1;
                    while (startIndex + 1 < value.Length && value[startIndex] == ' ')
                    {
                        startIndex++;
                    }

                    lastIndexOfWrapOnCharacter = -1;
                }
            }

            // when we get to the end of the loop, we can just append the remainder to the string builder
            wrappedStringBuilder.Append(value.Substring(startIndex).TrimStart());

            return wrappedStringBuilder.ToString();
        }

        #endregion
    }
}