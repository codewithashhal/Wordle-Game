using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;
class Wordle
{
    private string? words;

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
        else {return false;}
        
    }
}
class Program
{
    static void Main()
    {
        Wordle w1 = new Wordle();
        Console.WriteLine("Enter a word: ");
        string? word = Console.ReadLine();

        if (word != null && w1.validate(word))
        {
        // Program will continue
        }
        else{Console.WriteLine("galat");}
            // Selction of a random word
            
            // Validation() Word h ya nahi
            // calculation() Conditions check
            // 
        }
}