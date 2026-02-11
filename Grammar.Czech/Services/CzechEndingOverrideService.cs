using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

public class CzechEndingOverrideService : IEndingOverrideService<CzechWordRequest>
{
    public string? GetEndingOverride(CzechWordRequest request, string defaultEnding)
    {
        if (request.Pattern == "žena" &&
            request.Lemma.EndsWith("ka"))
        {
            if (request.Number == Number.Singular &&
            (request.Case == Case.Dative ||
            request.Case == Case.Locative))
            {
                return "-e";
            }
            if (request.Number == Number.Plural &&
                request.Case == Case.Genitive)
            {
                return "-ek";
            }
        }

        return null;
    }
}
