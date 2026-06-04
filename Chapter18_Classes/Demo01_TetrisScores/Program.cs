Console.Title = "Tetris Score Demo";

Score john = new Score();
john._name = "John";
john._points = 12412;
john._level = 15;

Score lucas = new Score("Lucas", 12021, 10);


if (john.EarnedStars())
    Console.WriteLine($"{john._name} earned a star");
if (lucas.EarnedStars())
    Console.WriteLine($"{lucas._name} earned a star");

class Score
{
    public string _name = "No Name";
    public int _points;
    public int _level;

    public Score() : this("Unknown", 0 , 1)
    { /* Itentionally empty */ }

    public Score(string name, int points, int level)
    {
        _name = name;
        _points = points;
        _level = level;
    }

    // Indicate whether there were at least 1000 points per level on avg
    public bool EarnedStars() => (_points / _level) > 1000;
}
