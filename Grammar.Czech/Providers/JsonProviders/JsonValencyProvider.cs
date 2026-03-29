using Grammar.Core.Helpers;
using Grammar.Core.Interfaces;
using Grammar.Core.Models.Valency;
using Grammar.Czech.Helpers;
using Grammar.Czech.Models;
using System.Reflection;

namespace Grammar.Czech.Providers.JsonProviders
{
    /// <summary>
    /// Loads lexical entries and valency frames from embedded JSON resources and
    /// implements <see cref="IValencyProvider"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Two separate files are loaded:
    /// <list type="bullet">
    ///   <item><c>Data/Valency/lexicon.json</c> — morphological metadata for all lemmata.</item>
    ///   <item><c>Data/Valency/valency.json</c> — valency frames keyed by verb lemma.</item>
    /// </list>
    /// </para>
    /// <para>
    /// Both files are loaded exactly once via a thread-safe <see cref="Lazy{T}"/>.
    /// When the project migrates to SQLite, replace this class with a
    /// <c>SqliteValencyProvider</c> and update only the DI registration.
    /// </para>
    /// </remarks>
    public sealed class JsonValencyProvider : IValencyProvider<CzechLexicalEntry>
    {
        private readonly string _lexiconPath = "Data.Valency.lexicon";
        private readonly string _valencyPath = "Data.Valency.valency";

        private readonly Lazy<Dictionary<string, CzechLexicalEntry>> _lexicon;
        private readonly Lazy<Dictionary<string, List<ValencyFrame>>> _frames;

        /// <summary>
        /// Initializes a new instance of <see cref="JsonValencyProvider"/> and sets up
        /// lazy loading from the embedded JSON resources.
        /// </summary>
        public JsonValencyProvider()
        {
            var assembly = Assembly.GetExecutingAssembly();

            _lexicon = new Lazy<Dictionary<string, CzechLexicalEntry>>(
                () => LoadLexicon(assembly),
                LazyThreadSafetyMode.ExecutionAndPublication);

            _frames = new Lazy<Dictionary<string, List<ValencyFrame>>>(
                () => LoadFrames(assembly),
                LazyThreadSafetyMode.ExecutionAndPublication);
        }

        /// <inheritdoc/>
        public CzechLexicalEntry? GetEntry(string lemma)
            => _lexicon.Value.TryGetValue(lemma.ToLowerInvariant(), out var entry)
                ? entry
                : null;

        /// <inheritdoc/>
        public IEnumerable<ValencyFrame> GetFrames(string verbLemma)
            => _frames.Value.TryGetValue(verbLemma.ToLowerInvariant(), out var frames)
                ? frames
                : [];

        /// <inheritdoc/>
        public bool HasEntry(string lemma)
            => _lexicon.Value.ContainsKey(lemma.ToLowerInvariant());

        private static Dictionary<string, CzechLexicalEntry> LoadLexicon(Assembly assembly)
            => JsonLoader.LoadDictionaryFromFile<CzechLexicalEntry>(
                assembly, "Data.Valency.lexicon", JsonHelpers.SerializerOptions)
               ?? [];

        private static Dictionary<string, List<ValencyFrame>> LoadFrames(Assembly assembly)
            => JsonLoader.LoadDictionaryFromFile<List<ValencyFrame>>(
                assembly, "Data.Valency.valency", JsonHelpers.SerializerOptions)
               ?? [];
    }
}
