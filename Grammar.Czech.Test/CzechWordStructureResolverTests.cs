using Grammar.Core.Enums;
using Grammar.Core.Interfaces;
using Grammar.Czech.Models;
using Grammar.Czech.Providers;
using Grammar.Czech.Providers.JsonProviders;
using Grammar.Czech.Services;
using System.Reflection;

namespace Grammar.Czech.Test
{
    /// <summary>
    /// Verifies czech word structure resolver behavior.
    /// </summary>
    [TestClass]
    public class CzechWordStructureResolverTests
    {
        private IWordStructureResolver<CzechWordRequest> _resolver;
        private IVerbStructureResolver<CzechWordRequest> _verbResolver;

        /// <summary>
        /// Creates the test subject and its dependencies.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            var registry = new CzechPhonemeRegistry();
            var phonologyService = new CzechPhonologyService(registry);
            var nounDataProvider = new JsonNounDataProvider();
            var verbDataProvider = new JsonVerbDataProvider();
            var prefixService = new CzechPrefixService(new JsonPrefixDataProvider());
            var epenthesisRule = new CzechEpenthesisRuleEvaluator(registry);

            var sut = new CzechWordStructureResolver(
                verbDataProvider, nounDataProvider, prefixService, phonologyService, registry, epenthesisRule);

            _resolver = sut;
            _verbResolver = sut;
        }

        // -------------------------------------------------------------------------

        #region vzor žena

        /// <summary>
        /// Verifies that analyze noun zena pattern extracts root.
        /// </summary>
        [TestMethod]
        public void AnalyzeNoun_ZenaPattern_ExtractsRoot()
        {
            // Arrange
            var request = BuildNounRequest("žena", "žena", Gender.Feminine, Case.Nominative, Number.Singular);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual("žen", result.Root);
            Assert.IsNull(result.DerivationSuffix);
        }

        /// <summary>
        /// Verifies that analyze noun zena pattern ka suffix extracts root and suffix.
        /// </summary>
        /// <param name="lemma">The dictionary form to resolve or analyze.</param>
        /// <param name="expectedRoot">The expected root extracted by the resolver.</param>
        /// <param name="expectedSuffix">The expected derivational suffix extracted by the resolver.</param>
        [TestMethod]
        [ZenaKaSuffixData]
        public void AnalyzeNoun_ZenaPatternKaSuffix_ExtractsRootAndSuffix(
            string lemma, string expectedRoot, string expectedSuffix)
        {
            // Arrange
            var request = BuildNounRequest(lemma, "žena", Gender.Feminine, Case.Genitive, Number.Plural);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual(expectedRoot, result.Root, $"Root pro {lemma}");
            Assert.AreEqual(expectedSuffix, result.DerivationSuffix, $"DerivationSuffix pro {lemma}");
        }

        #endregion vzor žena

        // -------------------------------------------------------------------------

        #region vzor město — strukturní sufix

        /// <summary>
        /// Verifies that analyze noun mesto pattern epenthesis cluster extracts root and suffix.
        /// </summary>
        /// <param name="lemma">The dictionary form to resolve or analyze.</param>
        /// <param name="expectedRoot">The expected root extracted by the resolver.</param>
        /// <param name="expectedSuffix">The expected derivational suffix extracted by the resolver.</param>
        [TestMethod]
        [MestoEpenthesisData]
        public void AnalyzeNoun_MestoPattern_EpenthesisCluster_ExtractsRootAndSuffix(
            string lemma, string expectedRoot, string expectedSuffix)
        {
            // Arrange
            var request = BuildNounRequest(lemma, "město", Gender.Neuter, Case.Genitive, Number.Plural);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual(expectedRoot, result.Root, $"Root pro {lemma}");
            Assert.AreEqual(expectedSuffix, result.DerivationSuffix, $"DerivationSuffix pro {lemma}");
        }

        /// <summary>
        /// Verifies that analyze noun mesto pattern stable cluster root unchanged.
        /// </summary>
        [TestMethod]
        public void AnalyzeNoun_MestoPattern_StableCluster_RootUnchanged()
        {
            // Homorganní shluk s+t — evaluátor vrátí false → root nesmí být zkrácen.
            // Arrange
            var request = BuildNounRequest("město", "město", Gender.Neuter, Case.Genitive, Number.Plural);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual("měst", result.Root);
        }

        #endregion vzor město — strukturní sufix

        // -------------------------------------------------------------------------

        #region vzor kost

        /// <summary>
        /// Verifies that analyze noun kost pattern extracts root.
        /// </summary>
        [TestMethod]
        public void AnalyzeNoun_KostPattern_ExtractsRoot()
        {
            // Arrange
            var request = BuildNounRequest("radost", "kost", Gender.Feminine, Case.Nominative, Number.Singular);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual("radost", result.Root);
            Assert.IsNull(result.DerivationSuffix);
        }

        #endregion vzor kost

        // -------------------------------------------------------------------------

        #region Mobile vowel

        /// <summary>
        /// Verifies that analyze noun pes nom sg keeps mobile vowel.
        /// </summary>
        [TestMethod]
        public void AnalyzeNoun_Pes_NomSg_KeepsMobileVowel()
        {
            // Arrange
            var request = BuildNounRequest("pes", "pán", Gender.Masculine, Case.Nominative, Number.Singular);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual("pes", result.Root);
        }

        /// <summary>
        /// Verifies that analyze noun pes gen sg removes mobile vowel.
        /// </summary>
        [TestMethod]
        public void AnalyzeNoun_Pes_GenSg_RemovesMobileVowel()
        {
            // Arrange
            var request = BuildNounRequest("pes", "pán", Gender.Masculine, Case.Genitive, Number.Singular, true);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual("ps", result.Root);
        }

        /// <summary>
        /// Verifies that analyze noun otec gen sg removes mobile vowel.
        /// </summary>
        [TestMethod]
        public void AnalyzeNoun_Otec_GenSg_RemovesMobileVowel()
        {
            // Arrange
            var request = BuildNounRequest("otec", "muž", Gender.Masculine, Case.Genitive, Number.Singular, true);

            // Act
            var result = _resolver.AnalyzeStructure(request);

            // Assert
            Assert.AreEqual("otc", result.Root);
        }

        #endregion Mobile vowel

        // -------------------------------------------------------------------------

        #region Verbs

        /// <summary>
        /// Verifies that analyze verb with prefix extracts prefix and stem.
        /// </summary>
        [TestMethod]
        public void AnalyzeVerb_WithPrefix_ExtractsPrefixAndStem()
        {
            // Arrange
            var request = new CzechWordRequest
            {
                Lemma = "donést",
                Pattern = "nese",
                WordCategory = WordCategory.Verb,
                Tense = Tense.Present
            };

            // Act
            var result = _verbResolver.AnalyzeVerbStructure(request);

            // Assert
            Assert.AreEqual("do", result.Prefix);
            Assert.AreEqual("nes", result.PresentStem);
        }

        /// <summary>
        /// Verifies that analyze verb irregular byt uses present stem.
        /// </summary>
        [TestMethod]
        public void AnalyzeVerb_IrregularByt_UsesPresentStem()
        {
            // Arrange
            var request = new CzechWordRequest
            {
                Lemma = "být",
                Pattern = "být",
                WordCategory = WordCategory.Verb,
                Tense = Tense.Present
            };

            // Act
            var result = _verbResolver.AnalyzeVerbStructure(request);

            // Assert
            Assert.AreEqual("js", result.PresentStem);
        }

        #endregion Verbs

        // -------------------------------------------------------------------------

        #region Guard clauses

        /// <summary>
        /// Verifies that analyze structure empty lemma throws argument exception.
        /// </summary>
        [TestMethod]
        public void AnalyzeStructure_EmptyLemma_ThrowsArgumentException()
        {
            var request = new CzechWordRequest { Lemma = "", Pattern = "žena" };

            Assert.ThrowsException<ArgumentException>(() => _resolver.AnalyzeStructure(request));
        }

        /// <summary>
        /// Verifies that analyze structure empty pattern throws argument exception.
        /// </summary>
        [TestMethod]
        public void AnalyzeStructure_EmptyPattern_ThrowsArgumentException()
        {
            var request = new CzechWordRequest { Lemma = "žena", Pattern = "" };

            Assert.ThrowsException<ArgumentException>(() => _resolver.AnalyzeStructure(request));
        }

        #endregion Guard clauses

        // -------------------------------------------------------------------------

        #region Helpers

        private static CzechWordRequest BuildNounRequest(
            string lemma, string pattern, Gender gender, Case @case, Number number, bool? hasMobileE = null) =>
            new()
            {
                Lemma = lemma,
                Pattern = pattern,
                WordCategory = WordCategory.Noun,
                Gender = gender,
                Case = @case,
                Number = number,
                HasMobileE = hasMobileE
            };

        #endregion Helpers

        // -------------------------------------------------------------------------

        #region Test data attributes

        /// <summary>
        /// Provides zena ka suffix data attribute behavior.
        /// </summary>
        private sealed class ZenaKaSuffixDataAttribute : TestAttributeBase
        {
            /// <summary>
            /// Provides data rows for a parameterized MSTest method.
            /// </summary>
            /// <param name="methodInfo">The test method requesting data.</param>
            /// <returns>The test data rows for the requested method.</returns>
            public override IEnumerable<object?[]> GetData(MethodInfo methodInfo) =>
            [
                ["studentka", "student", "k"],
                ["matka",     "mat",     "k"],
                ["babka",     "bab",     "k"],
            ];
        }

        /// <summary>
        /// Provides mesto epenthesis data attribute behavior.
        /// </summary>
        private sealed class MestoEpenthesisDataAttribute : TestAttributeBase
        {
            /// <summary>
            /// Provides data rows for a parameterized MSTest method.
            /// </summary>
            /// <param name="methodInfo">The test method requesting data.</param>
            /// <returns>The test data rows for the requested method.</returns>
            public override IEnumerable<object?[]> GetData(MethodInfo methodInfo) =>
            [
                ["jablko", "jabl", "k"],  // l+k  Alveolar+Velar
                ["okno",   "ok",   "n"],  // k+n  Velar+Alveolar
                ["peklo",  "pek",  "l"],  // k+l  Velar+Alveolar
                ["vlákno", "vlák", "n"],  // k+n  Velar+Alveolar
            ];
        }

        #endregion Test data attributes
    }
}
