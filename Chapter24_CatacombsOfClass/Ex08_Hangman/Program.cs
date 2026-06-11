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
        do
        {
            letter = Console.ReadLine() ?? "not valid";
        } while (letter.Length != 1);

        return Convert.ToChar(letter);
    }

    public void DisplayState(Game aGame)
    {
        if (aGame.RemainingGuesses == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You lost, try again.");
            return;
        }
        if (aGame.Win())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You won, congrats!");
            return;
        }
        Console.ResetColor();

        Console.Write("Word:");
        foreach (char character in aGame.HiddenWord)
            Console.Write($" {char.ToUpper(character)}");

        Console.Write($" | Remaining: {aGame.RemainingGuesses}");

        Console.Write($" | Incorrect: ");
        string display = "";
        foreach (char character in aGame.IncorrectChars)
            display += char.ToUpper(character); 
        Console.Write($"{display, 15}");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" | Guess: ");
    }
}

public class Game
{
    private readonly string _word;
    private int _lettersToGuess;
    private class Generator
    {
        internal string Word { get; }

        private string[] _list = new string[] { "elephant", "piggy", "teddy", "giraffe", "hippocampus" };

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
        IncorrectChars = new char[] {};
        CorrectChars = new char[] {};
        ThePlayer = aPlayer;
    }

    public void RunGame()
    {
        ThePlayer.DisplayState(this);
        while (!Win() && RemainingGuesses > 0)
        {
            char theLetter = ThePlayer.ChooseLetter();
            CheckLetter(theLetter);
            ThePlayer.DisplayState(this);
        }
    }

    private void CheckLetter(char inputLetter)
    {
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
            if (CorrectChars.Length == 0) CorrectChars[0] = inputLetter;
            else CorrectChars[^1] = inputLetter;
        }
        else
        {
            if (IncorrectChars.Length == 0) IncorrectChars[0] = inputLetter;
            else IncorrectChars[^1] = inputLetter;
            RemainingGuesses--;
        }
    }

    public bool Win()
    {
        return _lettersToGuess == 0;
    }

    //public void ShowHiddenWord()
    //{
    //    foreach (char character in _word)
    //    {
    //        bool seen = false;
    //        foreach (char correctChar in CorrectChars)
    //            if (character == correctChar)
    //            {
    //                seen = true;
    //                break;
    //            }
    //        if (seen)
    //            Console.WriteLine($"{character, 1}");
    //        else
    //            Console.Write($"{"_",1}");
    //    }
    //}
}

