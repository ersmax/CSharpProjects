Console.Title = "Demo Static Members";
Score user = Score.CreateScore(10000, 10, "user");
Score user2 = Score.CreateScore(9500, 9, "user");
Console.WriteLine(Score.PointsThreshold);

Score[] scores = new Score[2] {user, user2};
int times = Score.CountForPlayer("user", scores);
Console.Write($"The user {user.Name} scored {times} ");
if (times > 1)
    Console.WriteLine("times");
else
    Console.WriteLine("time");

public class Score
{
    public static readonly int PointsThreshold = 1000;
    private static readonly int LevelThreshold = 4;
    public static int PropertyPointsThreshold { get; } = 1000;
    public static int PropertyLevelThreshold { get; } = 4;
    
    public string Name { get; set; }
    public int Points { get; set; }
    public int Level { get; set; }

    static Score()
    {
        PointsThreshold = 1;
        LevelThreshold = 10;
    }
    public Score() : this(0, 0, "Unknown") { }
    public Score(int points, int level, string name)
    {
        Points = points;
        Level = level;
        Name = name;
    }

    public static Score CreateScore() => new Score();
    public static Score CreateScore(int points, int level, string name) => new Score(points, level, name);
    
    public bool IsWorthyOfTheHighScoreTable()
    {
        if (Points < PointsThreshold) return false;
        if (Level < LevelThreshold) return false;
        return true;
    }

    public bool IsWorthyProperty()
    {
        if (Points < PropertyPointsThreshold) return false;
        if (Level < PropertyLevelThreshold) return false;
        return true;
    }
    public static int CountForPlayer(string playerName, Score[] scores)
    {
        int count = 0;
        foreach (Score score in scores)
            if (score.Name == playerName)
                count++;
        return count;
    }
}
