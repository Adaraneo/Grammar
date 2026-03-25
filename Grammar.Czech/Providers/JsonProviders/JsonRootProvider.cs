using Grammar.Core.Helpers;
using Grammar.Core.Models.Derivation;
using Grammar.Czech.Helpers;
using Grammar.Czech.Interfaces;
using Grammar.Czech.Models.Derivation;
using System.Reflection;

namespace Grammar.Czech.Providers.JsonProviders
{
    /// <summary>
    /// Loads Czech root entries from the embedded <c>Data/Roots/roots.json</c> resource
    /// and implements <see cref="ICzechRootProvider"/>.
    /// </summary>
    /// <remarks>
    /// The data is loaded once on first access via a thread-safe <see cref="Lazy{T}"/>.
    /// The <c>IRootProvider</c> methods map <see cref="CzechRootEntry"/> to the
    /// language-agnostic <see cref="RootEntry"/> type for callers that only depend
    /// on <c>Grammar.Core</c>.
    /// </remarks>
    public class JsonRootProvider : ICzechRootProvider
    {
        private readonly string _rootsPath = "Data.Lexicon.roots";
        private readonly Lazy<Dictionary<string, CzechRootEntry>> _roots;

        /// <summary>
        /// Initializes a new instance of <see cref="JsonRootProvider"/> and sets up
        /// lazy loading from the embedded JSON resource.
        /// </summary>
        public JsonRootProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _roots = new Lazy<Dictionary<string, CzechRootEntry>>(
                () => JsonLoader.LoadDictionaryFromFile<CzechRootEntry>(
                    assembly, _rootsPath, JsonHelpers.SerializerOptions)!,
                LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <inheritdoc/>
        public CzechRootEntry? GetCzechByRoot(string root)
            => _roots.Value.TryGetValue(root.ToLowerInvariant(), out var entry) ? entry : null;

        /// <inheritdoc/>
        public CzechRootEntry? GetCzechByLemma(string lemma)
            => _roots.Value.Values.FirstOrDefault(
                e => e.Derivations.Any(
                    d => d.Lemma.Equals(lemma, StringComparison.OrdinalIgnoreCase)));

        /// <inheritdoc/>
        public RootEntry? GetByRoot(string root)
            => MapToCore(GetCzechByRoot(root));

        /// <inheritdoc/>
        public RootEntry? GetByLemma(string lemma)
            => MapToCore(GetCzechByLemma(lemma));

        private static RootEntry? MapToCore(CzechRootEntry? czech)
        {
            if (czech is null)
            {
                return null;
            }

            return new RootEntry
            {
                Root = czech.Root,
                Derivations = czech.Derivations
            };
        }
    }
}
