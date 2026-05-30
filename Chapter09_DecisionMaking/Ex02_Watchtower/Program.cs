Console.Title = "Watchtower";

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("Enter the coordinates (x, y).");
Console.Write("x-axis point: ");
int xPoint = Convert.ToInt32(Console.ReadLine());
Console.Write("y-axis point: ");
int yPoint = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Coordinate (x-y): ({xPoint}, {yPoint})");
bool isNorth = (yPoint > 0);
bool isSouth = (yPoint < 0);
bool isWest = (xPoint < 0);
bool isEast = (xPoint > 0);

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("The enemy is to the ");
if (isNorth)
    if (isWest)
        Console.WriteLine("northwest!");
    else if (isEast)
        Console.WriteLine("northest!");
    else
        Console.WriteLine("north!");
else if (isSouth)
    if (isWest)
        Console.WriteLine("southwest!");
    else if (isEast)
        Console.WriteLine("southest!");
    else
        Console.WriteLine("south!");
else
    if (isWest)
        Console.WriteLine("west!");
    else if (isEast)
        Console.WriteLine("est!");
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\rThe enemy is here!   ");
    }
Console.Beep();

Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("Press a key to exit");
Console.ReadKey(true);

