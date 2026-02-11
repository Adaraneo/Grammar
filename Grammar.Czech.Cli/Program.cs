namespace Grammar.Cli
{
    using Grammar.Core.Enums;
    using Grammar.Czech;
    using Grammar.Czech.Models;
    using Grammar.Czech.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string dataPath = configuration["DataPath"] ?? throw new InvalidOperationException("Missing DataPath in configuration!");

            var services = new ServiceCollection();
            services.AddCzechGrammarServices(dataPath);

            var provider = services.BuildServiceProvider(new ServiceProviderOptions() { ValidateOnBuild = true });
            var engine = provider.GetRequiredService<MorphologyEngine>();
            var composer = provider.GetRequiredService<CzechWordFormComposer>();

            var studentRequest = new CzechWordRequest
            {
                Lemma = "student",
                WordCategory = WordCategory.Noun,
                Gender = Gender.Masculine,
                Number = Number.Singular,
                Pattern = "pán",
                IsAnimate = true
            };

            var studentkaRequest = new CzechWordRequest
            {
                Lemma = "studentka",
                WordCategory = WordCategory.Noun,
                Gender = Gender.Feminine,
                Number = Number.Singular,
                Pattern = "žena",
            };

            var womanRequest = new CzechWordRequest
            {
                Lemma = "žena",
                WordCategory = WordCategory.Noun,
                Gender = Gender.Feminine,
                Number = Number.Singular,
                Pattern = "žena",
            };

            PrintNounForms(composer, studentRequest);
            PrintNounForms(composer, studentkaRequest);
            PrintNounForms(composer, womanRequest);

            var doRequest = new CzechWordRequest
            {
                Lemma = "dělat",
                WordCategory = WordCategory.Verb,
                Gender = Gender.Masculine,
                Aspect = VerbAspect.Imperfective,
                Pattern = "dělá",
            };

            var carryRequest = new CzechWordRequest
            {
                Lemma = "nést",
                WordCategory = WordCategory.Verb,
                Gender = Gender.Masculine,
                Aspect = VerbAspect.Imperfective,
                Pattern = "nese",
            };

            PrintVerbForms(composer, doRequest);
            PrintVerbForms(composer, carryRequest);

            var negativeCarryRequest = new CzechWordRequest
            {
                Lemma = carryRequest.Lemma,
                WordCategory = carryRequest.WordCategory,
                Gender = carryRequest.Gender,
                Aspect = carryRequest.Aspect,
                Pattern = carryRequest.Pattern,
                IsNegative = true,
            };

            PrintVerbForms(composer, negativeCarryRequest);

            var meRequest = new CzechWordRequest
            {
                Lemma = "já",
                WordCategory = WordCategory.Pronoun,
            };

            var sheRequest = new CzechWordRequest
            {
                Lemma = "ona",
                WordCategory = WordCategory.Pronoun,
            };

            var theyRequest = new CzechWordRequest
            {
                Lemma = "ona_",
                WordCategory = WordCategory.Pronoun,
            };

            var myRequest = new CzechWordRequest
            {
                Lemma = "můj",
                WordCategory = WordCategory.Pronoun,
            };

            PrintPronounForms(engine, meRequest);
            PrintPronounForms(engine, sheRequest);
            PrintPronounForms(engine, theyRequest);
            PrintPronounForms(engine, myRequest);
        }

        private static void PrintWordInfo(CzechWordRequest request)
        {
            Console.WriteLine("{0}:", request.Lemma.Trim('_'));
        }

        private static void PrintNounForms(CzechWordFormComposer composer, CzechWordRequest request)
        {
            PrintWordInfo(request);
            foreach (var cNumber in Enum.GetValues<Number>())
            {
                Console.WriteLine("\t{0}:", cNumber.ToString().ToLowerInvariant());
                foreach (var cCase in Enum.GetValues<Case>())
                {
                    request.Number = cNumber;
                    request.Case = cCase;
                    var result = composer.GetFullForm(request);
                    Console.WriteLine($"\t\t{cCase}: {result.Form}");
                }
            }
        }

        private static void PrintVerbForms(CzechWordFormComposer composer, CzechWordRequest request, Modus modus = Modus.Conjuctive)
        {
            PrintWordInfo(request);
            foreach (var cTense in Enum.GetValues<Tense>())
            {
                foreach (var cNumber in Enum.GetValues<Number>())
                {
                    foreach (var cPerson in Enum.GetValues<Person>())
                    {
                        request.Tense = cTense;
                        request.Number = cNumber;
                        request.Person = cPerson;
                        request.Modus = modus;
                        var result = composer.GetFullForm(request);
                        Console.WriteLine("\t({1};{2};{3};{4};{5};{6}): {0}", result.Form, request.Tense, request.Number, request.Person, request.Modus, request.Gender, request.Aspect);
                    }
                }
            }
        }

        private static void PrintPronounForms(MorphologyEngine engine, CzechWordRequest request)
        {
            PrintWordInfo(request);
            foreach (var cCase in Enum.GetValues<Case>())
            {
                if (cCase == Case.Vocative)
                {
                    continue;
                }

                request.Case = cCase;
                var result = engine.GetForm(request);
                Console.WriteLine("\t{1}: {0}", result.Form, cCase);
            }
        }
    }
}
