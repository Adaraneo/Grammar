using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grammar.Czech.Services
{
    public class CzechSofteningRuleEvaluator : ISofteningRuleEvaluator<CzechWordRequest>
    {
        private readonly List<SofteningRule> rules = new()
        {
            new("žena", WordCategory.Noun, Number.Singular, Case.Dative, req => req.Lemma != "žena"),
            new("žena", WordCategory.Noun, Number.Singular, Case.Locative, req => req.Lemma != "žena"),
            new(null, WordCategory.Noun, null, Case.Vocative,
                req => req.Lemma?.EndsWith("ec") == true)
        };

        public bool ShouldApplySoftening(CzechWordRequest request)
        {
            return rules.Any(rule =>
                (rule.Pattern == null || rule.Pattern == request.Pattern) &&
                (rule.Category == null || rule.Category == request.WordCategory) &&
                (rule.Number == null || rule.Number == request.Number) &&
                (rule.Case == null || rule.Case == request.Case) &&
                (rule.CustomPredicate == null || rule.CustomPredicate(request))
            );
        }
    }
}
