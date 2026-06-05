var shape = new Rectangle(2, 3);
shape.Height = 5;
Console.WriteLine($"The rectangle ({shape.Width}x{shape.Height} has an area of {shape.Area})");

public class Rectangle
{
    private float _height;
    private float _width;

    public Rectangle() : this(0, 0) { }
    public Rectangle(float  width, float height)
    {
        Width = width;
        Height = height;
    }

    public float Width
    {
        get
        {
            return _width;
        }
        set
        {
            _width = value;
        }
    }

    //public float Height
    //{
    //    get => _height;
    //    set => _height = value;
    //}

    // or simply auto-implemented property:
    //public float Width { get; set; }
    public float Height { get; set; }

    public float Area => Width * Height;  // get => _width * _height
  
}