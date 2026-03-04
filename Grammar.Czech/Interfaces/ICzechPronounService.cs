using Grammar.Core.Enums;

namespace Grammar.Czech.Interfaces
{
    public interface ICzechPronounService
    {
        /// <summary>
        /// Vrací tvar zájmena v daném pádu. Pokud není k dispozici, vrátí null.
        /// </summary>
        string? TryGetForm(string baseForm, Case grammaticalCase);

        /// <summary>
        /// Vrací všechny dostupné pády pro dané zájmeno (např. „já“ → 1., 2., 3., ...)
        /// </summary>
        IEnumerable<Case> GetAvailableCases(string baseForm);

        /// <summary>
        /// Vrací true, pokud daná kombinace zájmena a pádu existuje.
        /// </summary>
        bool IsAllowed(string baseForm, Case grammaticalCase);

        /// <summary>
        /// Vrací typ zájmena (Personal, Possessive, Demonstrative, ...)
        /// </summary>
        PronounType? GetPronounType(string baseForm);
    }
}
