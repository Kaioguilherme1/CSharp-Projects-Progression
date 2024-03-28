//Author: Kaio Guilherme

namespace Hangman_Game;
class Hangman
{   
    // Path to save the score
    public const string Path = "../../../scores.txt";
    private int lifes = 6;
    private int _score;
    private string? _playerName;
    private List<string> _hangman = new List<string>
    {
        "|------|",
        "|",
        "|",
        "|",
        "|",
        "|"
    };
    
    /// <summary>
    /// Save the player name and score in a file
    /// </summary>
    public void Save()
    {
        try
        {
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine("| " + _playerName + " : " + _score);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    
    /// <summary>
    /// Print the hangman
    /// </summary>
    private void PrintHangman()
    {   
        // Print the hangman according to the lifes
        switch (this.lifes)
        {
            case 0:
                _hangman[1] = "|      ()";
                _hangman[2] = "|      /|\\";
                _hangman[3] = "|       |";
                _hangman[4] = "|      / \\";
                break;
            
            case 1:
                _hangman[1] = "|      ()";
                _hangman[2] = "|      /|\\";
                _hangman[3] = "|       |";
                _hangman[4] = "|      /";
                break;
            
            case 2:
                _hangman[1] = "|      ()";
                _hangman[2] = "|      /|\\";
                _hangman[3] = "|       |";
                break;
            
            case 3:
                _hangman[1] = "|      ()";
                _hangman[2] = "|      /|";
                _hangman[3] = "|       |";
                break;
                
            case 4:
                _hangman[1] = "|      ()";
                _hangman[2] = "|       |";
                _hangman[3] = "|       |";
                break;
            case 5:
                _hangman[1] = "|      ()";
                break;
            
            case 6:
                this._hangman = new List<string>
                {
                    "|------|",
                    "|",
                    "|",
                    "|",
                    "|",
                    "|"
                };
                break;
        }
        foreach (string line in _hangman)
        {
            Console.WriteLine(line);
        }
    }
    
    
    /// <summary>
    /// Check if the option is valid
    /// </summary>
    private static bool ValidOption(char option)
    {
        return (char.IsLetter(option) && (option == 'y' || option == 'n'));
    }
    
    /// <summary>
    /// Start the game
    /// </summary>
    /// <param name="words"></param>
    public void Start(List<String> words)
    {
        Random random = new Random();
        List<int> indexes = new List<int>();
        ConsoleKeyInfo option;
        // Loop to get a random word from the list
        do
        {
            int index;
            // Check if the index is already in the list and get a new one
            do
            {
                index = random.Next(words.Count);
            } while (indexes.Contains(index));

            indexes.Add(index);
            string word = words[index];
            char[] wordArray = word.ToCharArray();
            char[] wordArrayHidden = new char[wordArray.Length];
            List<char> letters = new List<char>();
            bool found = false;
            
            for (int i = 0; i < wordArray.Length; i++)
            {
                wordArrayHidden[i] = '_';
            }
            
            // Loop to get the letters from the player
            do
            {   
                Console.Clear();
                Console.WriteLine("|==============================================|"); 
                Console.WriteLine(string.Format("| Lifes: {0}            | Score: {1,3}             |", this.lifes, this._score));
                Console.WriteLine("|==============================================|");
                PrintHangman();
                Console.WriteLine("Word: " + new string(wordArrayHidden));
                Console.WriteLine("Letters: " + string.Join(", ", letters));
                Console.WriteLine("Enter a letter: ");
                ConsoleKeyInfo key = Console.ReadKey();
                
                // Check if the key is a letter
                if (char.IsLetter(key.KeyChar))
                {
                    char letter = char.ToLower(key.KeyChar);
                    letters.Add(letter);
                    for (int i = 0; i < wordArray.Length; i++)
                    {
                        if (wordArray[i] == letter)
                        {
                            wordArrayHidden[i] = letter;
                            found = true;
                        }
                    }
                    // Check if the letter is in the word
                    if (found)
                    {
                        this._score++;
                    }
                    else if (!found)
                    {
                        this._score--;
                        this.lifes--;
                    }
                    found = false;
                    
                }
                else
                {
                    Console.WriteLine("\nPlease, enter a valid letter!");
                }
                
                // Check if the player found the word
                if (wordArrayHidden.SequenceEqual(wordArray))
                {
                    bool validOption;
                    
                    Console.Clear();
                    Console.WriteLine("|==============================================|");
                    Console.WriteLine("|      Congratulations! You found the word!    |");
                    Console.WriteLine("|==============================================|");
                    Console.WriteLine("Score: " + this._score);
                    // Loop to check if the player wants to continue
                    do
                    {
                        Console.WriteLine("Continue? (y/n)");
                        option = Console.ReadKey();
                        validOption = ValidOption(option.KeyChar);
                        if (validOption)
                        {
                            if (option.KeyChar == 'n')
                            {
                                this.lifes = 0;
                            }else if (option.KeyChar == 'y')
                            {
                                this.lifes = 6;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nPlease, enter a valid option!");
                        }
                    } while (!validOption);
                    break;
                }
                
            } while (this.lifes > 0);
            // Check if the player lost
            if (this.lifes == 0)
                {
                Console.Clear();
                Console.WriteLine("|==============================================|");
                Console.WriteLine("|                Game Over!                    |");
                Console.WriteLine("|==============================================|");
                PrintHangman();
                Console.WriteLine("You lost! The word was: " + word);
                Console.WriteLine("Enter a your name to save your score >>> ");
                _playerName = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(_playerName))
                {
                    _playerName = "noname";
                }
                Console.Clear();
                Console.WriteLine(" " + this._playerName);
                Console.WriteLine("Your score: " + this._score);
                Save();
                // Loop to check if the player wants to play again
                do
                {
                    Console.WriteLine("Do you want to play again? (y/n)");
                    option = Console.ReadKey();
                    if (ValidOption(option.KeyChar))
                    {
                        if (option.KeyChar == 'y')
                        {
                            this.lifes = 6;
                            this._score = 0;
                            break;
                        }
                        else if (option.KeyChar == 'n')
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease, enter a valid option!");
                    }
                    
                } while (ValidOption(option.KeyChar));
            }
        } while (this.lifes > 0);
    }
}    
