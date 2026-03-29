using Grammar.Czech.Models;

namespace Grammar.Czech.Interfaces
{
    public interface IAlternationRuleEvaluator
    {
        bool ShouldShortenGenitivePlural(CzechWordRequest request, NounPattern pattern);
    }
}
