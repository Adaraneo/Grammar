using Grammar.Core.Enums;

namespace Grammar.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for working with enum values.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts a grammatical case to its short Czech-style code.
        /// </summary>
        /// <param name="grammaticalCase">The grammatical case requested for the generated form.</param>
        /// <returns>The short case code used in Czech morphology data.</returns>
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
