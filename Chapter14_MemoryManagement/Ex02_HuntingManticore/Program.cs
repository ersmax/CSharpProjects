Console.Title = "Hunting the Manticore";

int round = 1;
int manticoreHealth = 10;
int cityHealth = 15;

Console.ForegroundColor = ConsoleColor.Green;
string user1Text = "Player 1, how far away from the city do you want to station the Manticore?";
int targetDistance = AskNumberInRange(user1Text, 0, 100);

Console.Clear();
Console.WriteLine("Player 2, it is your turn.");
while (manticoreHealth > 0 && cityHealth > 0)
{
    StatusDisplay(round, cityHealth, manticoreHealth);

    Console.Write("This cannon is expected to deal ");
    int damagePoints = ComputeDamage(round);
    Console.Write(damagePoints);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(" this round.");

    string user2Text = "Enter desired cannon range:";
    int cannonDistance = AskNumber(user2Text);

    int distanceToTarget = ComputeDistance(targetDistance, cannonDistance);
    ShowTurnOutcome(distanceToTarget);
    if (distanceToTarget == 0) 
        manticoreHealth -= damagePoints;

    if (manticoreHealth > 0)    // manticore shoots only if it's alive still
        cityHealth--;  
    round++;
}
cityHealth = Math.Clamp(cityHealth, 0, 15);
manticoreHealth = Math.Clamp(manticoreHealth, 0, 10);
ShowGameOutcome(cityHealth, manticoreHealth);

// ------------------ MAIN's METHODS ------------------

// Display the status of the current game
void StatusDisplay(int gameRound, int cityHealth, int manticoreHealth)
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"STATUS: Round: {gameRound, 3}  City: {cityHealth}/15  Manticore: {manticoreHealth}/10");
    Console.ForegroundColor = ConsoleColor.Green;
}

// Ask the user a number 
int AskNumber(string text)
{
    Console.Write(text + " ");
    return Convert.ToInt32(Console.ReadLine());
}

// Ask the user a number in range (min, max)
int AskNumberInRange(string text, int min, int max)
{
    bool valid = false;
    int number;
    do
    {
        number = AskNumber(text);
        if (number >= min && number <= max)
            valid = true;

    } while (!valid);

    return number;
}

// Compute the damage from the cannon
int ComputeDamage(int roundNumber)
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

// Compute the distance from the cannon shot from the target
int ComputeDistance(int targetDistance, int cannonDistance) => targetDistance - cannonDistance;

// Show results of the game's turn
void ShowTurnOutcome(int distanceToTarget)
{
    if (distanceToTarget == 0)
        Console.WriteLine("That round was a DIRECT HIT!");
    else if (distanceToTarget > 0)
        Console.WriteLine("That round FELL SHORT of the target.");
    else if (distanceToTarget < 0)
        Console.WriteLine("That round OVERSHOT of the target.");
}

// Show final results of the game
void ShowGameOutcome(int cityHealth, int manticoreHealth)
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
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}