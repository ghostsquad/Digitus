// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The enum extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus
{
    using System;
    using System.Linq;

    /// <summary>
    ///     The enum extensions.
    /// </summary>
    public static class EnumExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get display name.
        /// </summary>
        /// <param name="enumType">
        /// The enum type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetDisplayName(this Enum enumType)
        {
            var displayNameAttribute =
                enumType.GetType()
                    .GetField(enumType.ToString())
                    .GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                    .FirstOrDefault() as EnumDisplayNameAttribute;

            return displayNameAttribute != null
                       ? displayNameAttribute.DisplayName
                       : Enum.GetName(enumType.GetType(), enumType);
        }

        #endregion
    }
}