namespace Grammar.Core.Models.Word
{
    /// <summary>
    /// Represents the generated surface form of a word.
    /// </summary>
    public class WordForm
    {
        /// <summary>
        /// Gets or sets the generated surface form.
        /// </summary>
        public string Form { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordForm"/> type.
        /// </summary>
        public WordForm(string form)
        {
            Form = form;
        }
    }
}
