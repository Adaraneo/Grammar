using System.Collections.Generic;
using System.Linq;
using Grammar.Core.Enums;
using Grammar.Core.Models;
using Grammar.Core.Interfaces;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechPronounService : ICzechPronounService, IInflectionService<CzechWordRequest>
    {
        private readonly Dictionary<string, PronounData> _pronouns;

        public CzechPronounService(IPronounDataProvider provider)
        {
            _pronouns = provider.GetPronouns();
        }

        public string? TryGetForm(string baseForm, Case grammaticalCase)
            => TryGetForm(baseForm, grammaticalCase, null);

        public string? TryGetForm(string baseForm, Case grammaticalCase, PronounFormOptions? options)
        {
            if (!_pronouns.TryGetValue(baseForm, out var data) || data.FixedForms == null)
            {
                return null;
            }

            if (!data.FixedForms.TryGetValue(grammaticalCase, out var forms))
            {
                return null;
            }

            return SelectBestForm(forms, options);
        }

        private string? SelectBestForm(PronounCaseForms caseForms, PronounFormOptions? options)
        {
            if (options == null)
            {
                return caseForms.Default
                    ?? caseForms.AfterPreposition
                    ?? caseForms.Clitic
                    ?? caseForms.Rare;
            }

            // 1) po předložce typicky přebije vše (příklonky po předložce nedávají smysl)
            if (options.AfterPreposition)
            {
                return caseForms.AfterPreposition
                    ?? caseForms.Default
                    ?? caseForms.Rare
                    ?? caseForms.Clitic;
            }

            // 2) preferuj příklonku, když je žádána
            if (options.PreferClitic)
            {
                return caseForms.Clitic
                    ?? caseForms.Default
                    ?? caseForms.Rare
                    ?? caseForms.AfterPreposition;
            }

            // 3) preferuj rare (knižní), když je žádána
            if (options.PreferRare)
            {
                return caseForms.Rare
                    ?? caseForms.Default
                    ?? caseForms.AfterPreposition
                    ?? caseForms.Clitic;
            }

            // 4) defaultní chování s drobnými fallbacky
            return caseForms.Default
                ?? caseForms.AfterPreposition
                ?? caseForms.Clitic
                ?? caseForms.Rare;
        }

        public IEnumerable<Case> GetAvailableCases(string baseForm)
        {
            if (_pronouns.TryGetValue(baseForm, out var data) && data.FixedForms != null)
            {
                return data.FixedForms.Keys;
            }

            return Enumerable.Empty<Case>();
        }

        public bool IsAllowed(string baseForm, Case grammaticalCase)
            => TryGetForm(baseForm, grammaticalCase) != null;

        public PronounType? GetPronounType(string baseForm)
        {
            return _pronouns.TryGetValue(baseForm, out var data)
                ? data.Type
                : null;
        }

        public WordForm GetForm(CzechWordRequest request)
        {
            if (request.Case == null)
            {
                throw new System.ArgumentException("Case must be specified for pronoun inflection.", nameof(request));
            }

            var form = TryGetForm(request.Lemma, request.Case.Value);

            return new WordForm(form ?? request.Lemma);
        }
    }
}
