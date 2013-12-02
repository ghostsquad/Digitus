namespace Digitus.PlainTextStyling
{
    using Digitus.PlainTextStyling.Components;

    /// <summary>
    ///     The BoxModel interface.
    /// </summary>
    public interface IBoxModel
    {
        #region Public Properties

        /// <summary>
        /// Gets the borders.
        /// </summary>
        Borders Borders { get; }

        /// <summary>
        ///     Gets the margins.
        /// </summary>
        BoxSpacing Margins { get; }

        /// <summary>
        ///     Gets the padding.
        /// </summary>
        BoxSpacing Padding { get; }

        #endregion
    }
}