public class Score
{
    private static readonly int PointsThreshold = 1000;
    private static readonly int LevelThreshold = 4;
    public static int PropertyPointsThreshold { get; } = 1000;
    public static int PropertyLevelThreshold { get; } = 4;
    public int Points { get; set; }
    public int Level { get; set; }
    public Score() : this(0, 0) { }
    public Score(int points, int level)
    {
        Points = points;
        Level = level;
    }
    
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
}