namespace Grammar.Core.Models.Word
{
    public class WordForm
    {
        public string Form { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public WordForm(string form)
        {
            Form = form;
        }
    }
}
