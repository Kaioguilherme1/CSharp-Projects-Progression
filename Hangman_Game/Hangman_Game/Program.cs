using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class WordsClass
{
    public WordsClass()
    {
        words = new List<string>();
    }
    public List<string> words { get; set; }
}

class Hangman
{
    private Dictionary<String, List<String>> difficultys = new Dictionary<String, List<String>>();
    private int lifes = 6;
    private int score = 0;
    
    public int Start(List<String> words)
    {
        Random random = new Random();
        List<int> indexes = new List<int>();
        do
        {
            int index;
            do
            {
                index = random.Next(words.Count);
            } while (indexes.Contains(index));
            indexes.Add(index);
            
            string word = words[index];
            char[] wordArray = word.ToCharArray();
            char[] wordArrayHidden = new char[wordArray.Length];
            bool found = false;
            
            for (int i = 0; i < wordArray.Length; i++)
            {
                wordArrayHidden[i] = '_';
            }

            do
            {
                Console.Clear();
                Console.WriteLine(wordArray);
                Console.WriteLine("Word: " + new string(wordArrayHidden));
                Console.WriteLine("Lifes: " + this.lifes);
                Console.WriteLine("Score: " + this.score);
                Console.WriteLine("Enter a letter: ");
                ConsoleKeyInfo key = Console.ReadKey();
                if (char.IsLetter(key.KeyChar))
                {
                    char letter = char.ToLower(key.KeyChar);
                    Console.WriteLine($"\nVocê digitou a letra: {letter}");
                    
                    for (int i = 0; i < wordArray.Length; i++)
                    {
                        if (wordArray[i] == letter)
                        {
                            wordArrayHidden[i] = letter;
                            found = true;
                        }
                    }
                    
                    if (found)
                    {
                        this.score++;
                    }
                    else
                    {
                        this.score--;
                        this.lifes--;
                    }
                    
                    
                }
                else
                {
                    Console.WriteLine("\nPor favor, digite apenas uma letra.");
                }
                
                
            } while (this.lifes > 0);
            
        } while (true);
    }
    
    public void ReadJson()
    {
        try
        {
            string jsonString = File.ReadAllText("../../../words.json");
            var words = JsonSerializer.Deserialize<WordsClass>(jsonString);
            foreach (string word in words.words) // 
            {
                if (word.Length < 4)
                {
                    if (!difficultys.ContainsKey("easy"))
                    {
                        difficultys.Add("easy", new List<string>());
                    }
                    difficultys["easy"].Add(word);
                }
                else if ( word.Length < 7 && word.Length >= 4)
                {
                    if (!difficultys.ContainsKey("medium"))
                    {
                        difficultys.Add("medium", new List<string>());
                    }
                    difficultys["medium"].Add(word);
                }
                else
                {
                    if (!difficultys.ContainsKey("hard"))
                    {
                        difficultys.Add("hard", new List<string>());
                    }
                    difficultys["hard"].Add(word);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    
    static void Main(string[] args)
    {   
        int difficulty;
        Hangman hangman = new Hangman();
        hangman.ReadJson();
        Console.WriteLine("|==========================================|");
        Console.WriteLine("|         Welcome to Hangman Game!         |");
        Console.WriteLine("|==========================================|");
        Console.WriteLine("| Choose a difficulty: easy, medium or hard |");
        Console.WriteLine("| 1) Easy                                  |");
        Console.WriteLine("| 2) Medium                                |");
        Console.WriteLine("| 3) Hard                                  |");
        Console.WriteLine("|==========================================|");
        Console.Write("Enter a difficulty >>> ");
        difficulty =  Convert.ToInt32(Console.ReadLine());
        switch (difficulty)
        {
            case 1:
                hangman.Start(hangman.difficultys["easy"]);
                break;
            case 2:
                hangman.Start(hangman.difficultys["medium"]);
                break;
            case 3:
                hangman.Start(hangman.difficultys["hard"]);
                break;
            default:
                Console.WriteLine("Invalid difficulty.");
                break;
        }
    }
}