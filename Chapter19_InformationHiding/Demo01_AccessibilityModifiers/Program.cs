Console.Title = "Accessibility modifiers";

var rectangle = new Rectangle(-2, 3);
rectangle.SetWidth(3);
Console.WriteLine(rectangle.GetArea());

class Rectangle
{
    private float _width;
    private float _height;
    private float _area;

    public Rectangle() : this(0, 0) { }

    public Rectangle(float width, float height)
    {
        if (width < 0 || height < 0)
            throw new ArgumentException("The argument passed is negative");
        _width = width;
        _height = height;
        UpdateArea();
    }

    public float GetWidth() => _width;
    public float GetHeight() => _height;
    public float GetArea() => _area;

    public void SetWidth(float width)
    {
        _width = width;
        UpdateArea();
    }

    public void SetHeight(float height)
    {
        _height = height;
        UpdateArea();
    }

    private void UpdateArea() => _area = _height * _width;

}