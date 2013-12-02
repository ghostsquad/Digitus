namespace Digitus.PlainTextStyling.Components
{
    /// <summary>
    ///     The borders builder.
    /// </summary>
    public class BordersBuilder
    {
        #region Fields

        /// <summary>
        ///     The borders.
        /// </summary>
        private readonly Borders borders;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BordersBuilder" /> class.
        /// </summary>
        public BordersBuilder()
        {
            this.borders = new Borders();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The to borders.
        /// </summary>
        /// <returns>
        ///     The <see cref="Borders" />.
        /// </returns>
        public Borders ToBorders()
        {
            return this.borders;
        }

        /// <summary>
        /// The with bottom border.
        /// </summary>
        /// <param name="borderCharacter">
        /// The border character.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithBottomBorder(char borderCharacter, int size)
        {
            this.borders.Bottom = new Border(borderCharacter, size);
            return this;
        }

        /// <summary>
        /// The with bottom border.
        /// </summary>
        /// <param name="border">
        /// The border.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithBottomBorder(Border border)
        {
            this.borders.Bottom = border;
            return this;
        }

        /// <summary>
        /// The with left border.
        /// </summary>
        /// <param name="borderCharacter">
        /// The border character.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithLeftBorder(char borderCharacter, int size)
        {
            this.borders.Left = new Border(borderCharacter, size);
            return this;
        }

        /// <summary>
        /// The with left border.
        /// </summary>
        /// <param name="border">
        /// The border.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithLeftBorder(Border border)
        {
            this.borders.Left = border;
            return this;
        }

        /// <summary>
        /// The with right border.
        /// </summary>
        /// <param name="borderCharacter">
        /// The border character.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithRightBorder(char borderCharacter, int size)
        {
            this.borders.Right = new Border(borderCharacter, size);
            return this;
        }

        /// <summary>
        /// The with right border.
        /// </summary>
        /// <param name="border">
        /// The border.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithRightBorder(Border border)
        {
            this.borders.Right = border;
            return this;
        }

        /// <summary>
        /// The with top border.
        /// </summary>
        /// <param name="borderCharacter">
        /// The border character.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithTopBorder(char borderCharacter, int size)
        {
            this.borders.Top = new Border(borderCharacter, size);
            return this;
        }

        /// <summary>
        /// The with top border.
        /// </summary>
        /// <param name="border">
        /// The border.
        /// </param>
        /// <returns>
        /// The <see cref="BordersBuilder"/>.
        /// </returns>
        public BordersBuilder WithTopBorder(Border border)
        {
            this.borders.Top = border;
            return this;
        }

        #endregion
    }
}