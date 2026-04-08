using Grammar.Core.Helpers;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models;
using Grammar.Czech.Models.Grammar.Czech.Models;
using System.Reflection;

namespace Grammar.Czech.Providers.JsonProviders
{
    /// <summary>
    /// Loads pronoun data provider from embedded JSON resources.
    /// </summary>
    public class JsonPronounDataProvider : IPronounDataProvider
    {
        private readonly string _pronounPath = "Data.Rules.Pronouns.patterns";
        private readonly string _paradigmsPath = "Data.Rules.Pronouns.paradigms";
        private readonly Lazy<Dictionary<string, PronounData>> _pronouns;
        private readonly Lazy<Dictionary<string, PronounParadigm>> _paradigms;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonPronounDataProvider"/> type.
        /// </summary>
        public JsonPronounDataProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _pronouns = new Lazy<Dictionary<string, PronounData>>(() => JsonLoader.LoadDictionaryFromFile<PronounData>(assembly, _pronounPath, JsonHelpers.SerializerOptions)!);
            _paradigms = new Lazy<Dictionary<string, PronounParadigm>>(() => JsonLoader.LoadDictionaryFromFile<PronounParadigm>(assembly, _paradigmsPath, JsonHelpers.SerializerOptions)!);
        }

        /// <summary>
        /// Gets Czech pronoun paradigms loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded pronoun paradigms keyed by paradigm identifier.</returns>
        public Dictionary<string, PronounParadigm> GetParadigms() => _paradigms.Value;

        /// <summary>
        /// Gets Czech pronoun entries loaded from embedded JSON data.
        /// </summary>
        /// <returns>The loaded pronoun metadata keyed by lemma.</returns>
        public Dictionary<string, PronounData> GetPronouns() => _pronouns.Value;
    }
}
