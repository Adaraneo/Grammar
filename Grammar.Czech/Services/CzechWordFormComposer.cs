using Grammar.Core.Interfaces;
using Grammar.Core.Models;
using Grammar.Czech.Models;
using Grammar.Core.Enums;

namespace Grammar.Czech.Services
{
    public class CzechWordFormComposer : IWordFormComposer<CzechWordRequest>
    {
        private readonly INegationService<CzechWordRequest> negationService;
        private readonly CzechVerbPhraseBuilderService verbPhraseBuilderService;
        private readonly MorphologyEngine morphologyEngine;

        public CzechWordFormComposer(CzechVerbPhraseBuilderService verbPhraseBuilderService, INegationService<CzechWordRequest> negationService, MorphologyEngine morphologyEngine)
        {
            this.negationService = negationService;
            this.verbPhraseBuilderService = verbPhraseBuilderService;
            this.morphologyEngine = morphologyEngine;
        }

        public bool HasExplicitSubject { get; set; }
        public bool IsReflexive { get; set; }

        public WordForm GetFullForm(CzechWordRequest request)
        {
            // TODO: Make full form of phrase (especially verb for now). If word is single, return single form.
            WordForm form = morphologyEngine.GetForm(request);
            var verbNegationApplied = false;
            if (request.WordCategory == WordCategory.Verb)
            {
                var verbForm = form.Form;
                if (request.Aspect == VerbAspect.Imperfective && request.Tense == Tense.Future)
                {
                    verbForm = verbPhraseBuilderService.BuildSynteticFuturePhrase(verbForm, request.Number, request.Person, request.Modus, request.Gender, request.IsNegative);
                    verbNegationApplied = request.IsNegative;
                }
                else if (request.Voice == Voice.Passive)
                {
                    if (request.Modus == Modus.Conditional)
                    {
                        verbForm = verbPhraseBuilderService.BuildPassiveConditionalPhrase(verbForm, request.Number, request.Person, request.Modus, request.Gender, request.IsNegative);
                        verbNegationApplied = request.IsNegative;
                    }
                    else
                    {
                        verbForm = verbPhraseBuilderService.BuildPassivePhrase(verbForm, request.Tense, request.Number, request.Person, request.Modus, request.Gender, request.IsNegative);
                        verbNegationApplied = request.IsNegative;
                    }
                }
                else if (request.Modus == Modus.Conditional)
                {
                    verbForm = verbPhraseBuilderService.BuildConditionalPhrase(verbForm, request.Number, request.Person, HasExplicitSubject, request.IsNegative);
                    verbNegationApplied = request.IsNegative;
                }

                if (IsReflexive)
                {
                    verbForm = verbPhraseBuilderService.BuildReflexivePhrase(verbForm, (request.Case == Case.Dative));
                }

                form = new WordForm(verbForm);
            }

            if (request.IsNegative && !verbNegationApplied)
            {
                form = negationService.ApplyNegation(request, form.Form);
            }

            return form;
        }
    }
}
