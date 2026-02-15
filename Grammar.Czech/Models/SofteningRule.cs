using Grammar.Core.Enums;

namespace Grammar.Czech.Models
{
    public sealed record SofteningRule(
        string? Pattern = null,
        WordCategory? Category = null,
        Number? Number = null,
        Case? Case = null,
        Func<CzechWordRequest, bool>? CustomPredicate = null,
        string? EndingTransformation = null
    );
}
