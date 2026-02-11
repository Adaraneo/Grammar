namespace Grammar.Czech.Models
{
    public sealed record AdjectivePattern
    {
        public IReadOnlyDictionary<string, IReadOnlyDictionary<string, List<string>>> Endings { get; init; }
        /// <summary>
        /// Hard, soft or possessive
        /// </summary>
        public string Type { get; init; }
    }
}