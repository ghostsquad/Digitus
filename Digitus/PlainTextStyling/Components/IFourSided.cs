namespace Digitus.PlainTextStyling.Components
{
    /// <summary>
    /// The FourSided interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the side.
    /// </typeparam>
    public interface IFourSided<T>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        T Bottom { get; set; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        T Left { get; set; }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        T Right { get; set; }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        T Top { get; set; }

        #endregion
    }
}