using Grammar.Core.Enums;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using Grammar.Czech.Providers;
using Grammar.Czech.Services;

namespace Grammar.Czech.Test
{
    [TestClass]
    public class CzechEpenthesisRuleEvaluatorTests
    {
        private IEpenthesisRuleEvaluator<CzechWordRequest> evaluator;

        [TestInitialize]
        public void Setup()
        {
            var registry = new CzechPhonemeRegistry();
            this.evaluator = new CzechEpenthesisRuleEvaluator(registry);
        }

        [TestMethod]
        public void ShouldApplyEpenthesis_MatkaStudentkaGenPl_ReturnsTrue()
        {
            var matkaRequest = new CzechWordRequest
            {
                Lemma = "matka",
                WordCategory = WordCategory.Noun,
                Number = Number.Plural,
                Case = Case.Genitive,
                Gender = Gender.Feminine,
                Pattern = "žena"
            };

            var studentkaRequest = new CzechWordRequest
            {
                Lemma = "studentka",
                WordCategory = WordCategory.Noun,
                Number = Number.Plural,
                Case = Case.Genitive,
                Gender = Gender.Feminine,
                Pattern = "žena"
            };

            var result = evaluator.ShouldApplyEpenthesis("mat", "k", matkaRequest);
            Assert.IsTrue(result);
            result = evaluator.ShouldApplyEpenthesis("student", "k", studentkaRequest);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldApplyEpenthesis_MatkaStudentkaGenSg_ReturnsFalse()
        {
            var matkaRequest = new CzechWordRequest
            {
                Lemma = "matka",
                WordCategory = WordCategory.Noun,
                Number = Number.Singular,
                Case = Case.Genitive,
                Gender = Gender.Feminine,
                Pattern = "žena"
            };

            var studentkaRequest = new CzechWordRequest
            {
                Lemma = "studentka",
                WordCategory = WordCategory.Noun,
                Number = Number.Singular,
                Case = Case.Genitive,
                Gender = Gender.Feminine,
                Pattern = "žena"
            };

            var result = evaluator.ShouldApplyEpenthesis("mat", "k", matkaRequest);
            Assert.IsFalse(result);
            result = evaluator.ShouldApplyEpenthesis("student", "k", studentkaRequest);
            Assert.IsFalse(result);
        }
    }
}