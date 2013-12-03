namespace Digitus
{
    using System;

    /// <summary>
    ///     The picky replace options.
    /// </summary>
    [Flags]
    public enum PickyReplaceOptions
    {
        /// <summary>
        ///     The exclude between.
        /// </summary>
        ExcludeBetween = 1, 

        /// <summary>
        ///     The include between.
        /// </summary>
        IncludeBetween = 2, 

        /// <summary>
        /// The end not required.
        /// </summary>
        EndNotRequired = 4
    }
}