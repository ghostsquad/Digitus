namespace Digitus.PlainTextStyling.Components
{
    /// <summary>
    /// The box spacing builder.
    /// </summary>
    public class BoxSpacingBuilder
    {
        #region Fields

        /// <summary>
        /// The box spacing.
        /// </summary>
        private readonly BoxSpacing boxSpacing;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxSpacingBuilder"/> class.
        /// </summary>
        public BoxSpacingBuilder()
        {
            this.boxSpacing = new BoxSpacing();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The to box spacing.
        /// </summary>
        /// <returns>
        /// The <see cref="BoxSpacing"/>.
        /// </returns>
        public BoxSpacing ToBoxSpacing()
        {
            return this.boxSpacing;
        }

        /// <summary>
        /// The with bottom spacing.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BoxSpacingBuilder"/>.
        /// </returns>
        public BoxSpacingBuilder WithBottomSpacing(int size)
        {
            this.boxSpacing.Bottom = size;

            return this;
        }

        /// <summary>
        /// The with left spacing.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BoxSpacingBuilder"/>.
        /// </returns>
        public BoxSpacingBuilder WithLeftSpacing(int size)
        {
            this.boxSpacing.Left = size;

            return this;
        }

        /// <summary>
        /// The with right spacing.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BoxSpacingBuilder"/>.
        /// </returns>
        public BoxSpacingBuilder WithRightSpacing(int size)
        {
            this.boxSpacing.Right = size;

            return this;
        }

        /// <summary>
        /// The with top spacing.
        /// </summary>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BoxSpacingBuilder"/>.
        /// </returns>
        public BoxSpacingBuilder WithTopSpacing(int size)
        {
            this.boxSpacing.Top = size;

            return this;
        }

        #endregion
    }
}