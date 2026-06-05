Circle circle = new Circle() { X = 4, Radius = 3 };
Console.WriteLine($"Radius of circle in (x, y): ({circle.X}, {circle.Y}) is {circle.Radius}");
// This won't work:
// circle.Radius = 2;

public class Circle
{
    public float X { get; init; } = 0;
    public float Y { get; init; } = 0;
    public float Radius { get; init; } = 0;
}