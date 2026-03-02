using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

class Wordle
{
    private string[] words;
    private string comp = "";
    private Random random = new Random();

    public Wordle()
    {
        if (File.Exists("words.txt"))
            words = File.ReadAllLines("words.txt");
    }

    public void randomInput()
    {
        int number = random.Next(0, words.Length);
        comp = words[number].ToLower();
    }

    public bool validate(string input)
    {
        if (input.Length != 5 || string.IsNullOrEmpty(input)) return false;

        foreach (char x in input) {
            if (!char.IsLetter(x)) return false;
        }
        return true;
    }

    public string[] calculate(string input)
    {
        if (string.IsNullOrEmpty(input)) return [];

        input = input.ToLower();
        comp = comp.ToLower();

        int[] count = new int[26]; 

        //taake hum comp mein check karlein k dupicates hain ya nhi aur nke count ko store karlein
        for (int i = 0; i < comp.Length; i++)
        {
            count[comp[i] - 'a']++;
        }

        string[] result = new string[comp.Length];

        // green ki condition check karne k liye
        for (int i = 0; i < comp.Length; i++)
        {
            if (input[i] == comp[i])
            {
                result[i] = "Green";
                count[input[i] - 'a']--; //taake humaare input se uska count kam hojaye
            }
        }

        //agar green nhi hai toh phir yeh check karte hain
        for (int i = 0; i < comp.Length; i++)
        {
            if (result[i] != null) continue; //kiunke agar green hoga toh null nhi hoga
            if (count[input[i] - 'a'] > 0)
            {
                result[i] = "Yellow";
                count[input[i] - 'a']--;
            }
            else
            {
                result[i] = "Grey";
            }
        }
        return result;
    }

    public void check_victory(string[] input)
    {
        int cnt = 0;
        for (int i = 0; i < input.Length; i++)
        {
            Console.Write(input[i] + " ");
            if (input[i] == "Green") {cnt++;}
            else {cnt = 0;}
        }
        Console.WriteLine();

        if (cnt == input.Length)
            {
                Console.WriteLine("You have won the Game");
            }
    }
}

class Program
{
    static void Main()
    {
        Wordle w1 = new Wordle();

        w1.randomInput();
        // Console.WriteLine(secret);
        for (int i = 0; i < 5 ; i++) {
            Console.WriteLine("Enter a word: ");

            string? word = Console.ReadLine();
            if (string.IsNullOrEmpty(word) || !w1.validate(word))
            {
                Console.WriteLine("galat");
                i--;
                continue;
            }
            string[] ans = w1.calculate(word);
            w1.check_victory(ans);
        }
    }
}