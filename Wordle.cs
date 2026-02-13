using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
class Wordle
{
    private string? words;
    private string comp = "";

    public string randomInput()
    {
        Random random = new Random();
        int number = random.Next(0, 51);
        string path = "words.txt";
        string[] words = File.ReadAllLines(path);
        comp += words[number].ToLower();
        return comp;

    }

    public bool validate(string input)
    {
        string path = "words.txt"; // File name (same folder as program)

        if (File.Exists(path))
        {
            string[] words = File.ReadAllLines(path);
            foreach (string word in words)
            {
                if (word.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        else { return false; }

    }

    public void calculate(string input)
    {
        
        for (int i = 0; i < input.Length; i++)
        {
            bool found = false;
            if (comp[i] == input[i])
            {
                Console.WriteLine("Green " + comp[i]);
            }
            else
            {
                for (int j = 0; j < input.Length; j++)
                {
                    
                    if (input[i] != comp[j])
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Yellow " + comp[j]);
                        found = true;   
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Grey");
                }
            }
        }

    }
}
class Program
{
    static void Main()
    {

        Wordle w1 = new Wordle();
        Console.WriteLine("Enter a word: ");
        string? word = Console.ReadLine();
        Console.WriteLine(w1.randomInput());

        if (word != null && w1.validate(word))
        {
            // Program will continue
        }
        else { Console.WriteLine("galat"); }
        // Selction of a random word

        // Validation() Word h ya nahi
        // calculation() Conditions check
        //

        w1.calculate(word);
    }


}