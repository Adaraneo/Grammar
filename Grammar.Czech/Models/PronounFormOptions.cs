namespace Grammar.Czech.Models
{
    /// <summary>
    /// Represents lookup options for selecting a Czech pronoun form.
    /// </summary>
    public sealed record PronounFormOptions(
        bool AfterPreposition = false,
        bool PreferClitic = false,
        bool PreferRare = false
        );
}
