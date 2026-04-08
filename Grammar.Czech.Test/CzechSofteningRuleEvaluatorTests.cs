using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using Grammar.Czech.Services;

namespace Grammar.Czech.Test
{
    /// <summary>
    /// Verifies czech softening rule evaluator behavior.
    /// </summary>
    [TestClass]
    public class CzechSofteningRuleEvaluatorTests
    {
        private ISofteningRuleEvaluator<CzechWordRequest> softeningRuleEvaluator;

        /// <summary>
        /// Creates the test subject and its dependencies.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            softeningRuleEvaluator = new CzechSofteningRuleEvaluator();
        }

        /// <summary>
        /// Gets ending transformation should return e for holka dative singular.
        /// </summary>
        [TestMethod]
        public void GetEndingTransformation_ShouldReturnE_ForHolkaDativeSingular()
        {
            var request = new CzechWordRequest
            {
                Lemma = "holka",
                Pattern = "žena",
                WordCategory = WordCategory.Noun,
                Number = Number.Singular,
                Case = Case.Dative
            };
            var result = softeningRuleEvaluator.GetEndingTransformation(request, out _);
            Assert.AreEqual("-e", result);
        }

        /// <summary>
        /// Gets ending transformation should return e for holka locative singular.
        /// </summary>
        [TestMethod]
        public void GetEndingTransformation_ShouldReturnE_ForHolkaLocativeSingular()
        {
            var request = new CzechWordRequest
            {
                Lemma = "holka",
                Pattern = "žena",
                WordCategory = WordCategory.Noun,
                Number = Number.Singular,
                Case = Case.Locative
            };
            var result = softeningRuleEvaluator.GetEndingTransformation(request, out _);
            Assert.AreEqual("-e", result);
        }

        /// <summary>
        /// Determines whether should apply softening should return false for holka genitive plural.
        /// </summary>
        [TestMethod]
        public void ShouldApplySoftening_ShouldReturnFalse_ForHolkaGenitivePlural()
        {
            var request = new CzechWordRequest
            {
                Lemma = "holka",
                Pattern = "žena",
                WordCategory = WordCategory.Noun,
                Number = Number.Plural,
                Case = Case.Genitive
            };
            var result = softeningRuleEvaluator.ShouldApplySoftening(request, out _);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Gets ending transformation should return null for holka nominative singular.
        /// </summary>
        [TestMethod]
        public void GetEndingTransformation_ShouldReturnNull_ForHolkaNominativeSingular()
        {
            var request = new CzechWordRequest
            {
                Lemma = "holka",
                Pattern = "žena",
                WordCategory = WordCategory.Noun,
                Number = Number.Singular,
                Case = Case.Nominative
            };
            var result = softeningRuleEvaluator.GetEndingTransformation(request, out _);
            Assert.IsNull(result);
        }

        /// <summary>
        /// Determines whether should apply softening should return false for holka nominative singular.
        /// </summary>
        [TestMethod]
        public void ShouldApplySoftening_ShouldReturnFalse_ForHolkaNominativeSingular()
        {
            var request = new CzechWordRequest
            {
                Lemma = "holka",
                Pattern = "žena",
                WordCategory = WordCategory.Noun,
                Number = Number.Singular,
                Case = Case.Nominative
            };
            var result = softeningRuleEvaluator.ShouldApplySoftening(request, out _);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Determines whether should apply softening should return true for holka dative singular.
        /// </summary>
        [TestMethod]
        public void ShouldApplySoftening_ShouldReturnTrue_ForHolkaDativeSingular()
        {
            var request = new CzechWordRequest
            {
                Lemma = "holka",
                Pattern = "žena",
                WordCategory = WordCategory.Noun,
                Number = Number.Singular,
                Case = Case.Dative
            };
            var result = softeningRuleEvaluator.ShouldApplySoftening(request, out _);
            Assert.IsTrue(result);
        }
    }
}
