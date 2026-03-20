
namespace Grammar.Core.Models.Word
{
    public sealed class WordStructure
    {
        public string? Prefix { get; set; }
        public string Root { get; set; } = string.Empty;
        public string? DerivationSuffix { get; set; }

        public override string ToString() => $"{Prefix}{Root}{DerivationSuffix}";
    }
}
