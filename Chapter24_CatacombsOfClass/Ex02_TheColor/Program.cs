Console.Title = "The Color";

var color1 = new Color(0, 128, 54);
var red = Color.Red;
Console.WriteLine($"First color: {color1}: Red: {color1.R}, Green: {color1.G}, Blue: {color1.B}");
Console.WriteLine($"Second color: {red}: Red: {red.R}, Green: {red.G}, Blue: {red.B}");

public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color() : this(0, 0, 0) { }
    public Color(byte red, byte green, byte blue) 
    {
        R = red;
        G = green;
        B = blue;
    }

    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);
}
