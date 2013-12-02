namespace Digitus.PlainTextStyling.Components
{
    /// <summary>
    ///     The plain text border.
    /// </summary>
    public class Border
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="c">
        /// The border character.
        /// </param>
        /// <param name="size">
        /// The size of the border. -1 for auto.
        /// </param>
        public Border(char c, int size)
        {
            this.Size = size;
            this.Char = c;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Border"/> class.
        /// </summary>
        /// <param name="c">
        /// The border character.
        /// </param>
        public Border(char c)
        {
            this.Size = -1;
            this.Char = c;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the character to use as the border.
        /// </summary>
        public char Char { get; set; }

        /// <summary>
        ///     Gets or sets the size.
        /// </summary>
        public int Size { get; set; }

        #endregion
    }
}