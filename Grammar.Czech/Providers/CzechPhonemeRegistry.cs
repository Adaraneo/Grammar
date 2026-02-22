using Grammar.Core.Interfaces;
using Grammar.Core.Models.Phonology;
using Grammar.Core.Enums.PhonologicalFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar.Czech.Providers
{
    public sealed class CzechPhonemeRegistry : IPhonemeRegistry
    {
        private static readonly Dictionary<string, Phoneme> _phonemes = BuildRegistry();
        private static Dictionary<string, Phoneme> BuildRegistry() => new()
        {
            ["p"] = new Phoneme { Symbol = "p", Place = ArticulationPlace.Bilabial, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiceless, VoicedCounterpart = "b" },
            ["b"] = new Phoneme { Symbol = "b", Place = ArticulationPlace.Bilabial, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiced, VoicelessCounterpart = "p" },
            ["f"] = new Phoneme { Symbol = "f", Place = ArticulationPlace.Labiodental, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiceless, VoicedCounterpart = "v" },
            ["v"] = new Phoneme { Symbol = "v", Place = ArticulationPlace.Labiodental, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiced, VoicelessCounterpart = "f" },
            ["m"] = new Phoneme { Symbol = "m", Place = ArticulationPlace.Bilabial, Manner = ArticulationManner.Nasal },
            ["t"] = new Phoneme { Symbol = "t", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiceless, VoicedCounterpart = "d", PalatalizeTo = "ť" },
            ["d"] = new Phoneme { Symbol = "d", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiced, VoicelessCounterpart = "t", PalatalizeTo = "ď" },
            ["s"] = new Phoneme { Symbol = "s", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiceless, VoicedCounterpart = "z" },
            ["z"] = new Phoneme { Symbol = "z", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiced, VoicelessCounterpart = "s" },
            ["n"] = new Phoneme { Symbol = "n", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Nasal, PalatalizeTo = "ň" },
            ["c"] = new Phoneme { Symbol = "c", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Affricate, Voicing = Voicing.Voiceless, PalatalizeTo = "č" },
            ["č"] = new Phoneme { Symbol = "č", Place = ArticulationPlace.Palatal, Manner = ArticulationManner.Affricate, Voicing = Voicing.Voiceless },
            ["ť"] = new Phoneme { Symbol = "ť", Place = ArticulationPlace.Palatal, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiceless },
            ["ď"] = new Phoneme { Symbol = "ď", Place = ArticulationPlace.Palatal, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiced },
            ["š"] = new Phoneme { Symbol = "š", Place = ArticulationPlace.Palatal, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiceless, VoicedCounterpart = "ž" },
            ["ž"] = new Phoneme { Symbol = "ž", Place = ArticulationPlace.Palatal, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiced, VoicelessCounterpart = "š" },
            ["ň"] = new Phoneme { Symbol = "ň", Place = ArticulationPlace.Palatal, Manner = ArticulationManner.Nasal },
            ["k"] = new Phoneme { Symbol = "k", Place = ArticulationPlace.Velar, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiceless, VoicedCounterpart = "g", PalatalizeTo = "c" },
            ["g"] = new Phoneme { Symbol = "g", Place = ArticulationPlace.Velar, Manner = ArticulationManner.Plosive, Voicing = Voicing.Voiced, VoicelessCounterpart = "k" },
            ["ch"] = new Phoneme { Symbol = "ch", Place = ArticulationPlace.Velar, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiceless, VoicedCounterpart = "h", PalatalizeTo = "š" },
            ["h"] = new Phoneme { Symbol = "h", Place = ArticulationPlace.Velar, Manner = ArticulationManner.Fricative, Voicing = Voicing.Voiced, VoicelessCounterpart = "ch", PalatalizeTo = "z" },
            ["j"] = new Phoneme { Symbol = "j", Place = ArticulationPlace.Palatal, Manner = ArticulationManner.Approximant },
            ["ř"] = new Phoneme { Symbol = "ř", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Trill },
            ["r"] = new Phoneme { Symbol = "r", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.Trill, PalatalizeTo = "ř" },
            ["l"] = new Phoneme { Symbol = "l", Place = ArticulationPlace.Alveolar, Manner = ArticulationManner.LateralApproximant },
            ["a"] = new Phoneme { Symbol = "a", Backness = VowelBackness.Central, Height = VowelHeight.Open, IsRounded = false },
            ["e"] = new Phoneme { Symbol = "e", Backness = VowelBackness.Front, Height = VowelHeight.Mid, IsRounded = false },
            ["i"] = new Phoneme { Symbol = "i", Backness = VowelBackness.Front, Height = VowelHeight.Close, IsRounded = false },
            ["y"] = new Phoneme { Symbol = "y", Backness = VowelBackness.Front, Height = VowelHeight.Close, IsRounded = false },
            ["o"] = new Phoneme { Symbol = "o", Backness = VowelBackness.Back, Height = VowelHeight.Mid, IsRounded = true },
            ["u"] = new Phoneme { Symbol = "u", Backness = VowelBackness.Back, Height = VowelHeight.Close, IsRounded = true },
            ["ě"] = new Phoneme { Symbol = "ě", Backness = VowelBackness.Front, Height = VowelHeight.Mid, IsRounded = false },
            ["á"] = new Phoneme { Symbol = "á", Backness = VowelBackness.Central, Height = VowelHeight.Open, IsRounded = false },
            ["é"] = new Phoneme { Symbol = "é", Backness = VowelBackness.Front, Height = VowelHeight.Mid, IsRounded = false },
            ["í"] = new Phoneme { Symbol = "í", Backness = VowelBackness.Front, Height = VowelHeight.Close, IsRounded = false },
            ["ý"] = new Phoneme { Symbol = "ý", Backness = VowelBackness.Front, Height = VowelHeight.Close, IsRounded = false },
            ["ó"] = new Phoneme { Symbol = "ó", Backness = VowelBackness.Back, Height = VowelHeight.Mid, IsRounded = true },
            ["ú"] = new Phoneme { Symbol = "ú", Backness = VowelBackness.Back, Height = VowelHeight.Close, IsRounded = true },
            ["ů"] = new Phoneme { Symbol = "ů", Backness = VowelBackness.Back, Height = VowelHeight.Close, IsRounded = true },
            ["ou"] = new Phoneme { Symbol = "ou", Backness = VowelBackness.Back },
            ["eu"] = new Phoneme { Symbol = "eu", Backness = VowelBackness.Front },
            ["au"] = new Phoneme { Symbol = "au", Backness = VowelBackness.Central }
        };

        public IReadOnlyCollection<Phoneme> AllPhonemes => throw new NotImplementedException();

        public Phoneme? Get(string symbol)
        {
            throw new NotImplementedException();
        }

        public bool IsVowel(char c)
        {
            throw new NotImplementedException();
        }

        public bool IsConsonant(char c)
        {
            throw new NotImplementedException();
        }

        public bool IsFrontVowel(char c)
        {
            throw new NotImplementedException();
        }
    }
}
