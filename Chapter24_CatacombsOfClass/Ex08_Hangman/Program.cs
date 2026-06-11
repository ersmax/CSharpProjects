Console.Title = "Hangman";

Player newPlayer = new Player();
Game aGame = new Game(newPlayer);
aGame.RunGame();

public class Player
{
    public char ChooseLetter()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        string letter;
        letter = Console.ReadLine() ?? "not valid";
        Console.ResetColor();
        if (letter.Length != 1)
            return '-';
        return char.ToUpper(Convert.ToChar(letter));
    }

    public void DisplayState(Game aGame)
    {
        if (aGame.RemainingGuesses == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost, try again.");
            Console.ResetColor();
            return;
        }
        
        Console.Write("Word:");
        foreach (char character in aGame.HiddenWord)
            Console.Write($" {char.ToUpper(character)}");

        if (aGame.Win())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYou won, congrats!");
            Console.ResetColor();
            return;
        }

        Console.Write($" | Remaining: {aGame.RemainingGuesses}");

        Console.Write($" | Incorrect: ");
        string display = "";
        foreach (char character in aGame.IncorrectChars)
            display += char.ToUpper(character); 
        Console.Write($"{display, -8} | ");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Guess: ");
        Console.ResetColor();
    }
}

public class Game
{
    private readonly string _word;
    private int _lettersToGuess;
    private class Generator
    {
        internal string Word { get; }

        private string[] _list = new string[] { "ELEPHANT", "PIGGY", "TEDDY", "GIRAFFE", "HIPPOCAMPUS" };

        public Generator()
        {
            Word = GetWord();
        }

        private string GetWord()
        {
            Random random = new Random();
            int idx = random.Next(_list.Length);
            return _list[idx];
        }
    }

    public char[] HiddenWord { get; }
    public char[] IncorrectChars { get; private set; }
    public char[] CorrectChars { get; private set; }
    public int RemainingGuesses { get; private set; } = 5;
    public Player ThePlayer { get; }

    public Game(Player aPlayer)
    {
        _word = new Generator().Word;
        HiddenWord = new char[_word.Length];
        for (int idx = 0; idx < _word.Length; idx++)
            HiddenWord[idx] = '_';
        
        _lettersToGuess = _word.Length;
        IncorrectChars = Array.Empty<char>();
        CorrectChars = Array.Empty<char>();
        ThePlayer = aPlayer;
    }

    public void RunGame()
    {
        Console.WriteLine("Enter a letter to guess");
        ThePlayer.DisplayState(this);
        while (!Win() && RemainingGuesses > 0)
        {
            char theLetter = ThePlayer.ChooseLetter();
            CheckLetter(theLetter);
            ThePlayer.DisplayState(this);
        }
        if (RemainingGuesses == 0)
            Console.WriteLine($"The correct word was: {_word}");

    }

    private void CheckLetter(char inputLetter)
    {
        inputLetter = char.ToUpper(inputLetter);
        
        if (RemainingGuesses == 0) return;
        
        if (!char.IsLetter(inputLetter)) return;

        foreach (char character in IncorrectChars)
            if (inputLetter == character) return;

        foreach (char character in CorrectChars)
            if (inputLetter == character) return;

        bool validGuess = false;
        for (int idx = 0; idx < _word.Length; idx++)
            if (_word[idx] == inputLetter)
            {
                validGuess = true;
                _lettersToGuess--;
                HiddenWord[idx] = inputLetter;
            }

        if (validGuess)
        {
            char[] temp = CorrectChars;
            Array.Resize(ref temp, temp.Length + 1);
            temp[^1] = inputLetter;
            CorrectChars = temp;
        }
        else
        {
            char[] temp = IncorrectChars;
            Array.Resize(ref temp, temp.Length + 1);
            temp[^1] = char.ToUpper(inputLetter);
            IncorrectChars = temp;
            RemainingGuesses--;
        }
    }

    public bool Win()
    {
        return _lettersToGuess == 0;
    }
}

