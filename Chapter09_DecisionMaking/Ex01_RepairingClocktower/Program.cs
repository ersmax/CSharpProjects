Console.Title = "Repairing the Clocktower";

Console.Write("Enter a whole number: ");
int number = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"You entered: {number,10}");

if (number % 2 == 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Tick");
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Tock");
}
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Press a key to exit");
Console.ReadKey(true);
