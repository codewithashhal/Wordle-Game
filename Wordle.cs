using System;
// using System.ComponentModel.DataAnnotations;
// using System.Runtime.InteropServices.Marshalling;
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
        string path = "words.txt"; 
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
        int [] count=new int[26];

        for(int i = 0; i < comp.Length; i++)
        {
            int index = comp[i] - 'a';
            count[index]++;
        }
        
        string[] result = new string[input.Length];

        for (int i = 0 ; i < input.Length; i++)
        {
            if (comp[i] == input[i])
            {
                result[i] = "Green";
                count[input[i] - 'a']--;
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
}