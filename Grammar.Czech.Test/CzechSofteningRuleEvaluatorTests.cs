using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using Grammar.Czech.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Czech.Test
{
    [TestClass]
    public class CzechSofteningRuleEvaluatorTests
    {
        private ISofteningRuleEvaluator<CzechWordRequest> softeningRuleEvaluator;
        [TestInitialize]
        public void Setup()
        {
            softeningRuleEvaluator = new CzechSofteningRuleEvaluator();
        }

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
            var result = softeningRuleEvaluator.GetEndingTransformation(request);
            Assert.AreEqual("-e", result);
        }

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
            var result = softeningRuleEvaluator.GetEndingTransformation(request);
            Assert.AreEqual("-e", result);
        }

        [TestMethod]
        public void GetEndingTransformation_ShouldReturnEk_ForHolkaGenitivePlural()
        {
            var request = new CzechWordRequest
            {
                Lemma = "holka",
                Pattern = "žena",
                WordCategory = WordCategory.Noun,
                Number = Number.Plural,
                Case = Case.Genitive
            };
            var result = softeningRuleEvaluator.GetEndingTransformation(request);
            Assert.AreEqual("-ek", result);
        }

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
            var result = softeningRuleEvaluator.ShouldApplySoftening(request);
            Assert.IsFalse(result);
        }

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
            var result = softeningRuleEvaluator.GetEndingTransformation(request);
            Assert.IsNull(result);
        }

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
            var result = softeningRuleEvaluator.ShouldApplySoftening(request);
            Assert.IsFalse(result);
        }

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
            var result = softeningRuleEvaluator.ShouldApplySoftening(request);
            Assert.IsTrue(result);
        }
    }
}
