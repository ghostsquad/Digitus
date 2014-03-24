namespace Digitus
{
    /// <summary>
    ///     The object extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        // http://stackoverflow.com/questions/811614/c-sharp-is-keyword-and-checking-for-not
        #region Public Methods and Operators

        /// <summary>
        /// The is a.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsA<T>(this object obj)
        {
            return obj is T;
        }

        #endregion
    }
}