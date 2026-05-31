Console.Title = "The Prototype";

Console.ForegroundColor = ConsoleColor.Green;

int target;
do
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    target = Convert.ToInt32(Console.ReadLine());
} while (target < 0 || target > 100);

Console.Clear();
Console.WriteLine("User 2, guess the number");

bool found = false;
while (!found)
{
    Console.Write("What is your next guess? ");
    int guess = Convert.ToInt32(Console.ReadLine());
    if (guess == target)
        found = true;
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{guess} is too ");
        if (guess < target)
            Console.WriteLine("low.");
        else
            Console.WriteLine("high.");
        Console.ForegroundColor = ConsoleColor.Green;
    }
}

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("You guessed the number!");



 