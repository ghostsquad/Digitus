namespace Digitus.PlainTextStyling
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Digitus.PlainTextStyling.Components;

    /// <summary>
    ///     The element.
    /// </summary>
    public class BoxStyleBuilder : IBoxModel
    {
        #region Fields

        /// <summary>
        ///     The original value.
        /// </summary>
        private readonly string originalValue;

        /// <summary>
        ///     The lines.
        /// </summary>
        private List<string> lines;

        /// <summary>
        ///     The max line length.
        /// </summary>
        private int maxLineLength;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxStyleBuilder"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public BoxStyleBuilder(string value)
        {
            this.originalValue = value;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the borders.
        /// </summary>
        public Borders Borders { get; private set; }

        /// <summary>
        ///     Gets the margins.
        /// </summary>
        public BoxSpacing Margins { get; private set; }

        /// <summary>
        ///     Gets the padding.
        /// </summary>
        public BoxSpacing Padding { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The to string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            this.lines = this.originalValue.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            this.maxLineLength = this.lines.Select(l => l.Length).Max();

            // add padding
            this.AddBoxSpacing(this.Padding);

            // add borders
            this.AddBorders();

            // add margins
            this.AddBoxSpacing(this.Margins);

            var valueBuilder = new StringBuilder();
            var linesRemaining = this.lines.Count;
            foreach (var line in this.lines)
            {
                valueBuilder.Append(line);
                linesRemaining--;
                if (linesRemaining >= 1)
                {
                    valueBuilder.AppendLine();
                }
            }

            return valueBuilder.ToString();
        }

        /// <summary>
        /// The with borders.
        /// </summary>
        /// <param name="borders">
        /// The borders.
        /// </param>
        /// <returns>
        /// The <see cref="BoxStyleBuilder"/>.
        /// </returns>
        public BoxStyleBuilder WithBorders(Borders borders)
        {
            this.Borders = borders;

            return this;
        }

        /// <summary>
        /// The with margins.
        /// </summary>
        /// <param name="margins">
        /// The margins.
        /// </param>
        /// <returns>
        /// The <see cref="BoxStyleBuilder"/>.
        /// </returns>
        public BoxStyleBuilder WithMargins(BoxSpacing margins)
        {
            this.Margins = margins;

            return this;
        }

        /// <summary>
        /// The with padding.
        /// </summary>
        /// <param name="padding">
        /// The padding.
        /// </param>
        /// <returns>
        /// The <see cref="BoxStyleBuilder"/>.
        /// </returns>
        public BoxStyleBuilder WithPadding(BoxSpacing padding)
        {
            this.Padding = padding;

            return this;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The add borders.
        /// </summary>
        private void AddBorders()
        {
            if (this.Borders == null)
            {
                return;
            }

            var borders = this.Borders;

            // to add borders, we first need to add right/left borders (as it will change to total length of each line)
            // then we can add the top/bottom
            var leftBorderChar = borders.Left == null ? string.Empty : borders.Left.Char.ToString(CultureInfo.CurrentCulture);
            var rightBorderChar = borders.Right == null ? string.Empty : borders.Right.Char.ToString(CultureInfo.CurrentCulture);

            for (var i = 0; i < this.lines.Count; i++)
            {
                this.lines[i] = leftBorderChar + this.lines[i] + rightBorderChar;
            }

            var maxBorderLength = this.lines[0].Length;

            var topBorderLength = borders.Top.Size < 0 ? maxBorderLength : borders.Top.Size;
            var bottomBorderLength = borders.Bottom.Size < 0 ? maxBorderLength : borders.Bottom.Size;

            this.lines.Insert(0, new string(borders.Top.Char, topBorderLength));
            this.lines.Add(new string(borders.Bottom.Char, bottomBorderLength));
        }

        /// <summary>
        /// The add box spacing.
        /// </summary>
        /// <param name="boxSpacing">
        /// The box spacing.
        /// </param>
        private void AddBoxSpacing(IFourSided<int> boxSpacing)
        {
            if (boxSpacing == null)
            {
                return;
            }

            // margins and padding work the same way, so we can use a common method for both.
            // essentially, what we need to do, is split our string by Environment.NewLine
            // and prepend & append new lines to our string according to the top/bottom padding integer
            // then, we loop through each line, and prepend & append and string.padleft/right by 
            // maxlinelength + spacing left + spacing right
            var topSpacing = new List<string>();
            var bottomSpacing = new List<string>();
          
            for (var i = 0; i < boxSpacing.Top; i++)
            {
                topSpacing.Add(new string(' ', this.maxLineLength));
            }

            for (var i = 0; i < boxSpacing.Bottom; i++)
            {
                topSpacing.Add(new string(' ', this.maxLineLength));
            }

            this.lines.InsertRange(0, topSpacing);
            this.lines.AddRange(bottomSpacing);

            for (var i = 0; i < this.lines.Count; i++)
            {
                this.lines[i] =
                    this.lines[i].PadLeft(this.lines[i].Length + boxSpacing.Left, ' ')
                        .PadRight(Math.Max(this.maxLineLength, this.lines[i].Length) + boxSpacing.Right, ' ');
            }
        }

        #endregion
    }
}