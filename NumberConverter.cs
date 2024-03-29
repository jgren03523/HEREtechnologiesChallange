using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEREtechnologiesChallange
{

    class NumberConverter
    {
        private static readonly Dictionary<string, int> numberMap = new Dictionary<string, int>
    {
        // Units
        {"jeden", 1}, {"dwa", 2}, {"trzy", 3}, {"cztery", 4},
        {"piec", 5}, {"szesc", 6}, {"siedem", 7}, {"osiem", 8}, {"dziewiec", 9},
        // Teens
        {"dziesiec", 10}, {"jedenascie", 11}, {"dwanascie", 12}, {"trzynascie", 13}, {"czternascie", 14},
        {"pietnascie", 15}, {"szesnascie", 16}, {"siedemnascie", 17}, {"osiemnascie", 18}, {"dziewietnascie", 19},
        // Tens
        {"dwadziescia", 20}, {"trzydziesci", 30}, {"czterdziesci", 40}, {"piecdziesiat", 50},
        {"szescdziesiat", 60}, {"siedemdziesiat", 70}, {"osiemdziesiat", 80}, {"dziewiecdziesiat", 90},
        // Hundreds
        {"sto", 100}, {"dwiescie", 200}, {"trzysta", 300}, {"czterysta", 400},
        {"piecset", 500}, {"szescset", 600}, {"siedemset", 700}, {"osiemset", 800}, {"dziewiecset", 900},
    };

        private static int ConvertTextToNumber(string text)
        {
            int result = 0;
            int temporarySum = 0;
            string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                // Check and apply thousands multiplier if applicable
                if (part.EndsWith("tysiace") || part.Equals("tysiac") || part.Equals("tysiecy"))
                {
                    // Handle "tysiace" separately, multiplying the current temporary sum
                    result += temporarySum * 1000;
                    temporarySum = 0; // Reset after moving to the next magnitude
                }
                else if (numberMap.TryGetValue(part, out var number))
                {
                    temporarySum += number;
                }
            }

            result += temporarySum; // Add any remaining amount that didn't end in "tysiace"

            return result;
        }

        static void Main()
        {
            Console.WriteLine("Please enter a number in text form (range 0 - 9999, without Polish characters):");
            string input = Console.ReadLine().ToLower().Trim();
            int number = ConvertTextToNumber(input);
            Console.WriteLine($"Converted Number: {number}");
        }
    }
}