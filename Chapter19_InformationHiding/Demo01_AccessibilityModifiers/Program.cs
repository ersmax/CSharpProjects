Console.Title = "Accessibility modifiers";

var rectangle = new Rectangle(-2, 3);
rectangle.SetWidth(3);
Console.WriteLine(rectangle.GetArea());

public class Rectangle
{
    private float _width;
    private float _height;

    public Rectangle() : this(0, 0) { }

    public Rectangle(float width, float height)
    {
        if (width < 0 || height < 0)
            throw new ArgumentException("The argument passed is negative");
        _width = width;
        _height = height;
    }

    public float GetWidth() => _width;
    public float GetHeight() => _height;
    public float GetArea() => _width * _height;

    public void SetWidth(float width) => _width = width;
    public void SetHeight(float height) => _height = height;
}