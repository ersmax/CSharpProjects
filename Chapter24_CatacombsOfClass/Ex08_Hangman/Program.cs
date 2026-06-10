Console.Title = "Hangman";

Game aGame = new Game();
aGame.ShowHiddenWord();


public class Game
{
    private readonly string _word;
    public char[] IncorrectChars { get; private set; }
    public char[] CorrectChars { get; private set; }
    public int LettersToGuess { get; private set; }

    public Game()
    {
        _word = new Generator().Word;
        IncorrectChars = new char[] {};
        CorrectChars = new char[] {};
        LettersToGuess = _word.Length;
    }

    public void ShowHiddenWord()
    {
        foreach (char character in _word)
        {
            bool seen = false;
            foreach (char correctChar in CorrectChars)
                if (character == correctChar)
                {
                    seen = true;
                    break;
                }
            if (seen)
                Console.WriteLine($"{character, 1}");
            else
                Console.Write($"{"_",1}");
        }
        Console.WriteLine();
    }
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
}

