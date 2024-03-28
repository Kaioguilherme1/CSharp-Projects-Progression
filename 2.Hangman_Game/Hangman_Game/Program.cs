//author: Kaio Guilherme


using System.Text.Json;
using Hangman_Game;

//class difficulty
public class WordsClass
{
    public WordsClass()
    {
        words = new List<string>();
    }
    public List<string> words { get; set; }
}


class Game
{
    // Dictionary to store the words according to the difficulty
    private Dictionary<String, List<String>> difficultys = new Dictionary<String, List<String>>();
    private string? scores;
    public string pathScores = "../../../scores.txt";
    public string pathWords = "../../../words.json";
    
    /// <summary>
    /// Read the json file and store the words in the dictionary
    /// </summary>
    public void ReadJson()
    {
        try
        {
            string jsonString = File.ReadAllText(pathWords);
            this.scores = File.ReadAllText(pathScores);
            var words = JsonSerializer.Deserialize<WordsClass>(jsonString);
            // Store the words in the dictionary according to the difficulty
            foreach (string? word in words.words) // 
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
        int? option;
        Hangman hangman = new Hangman();
        Game game = new Game();
        game.ReadJson();
        // Menu
        do
        {
            Console.WriteLine("|===========================================|");
            Console.WriteLine("|         Welcome to Hangman Game!          |");
            Console.WriteLine("|===========================================|");
            Console.WriteLine("| Choose a difficulty: easy, medium or hard  |");
            Console.WriteLine("| 1) Easy                                   |");
            Console.WriteLine("| 2) Medium                                 |");
            Console.WriteLine("| 3) Hard                                   |");
            Console.WriteLine("|===========================================|");
            Console.WriteLine("| 4) View Scores                            |");
            Console.WriteLine("| 0) Exit                                   |");
            Console.WriteLine("|===========================================|");
            Console.Write("Enter a option >>> ");
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    hangman.Start(game.difficultys["easy"]);
                    break;
                case 2:
                    hangman.Start(game.difficultys["medium"]);
                    break;
                case 3:
                    hangman.Start(game.difficultys["hard"]);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("|===========================================|");
                    Console.WriteLine("|                  Scores                   |");
                    Console.WriteLine("|===========================================|");
                    Console.WriteLine(game.scores);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid difficulty.");
                    break;
            }
        }while(option != 0);
}
}