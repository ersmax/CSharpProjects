Console.Title = "Buying Inventory";
Console.ForegroundColor = ConsoleColor.Green;

string menu = "The following items are available:\n" +
    "1 - Rope\n" +
    "2 - Torches\n" +
    "3 - Climbing Equipment\n" +
    "4 – Clean Water\n" +
    "5 – Machete\n" +
    "6 – Canoe\n" +
    "7 – Food Supplies\n";

Console.WriteLine(menu);
Console.Write("What number do you want to see the price of? ");
byte choice = Convert.ToByte(Console.ReadLine());
choice = (byte)Math.Clamp((int)choice, 1, 7);

string item = choice switch
{
    1 => "Rope",
    2 => "Torches",
    3 => "Climbing Equipment",
    4 => "Clean Water",
    5 => "Machete",
    6 => "Canoe",
    7 => "Food Supplies",
    _ => "Unknown"
};

int cost = choice switch
{
    1 => 10,    // gold
    2 => 15,
    3 => 25,
    4 => 1,
    5 => 20,
    6 => 200,
    7 => 1,
    _ => 0
};

Console.Write("Enter your full name: ");
string fullname = Console.ReadLine();
double finalCost = fullname switch
{
    "admin" => (double)cost / 2,    // discounted name
    _ => (double)cost
};

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine($"{item} costs {finalCost:F} gold.");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Press a key to exit");
Console.ReadKey(true);