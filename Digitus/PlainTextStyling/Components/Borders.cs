namespace Digitus.PlainTextStyling.Components
{
    /// <summary>
    ///     The borders.
    /// </summary>
    public class Borders : IFourSided<Border>
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the bottom.
        /// </summary>
        public Border Bottom { get; set; }

        /// <summary>
        ///     Gets or sets the left.
        /// </summary>
        public Border Left { get; set; }

        /// <summary>
        ///     Gets or sets the right.
        /// </summary>
        public Border Right { get; set; }

        /// <summary>
        ///     Gets or sets the top.
        /// </summary>
        public Border Top { get; set; }

        #endregion
    }
}