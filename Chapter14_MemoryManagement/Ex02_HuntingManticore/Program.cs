using System.Reflection.Metadata;

Console.Title = "Hunting the Manticore";

int round = 1;
int manticoreHealth = 10;
int cityHealth = 15;

Console.ForegroundColor = ConsoleColor.Green;
string user1Text = "Player 1, how far away from the city do you want to station the Manticore?";
int targetDistance = askNumber(user1Text, 0, 100);

Console.Clear();
Console.WriteLine("Player 2, it is your turn.");
while (manticoreHealth > 0 || cityHealth > 0)
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"STATUS: Round: {round, 3}  City: {cityHealth}/15  Manticore: {manticoreHealth}/10");
    Console.ForegroundColor = ConsoleColor.Green;

    Console.Write("This cannon is expected to deal ");
    int damagePoints = getDamage(round);
    Console.Write(damagePoints);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" this round.");

    string user2Text = "Enter desired cannon range:";
    int cannonDistance = askNumber(user2Text, 0, 100);

    int distanceToTarget = computeDistance(targetDistance, cannonDistance);
    if (distanceToTarget == 0)
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth -= damagePoints;
    }
    else if (distanceToTarget > 0)
        Console.WriteLine("That round FELL SHORT of the target.");
    else
        Console.WriteLine("That round OVERSHOT of the target.");

    cityHealth--;
    round++;
}
cityHealth = Math.Clamp(cityHealth, 0, 15);
manticoreHealth = Math.Clamp(manticoreHealth, 0, 10);
drawOutcome(cityHealth, manticoreHealth);

int askNumber(string text, int min, int max)
{
    bool valid = false;
    int number;
    do
    {
        Console.Write(text + " ");
        number = Convert.ToInt32(Console.ReadLine());
        if (number >= min && number <= max)
            valid = true;

    } while (!valid);

    return number;
}

int getDamage(int roundNumber)
{
    if (roundNumber % 3 == 0 && roundNumber % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        return 10;
    }
    else if (roundNumber % 3 == 0 || roundNumber % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        return 3;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        return 1;
    }
}

int computeDistance(int targetDistance, int cannonDistance) => targetDistance - cannonDistance;

void drawOutcome(int cityHealth, int manticoreHealth)
{
    Console.ForegroundColor = ConsoleColor.Red;

    if (cityHealth <= 0 && manticoreHealth <= 0)
    {
        Console.WriteLine("Game over: Both the manticore and the city were destroyed.");
        return;
    }
    else if (cityHealth <= 0)
    {
        Console.WriteLine("Game over:The city was destroyed.");
        return;
    }
    else if (manticoreHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
    }
}