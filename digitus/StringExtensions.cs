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

            var startIndex = 0;
            var lastIndexOfWrapOnCharacter = -1;

            for (var i = 0; i < theString.Length; i++)
            {
                // check if the current character matches the character we can wrap on (replace with newline)
                if (theString[i] == wrapOn)
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
                if (i + 1 < theString.Length && theString.Substring(i, 2) == Environment.NewLine)
                {                                        
                    wrappedStringBuilder.Append(theString.Substring(startIndex, (++i + 1) - startIndex));                    
                    lastIndexOfWrapOnCharacter = -1;
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
                        theString.Substring(startIndex, lastIndexOfWrapOnCharacter - startIndex));

                    //then we need to set our start index to the character after our lastIndexOfWrapChar
                    //at lastIndexOfWrapChar 2 (the space)
                    //our newStart becomes 3 (the "m")
                    //we set lastIndexOfWrapChar back to -1 to indicate we have not yet stumbled across a new wrapOn char (space)
                    startIndex = lastIndexOfWrapOnCharacter + 1;
                    lastIndexOfWrapOnCharacter = -1;
                }
            }

            //when we get to the end of the loop, we can just append the remainder to the string builder
            wrappedStringBuilder.Append(theString.Substring(startIndex));            

            return wrappedStringBuilder.ToString();
        }

        public static string WithNewLine(this string theString)
        {
            return new StringBuilder(2).Append(theString).Append(Environment.NewLine).ToString();            
        }

        #endregion
    }
}