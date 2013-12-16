// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoxSpacing.cs" company="">
//   
// </copyright>
// <summary>
//   The box spacing base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Digitus.PlainTextStyling.Components
{
    /// <summary>
    ///     The box spacing base.
    /// </summary>
    public class BoxSpacing : IFourSided<int>
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the bottom.
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        ///     Gets or sets the left.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        ///     Gets or sets the right.
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        ///     Gets or sets the top.
        /// </summary>
        public int Top { get; set; }

        #endregion
    }
}