using System;
using System.IO;

namespace wordle
{

    abstract class WordleBank      
    {
        private Random random = new Random(); 
        protected string[] words;
        protected string comp;

        // 3. CONSTRUCTOR CHAINING — default ctor chained ctor ko call karta hai
        

        public WordleBank()
        {
            // FILE  HANDLING !!!!

            if (File.Exists("alfaz.txt"))
                words = File.ReadAllLines("alfaz.txt");
            else
                words = new string[] { "apple", "bread", "cloud" };
        }

        public string GetRandomWord()
        {
            if (words == null || words.Length == 0)
                return "apple";

            int number = random.Next(0, words.Length);
            comp = words[number].ToLower();
            return comp;
        }

        // 4. ABSTRACT METHOD — har child class apna DisplayInfo degi
        public abstract void DisplayInfo();
    }

    class WordValidator : WordleBank
    {
        public WordValidator(string secretWord)
        {
            comp = secretWord;
        }

        public bool Validate(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 5)
                return false;

            foreach (char x in input)
                if (!char.IsLetter(x))
                    return false;

            return true;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("[WordValidator] Validates 5 letter alphabetic input.");
        }
    }

    // Wordle.cs mein WordleBank class ke baad add karo
    class WordPicker : WordleBank
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("[WordPicker] Loads words and picks randomly.");
        }
    }

    class Calculation : WordleBank
    {
        public Calculation(string secretWord)
        {
            comp = secretWord;
        }

        public string[] Calculate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new string[0];

            input = input.ToLower();
            string[] result = new string[5];
            int[] count = new int[26];

            for (int i = 0; i < 5; i++)
                count[comp[i] - 'a']++;

            for (int i = 0; i < 5; i++)
            {
                if (input[i] == comp[i])
                {
                    result[i] = "Green";
                    count[input[i] - 'a']--;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (result[i] == "Green") continue;
                // Input ka index count k array mein 1 h to yellow warna gray
                int index = input[i] - 'a';
                if (count[index] > 0)
                {
                    result[i] = "Yellow";
                    count[index]--;
                }
                else
                {
                    result[i] = "Grey";
                }
            }

            return result;
        }

        public string GetHint(int value)
        {
            return $"Hint: Position {value + 1} is '{char.ToUpper(comp[value])}'.";
        }   

        public bool CheckVictory(string[] result)
        {
            int cnt = 0;
            foreach (string color in result)
                if (color == "Green") 
                {
                    cnt++;}

            return (cnt == result.Length && result.Length > 0);
        }

        // Abstract method ka implementation
        public override void DisplayInfo()
        {
            Console.WriteLine("[Calculation] Computes Green/Yellow/Grey feedback.");
        }

    }
}
