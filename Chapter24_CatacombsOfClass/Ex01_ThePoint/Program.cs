Console.Title = "The Point";
Point first = new Point(2, 3);
Point second = new Point(-4, 0);
Console.WriteLine($"First point: ({first.X}, {first.Y}). " +
    $"Second point: ({second.X}, {second.Y}).");


public class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Point() : this(0, 0) { }
    public Point(int x, int y) {  X = x; Y = y; }
}
