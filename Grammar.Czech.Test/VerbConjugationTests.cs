using Grammar.Core.Enums;
using Grammar.Czech.Models;
using Grammar.Czech.Providers;
using Grammar.Czech.Providers.JsonProviders;
using Grammar.Czech.Services;

namespace Grammar.Czech.Test
{
    [TestClass]
    public sealed class VerbConjugationTests
    {
        private CzechVerbConjugationService service;

        [TestInitialize]
        public void Setup()
        {
            var verbDataProvider    = new JsonVerbDataProvider();
            var nounDataProvider    = new JsonNounDataProvider();
            var prefixDataProvider  = new JsonPrefixDataProvider();
            var particleDataProvider = new JsonParticlesDataProvider();

            var registry            = new CzechPhonemeRegistry();
            var phonologyService    = new CzechPhonologyService(registry);
            var prefixService       = new CzechPrefixService(prefixDataProvider);
            var particleService     = new CzechParticleService(particleDataProvider);

            var verbStructureResolver = new CzechWordStructureResolver(
                verbDataProvider, nounDataProvider, prefixService, phonologyService);

            service = new CzechVerbConjugationService(
                verbDataProvider,
                verbStructureResolver,
                particleService,
                prefixService);
        }

        // ------------------------------------------------------------------ //
        //  Přítomný čas                                                       //
        // ------------------------------------------------------------------ //

        /// <summary>
        /// Pokrývá: named pattern (nese, dělá), generické třídy (trida3, trida4)
        /// a nepravidelné být.
        /// </summary>
        [DataTestMethod]
        [DataRow("nést",    "nese",   "First",  "Singular", "nesu",   DisplayName = "nést – 1sg")]
        [DataRow("nést",    "nese",   "Second", "Singular", "neseš",  DisplayName = "nést – 2sg")]
        [DataRow("nést",    "nese",   "Third",  "Singular", "nese",   DisplayName = "nést – 3sg")]
        [DataRow("nést",    "nese",   "First",  "Plural",   "neseme", DisplayName = "nést – 1pl")]
        [DataRow("nést",    "nese",   "Second", "Plural",   "nesete", DisplayName = "nést – 2pl")]
        [DataRow("nést",    "nese",   "Third",  "Plural",   "nesou",  DisplayName = "nést – 3pl")]
        [DataRow("dělat",   "dělá",   "First",  "Singular", "dělám",  DisplayName = "dělat – 1sg")]
        [DataRow("dělat",   "dělá",   "Third",  "Singular", "dělá",   DisplayName = "dělat – 3sg")]
        [DataRow("dělat",   "dělá",   "Third",  "Plural",   "dělají", DisplayName = "dělat – 3pl")]
        [DataRow("prosit",  "trida4", "First",  "Singular", "prosím", DisplayName = "prosit – 1sg")]
        [DataRow("prosit",  "trida4", "Third",  "Singular", "prosí",  DisplayName = "prosit – 3sg")]
        [DataRow("kupovat", "trida3", "First",  "Singular", "kupuji", DisplayName = "kupovat – 1sg")]
        [DataRow("kupovat", "trida3", "Third",  "Singular", "kupuje", DisplayName = "kupovat – 3sg")]
        [DataRow("být",     "být",    "First",  "Singular", "jsem",   DisplayName = "být – 1sg")]
        [DataRow("být",     "být",    "Second", "Singular", "jsi",    DisplayName = "být – 2sg")]
        [DataRow("být",     "být",    "Third",  "Singular", "je",     DisplayName = "být – 3sg")]
        [DataRow("být",     "být",    "First",  "Plural",   "jsme",   DisplayName = "být – 1pl")]
        [DataRow("být",     "být",    "Third",  "Plural",   "jsou",   DisplayName = "být – 3pl")]
        public void GetBasicForm_PresentTense_ReturnsCorrectForm(
            string lemma, string pattern, string person, string number, string expected)
        {
            var request = new CzechWordRequest
            {
                Lemma        = lemma,
                Pattern      = pattern,
                WordCategory = WordCategory.Verb,
                Tense        = Tense.Present,
                Modus        = Modus.Indicative,
                Voice        = Voice.Active,
                Person       = Enum.Parse<Person>(person),
                Number       = Enum.Parse<Number>(number),
            };

            var result = service.GetBasicForm(request);

            Assert.AreEqual(expected, result.Form);
        }

        // ------------------------------------------------------------------ //
        //  Minulý čas                                                         //
        // ------------------------------------------------------------------ //

        /// <summary>
        /// Pokrývá: named pattern (nese, dělá), generická třída (trida4), být.
        /// Tři rody × singular/plural.
        /// </summary>
        [DataTestMethod]
        [DataRow("nést",   "nese",   "Masculine", "Singular", "nesl",    DisplayName = "nést – min. sg m")]
        [DataRow("nést",   "nese",   "Feminine",  "Singular", "nesla",   DisplayName = "nést – min. sg f")]
        [DataRow("nést",   "nese",   "Neuter",    "Singular", "neslo",   DisplayName = "nést – min. sg n")]
        [DataRow("nést",   "nese",   "Masculine", "Plural",   "nesli",   DisplayName = "nést – min. pl m")]
        [DataRow("nést",   "nese",   "Feminine",  "Plural",   "nesly",   DisplayName = "nést – min. pl f")]
        [DataRow("dělat",  "dělá",   "Masculine", "Singular", "dělal",   DisplayName = "dělat – min. sg m")]
        [DataRow("dělat",  "dělá",   "Feminine",  "Singular", "dělala",  DisplayName = "dělat – min. sg f")]
        [DataRow("dělat",  "dělá",   "Neuter",    "Singular", "dělalo",  DisplayName = "dělat – min. sg n")]
        [DataRow("dělat",  "dělá",   "Masculine", "Plural",   "dělali",  DisplayName = "dělat – min. pl m")]
        [DataRow("prosit", "trida4", "Masculine", "Singular", "prosil",  DisplayName = "prosit – min. sg m")]
        [DataRow("prosit", "trida4", "Feminine",  "Singular", "prosila", DisplayName = "prosit – min. sg f")]
        [DataRow("být",    "být",    "Masculine", "Singular", "byl",     DisplayName = "být – min. sg m")]
        [DataRow("být",    "být",    "Feminine",  "Singular", "byla",    DisplayName = "být – min. sg f")]
        [DataRow("být",    "být",    "Neuter",    "Singular", "bylo",    DisplayName = "být – min. sg n")]
        [DataRow("být",    "být",    "Masculine", "Plural",   "byli",    DisplayName = "být – min. pl m")]
        public void GetBasicForm_PastTense_ReturnsCorrectForm(
            string lemma, string pattern, string gender, string number, string expected)
        {
            var request = new CzechWordRequest
            {
                Lemma        = lemma,
                Pattern      = pattern,
                WordCategory = WordCategory.Verb,
                Tense        = Tense.Past,
                Modus        = Modus.Indicative,
                Voice        = Voice.Active,
                Person       = Person.Third,
                Gender       = Enum.Parse<Gender>(gender),
                Number       = Enum.Parse<Number>(number),
            };

            var result = service.GetBasicForm(request);

            Assert.AreEqual(expected, result.Form);
        }

        // ------------------------------------------------------------------ //
        //  Budoucí čas                                                        //
        // ------------------------------------------------------------------ //

        /// <summary>
        /// Pokrývá:
        /// - "být" → syntetické budoucí přes futureStem z dat ("bud")
        /// - perfektivní sloveso (donést) → přítomný tvar je fakticky budoucí
        /// - imperfektivní sloveso (dělat) → opisné budoucí, vrací infinitiv
        /// </summary>
        [DataTestMethod]
        [DataRow("být",    "být",  "First",  "Singular", "Imperfective", "budu",   DisplayName = "být – bud. 1sg")]
        [DataRow("být",    "být",  "Second", "Singular", "Imperfective", "budeš",  DisplayName = "být – bud. 2sg")]
        [DataRow("být",    "být",  "Third",  "Singular", "Imperfective", "bude",   DisplayName = "být – bud. 3sg")]
        [DataRow("být",    "být",  "First",  "Plural",   "Imperfective", "budeme", DisplayName = "být – bud. 1pl")]
        [DataRow("být",    "být",  "Third",  "Plural",   "Imperfective", "budou",  DisplayName = "být – bud. 3pl")]
        [DataRow("donést", "nese", "First",  "Singular", "Perfective",   "donesu", DisplayName = "donést – bud. 1sg (pf přít.)")]
        [DataRow("donést", "nese", "Third",  "Singular", "Perfective",   "donese", DisplayName = "donést – bud. 3sg (pf přít.)")]
        [DataRow("dělat",  "dělá", "Third",  "Singular", "Imperfective", "dělat",  DisplayName = "dělat – bud. opisné → infinitiv")]
        public void GetBasicForm_FutureTense_ReturnsCorrectForm(
            string lemma, string pattern, string person, string number,
            string aspect, string expected)
        {
            var request = new CzechWordRequest
            {
                Lemma        = lemma,
                Pattern      = pattern,
                WordCategory = WordCategory.Verb,
                Tense        = Tense.Future,
                Modus        = Modus.Indicative,
                Voice        = Voice.Active,
                Person       = Enum.Parse<Person>(person),
                Number       = Enum.Parse<Number>(number),
                Aspect       = Enum.Parse<VerbAspect>(aspect),
                Gender       = Gender.Masculine,
            };

            var result = service.GetBasicForm(request);

            Assert.AreEqual(expected, result.Form);
        }

        // ------------------------------------------------------------------ //
        //  Imperativ                                                          //
        // ------------------------------------------------------------------ //

        /// <summary>
        /// Pokrývá:
        /// - být → explicitní ImperativeStem z dat ("buď")
        /// - nést/nese → fallback na PresentStem, bez dvojité souhlásky
        /// - tisknout/trida2 → PresentStem="tisk", EndsWithTwoConsonants → epentetické "i"
        /// </summary>
        [DataTestMethod]
        [DataRow("být",      "být",    "Second", "Singular", "buď!",    DisplayName = "být – imp. 2sg")]
        [DataRow("být",      "být",    "First",  "Plural",   "buďme!",  DisplayName = "být – imp. 1pl")]
        [DataRow("být",      "být",    "Second", "Plural",   "buďte!",  DisplayName = "být – imp. 2pl")]
        [DataRow("nést",     "nese",   "Second", "Singular", "nes!",    DisplayName = "nést – imp. 2sg")]
        [DataRow("nést",     "nese",   "Second", "Plural",   "neste!",  DisplayName = "nést – imp. 2pl")]
        [DataRow("tisknout", "trida2", "Second", "Singular", "tiski!",  DisplayName = "tisknout – imp. 2sg (epenthesis)")]
        [DataRow("tisknout", "trida2", "Second", "Plural",   "tiskněte!", DisplayName = "tisknout – imp. 2pl")]
        public void GetBasicForm_Imperative_ReturnsCorrectForm(
            string lemma, string pattern, string person, string number, string expected)
        {
            var request = new CzechWordRequest
            {
                Lemma        = lemma,
                Pattern      = pattern,
                WordCategory = WordCategory.Verb,
                Modus        = Modus.Imperative,
                Voice        = Voice.Active,
                Person       = Enum.Parse<Person>(person),
                Number       = Enum.Parse<Number>(number),
            };

            var result = service.GetBasicForm(request);

            Assert.AreEqual(expected, result.Form);
        }
    }
}
