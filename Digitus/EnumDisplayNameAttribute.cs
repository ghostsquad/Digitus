// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumDisplayNameAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The enum display name attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus
{
    using System;

    /// <summary>
    ///     The enum display name attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDisplayNameAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumDisplayNameAttribute"/> class.
        /// </summary>
        /// <param name="displayName">
        /// The display name.
        /// </param>
        public EnumDisplayNameAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        #endregion
    }
}