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
            new("žena", WordCategory.Noun, Number.Singular, Case.Dative, req => req.Lemma.EndsWith("ka"), EndingTransformation: "-e"),
            new("žena", WordCategory.Noun, Number.Singular, Case.Locative, req => req.Lemma.EndsWith("ka"), EndingTransformation: "-e"),
            //new("žena", WordCategory.Noun, Number.Plural, Case.Genitive, req => req.Lemma.EndsWith("ka"), EndingTransformation: "-ek"),

            new("žena", WordCategory.Noun, Number.Singular, Case.Dative, req => !req.Lemma.EndsWith("ka") && req.Lemma != "žena"),
            new("žena", WordCategory.Noun, Number.Singular, Case.Locative, req => !req.Lemma.EndsWith("ka") && req.Lemma != "žena"),

            new(null, WordCategory.Noun, null, Case.Vocative,
                req => req.Lemma?.EndsWith("ec") == true)
        };

        public string? GetEngingTransformation(CzechWordRequest wordRequest)
        {
            var rule = rules.FirstOrDefault(rule =>
                (rule.Pattern == null || rule.Pattern == wordRequest.Pattern) &&
                (rule.Category == null || rule.Category == wordRequest.WordCategory) &&
                (rule.Number == null || rule.Number == wordRequest.Number) &&
                (rule.Case == null || rule.Case == wordRequest.Case) &&
                (rule.CustomPredicate == null || rule.CustomPredicate(wordRequest))
            );

            return rule?.EndingTransformation;
        }

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
