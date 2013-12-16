// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Conversions.cs" company="">
//   
// </copyright>
// <summary>
//   The conversions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.HelperClasses
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The conversions.
    /// </summary>
    public static class Conversions
    {
        #region Static Fields

        /// <summary>
        /// The binary validation pattern.
        /// </summary>
        private static readonly Regex BinaryValidationPattern = new Regex(@"[01]+", RegexOptions.Compiled);

        /// <summary>
        /// The hex validation pattern.
        /// </summary>
        private static readonly Regex HexValidationPattern = new Regex(
            @"0x[0-9abcdef]+", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The convert binary to hex string.
        /// </summary>
        /// <param name="theBinaryString">
        /// The the binary string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static string ConvertBinaryToHexString(this string theBinaryString)
        {
            if (!BinaryValidationPattern.IsMatch(theBinaryString))
            {
                throw new ArgumentException("Invalid Binary String.");
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// The convert binary to int.
        /// </summary>
        /// <param name="theBinaryString">
        /// The the binary string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static int ConvertBinaryToInt(this string theBinaryString)
        {
            if (!BinaryValidationPattern.IsMatch(theBinaryString))
            {
                throw new ArgumentException("Invalid Binary String.");
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// The convert hex to binary string.
        /// </summary>
        /// <param name="theHexString">
        /// The the hex string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static string ConvertHexToBinaryString(this string theHexString)
        {
            if (!HexValidationPattern.IsMatch(theHexString))
            {
                throw new ArgumentException("Invalid Hex String.");
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// The convert hex to int.
        /// </summary>
        /// <param name="theHexString">
        /// The the hex string.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static int ConvertHexToInt(this string theHexString)
        {
            if (!HexValidationPattern.IsMatch(theHexString))
            {
                throw new ArgumentException("Invalid Hex String.");
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// The convert to binary string.
        /// </summary>
        /// <param name="theInt">
        /// The the int.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static string ConvertToBinaryString(this int theInt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The convert to hex string.
        /// </summary>
        /// <param name="theInt">
        /// The the int.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public static string ConvertToHexString(this int theInt)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}