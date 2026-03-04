namespace Grammar.Czech.Models
{
    public sealed record PronounFormOptions(
        bool AfterPreposition = false,
        bool PreferClitic = false,
        bool PreferRare = false
        );
}
