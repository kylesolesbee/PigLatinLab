//Kyle Solesbee 10/5/23
//Pig Latin Lab

using System.Globalization;

namespace PigLatinLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            string word = GetUserInput("Please input a word to translate to pig Latin");

            bool hasVowel = HasVowel(word);

            if (hasVowel)
            {
                int first = FindFirstVowel(word);

                if (first == 0)
                {
                    word += "way";
                }
                else
                {
                    bool startWithUpper = char.IsUpper(word[0]);

                    string postFix = word.Substring(0, first).ToLower();
                    string preFix = word.Substring(first);

                    if (startWithUpper)
                    {
                        preFix = new CultureInfo("en-us", false).TextInfo.ToTitleCase(preFix);
                    }

                    word = preFix + postFix + "ay";
                }

                Console.WriteLine(word);
            }
            else
            {
                Console.WriteLine($"{word} cannot be translated into pig Latin");
            }
        }

        public static int FindFirstVowel(string word)
        {
            string[] vowels = { "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            char[] letters = word.ToCharArray();

            int i = 0;
            foreach (char let in letters)
            {
                if (vowels.Contains(let.ToString()))
                {
                    return i;
                }
                else
                {
                    i++;
                }
            }

            return -1;
        }

        public static bool HasVowel(string word)
        {
            string[] vowels = { "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };
            for (int i = 0; i < vowels.Length; i++)
            {
                string v = vowels[i];
                if (word.Contains(v))
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;

            //string translation;
            //string word;

            //Console.WriteLine("Enter a sentence: ");
            //word = Console.ReadLine();
            //translation = PigLatinTranslation(word);

            //return translation;
            //I was doing this a harder way but realized how much harder I truly was making it. 

        }
    }
}