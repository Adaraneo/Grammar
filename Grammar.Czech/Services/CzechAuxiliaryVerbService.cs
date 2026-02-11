using Grammar.Core.Enums;
using Grammar.Czech.Models;

namespace Grammar.Czech.Services
{
    public class CzechAuxiliaryVerbService
    {
        private readonly MorphologyEngine engine;
        public CzechAuxiliaryVerbService(MorphologyEngine engine)
        {
            this.engine = engine;
        }

        public string GetBeForm(Tense? tense, Number? number, Person? person, Modus? modus, Gender? gender, bool isNegative = false)
        {
            if (tense == Tense.Present && number == Number.Singular && person == Person.Third)
                return isNegative ? "není" : "je";

            var request = new CzechWordRequest
            {
                Lemma = "být",
                Pattern = "být",
                WordCategory = WordCategory.Verb,
                Tense = tense,
                Number = number,
                Person = person,
                Gender = gender,
                Modus = modus
            };

            var baseForm = engine.GetForm(request).Form;

            return isNegative ? $"ne{baseForm}" : baseForm;
        }
    }
}
