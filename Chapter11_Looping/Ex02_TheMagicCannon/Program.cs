Console.Title = "The Magic Cannon";

for (int idx = 1; idx <= 100; idx++)
{
    string blast = "Normal";

    if (idx % 3 == 0)
        if (idx % 5 == 0)
        {
            blast = "Combined";
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        else
        {
            blast = "Fire";
            Console.ForegroundColor = ConsoleColor.Red;
        }
    else if (idx % 5 == 0)
    {
        blast = "Electric";
        Console.ForegroundColor = ConsoleColor.Yellow;
    }

    Console.WriteLine($"{idx,-3}: {blast}");
    Console.ForegroundColor = ConsoleColor.Gray;
}
