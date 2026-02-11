using Grammar.Core.Enums;

namespace Grammar.Czech.Services
{
    public class CzechVerbPhraseBuilderService
    {
        private readonly CzechAuxiliaryVerbService auxVerbService;
        private readonly CzechParticleService particleService;
        private readonly CzechPrefixService prefixService;

        private string BuildConditionalAuxiliary(string verbForm, Number? number, Person? person, bool explicitSubject, bool isNegative)
        {
            var particle = particleService.GetConditionalParticle(number, person);
            var negation = isNegative ? prefixService.GetNegativePrefix() : string.Empty;
            return explicitSubject ? $"{particle} {negation}{verbForm}" : $"{negation}{verbForm} {particle}";
        }

        public CzechVerbPhraseBuilderService(CzechAuxiliaryVerbService auxiliaryService,CzechParticleService particleService, CzechPrefixService prefixService)
        {
            this.auxVerbService = auxiliaryService;
            this.particleService = particleService;
            this.prefixService = prefixService;
        }

        public string BuildConditionalPhrase(string verbForm, Number? number, Person? person, bool explicitSubject, bool isNegative)
        {
            return BuildConditionalAuxiliary(verbForm, number, person, explicitSubject, isNegative);
        }

        public string BuildPassiveConditionalPhrase(string verbForm, Number? number, Person? person, Modus? modus, Gender? gender, bool isNegative)
        {
            var beForm = auxVerbService.GetBeForm(Tense.Past, number, person, modus, gender, isNegative);
            verbForm = BuildConditionalAuxiliary(verbForm, number, person, true, false);
            return $"{beForm} {verbForm}";
        }

        public string BuildPassivePhrase(string verbForm, Tense? tense, Number? number, Person? person, Modus? modus, Gender? gender, bool isNegative)
        {
            var beForm = auxVerbService.GetBeForm(tense, number, person, modus, gender, isNegative);
            return $"{beForm} {verbForm}";
        }

        public string BuildReflexivePhrase(string verbForm, bool isDative)
        {
            var reflexive = particleService.GetReflexive(isDative);
            return $"{verbForm} {reflexive}";
        }

        public string BuildSynteticFuturePhrase(string verbForm, Number? number, Person? person, Modus? modus, Gender? gender, bool isNegative)
        {
            var beForm = auxVerbService.GetBeForm(Tense.Future, number, person, modus, gender, isNegative);
            return $"{beForm} {verbForm}";
        }
    }
}