Console.Title = "Asteroids";

GameObject[] gameObjects = new GameObject[] { new Asteroid(5, 4), new Ship(), new Bullet()};
foreach (GameObject game in gameObjects)
    game.Update();
Console.WriteLine(new Asteroid().PositionX);

GameObject gameObject = new Asteroid();
// casting with GetType method (of the class object)
if (gameObject.GetType() == typeof(Asteroid))
{
    Asteroid asteroid = (Asteroid)gameObject;
    Console.WriteLine(asteroid.RotationAngle);
}
// `as` keyword casting => as does a check of type and conversion
Asteroid? maybeAsteroid = gameObject as Asteroid;
if (maybeAsteroid != null)
    Console.WriteLine(maybeAsteroid.RotationAngle);

// `is` casting => check the type and assign it to a new variable
if (gameObject is Asteroid anotherAsteroid)
    Console.WriteLine(anotherAsteroid.RotationAngle);


public class GameObject
{
    public GameObject() { }
    public GameObject(float positionX, float positionY, float velocityX, float velocityY)
    {
        PositionX = positionX;
        PositionY = positionY;
        VelocityX = velocityX;
        VelocityY = velocityY;
    }

    public float PositionX {  get; protected set; }
    public float PositionY { get; protected set; }
    public float VelocityX { get; protected set; }
    public float VelocityY { get; protected set; }

    public void Update()
    {
        PositionX += VelocityX;
        PositionY += VelocityY;
    }
}

public sealed class Asteroid : GameObject
{
    public Asteroid() : base(0, 0, 0, 0) { }
    public Asteroid(int size, int angle) : this()
    {
        Size = size;
        RotationAngle = angle;
    }

    public float Size { get; }
    public float RotationAngle { get; } = -1;
}

public class Ship : GameObject
{
    public Ship() : base(0, 0, 0, 0) { }
    public string Class { get;}
    public int Ammunition { get; }
}

public sealed class Bullet : GameObject
{
    public Bullet() : base(0, 0, 0, 0) { }
    public string Type { get; } 
}

public class Point
{
    public float X { get; }
    public float Y { get; }

    public Point(float x, float y)
    {
        X = x; Y = y;
    }
}