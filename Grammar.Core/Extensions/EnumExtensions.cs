using Grammar.Core.Enums;

namespace Grammar.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string ToShortCode(this Case grammaticalCase) => grammaticalCase switch
        {
            Case.Nominative => "nom",
            Case.Genitive => "gen",
            Case.Dative => "dat",
            Case.Accusative => "acc",
            Case.Vocative => "voc",
            Case.Locative => "loc",
            Case.Instrumental => "ins",
            _ => grammaticalCase.ToString().ToLowerInvariant()
        };
    }
}
