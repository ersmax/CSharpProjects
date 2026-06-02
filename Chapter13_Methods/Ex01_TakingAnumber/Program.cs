int yearOfBirth = AskForNumber("What is your year of birth?");
int monthOfBirth = AskForNumberInRange("What is your month of birth?", 1, 12);
int dayOfBirth = AskForNumberInRange("What is your day of birth?", 1, 31);
Console.WriteLine($"Your date of birth is {monthOfBirth}/{dayOfBirth}/{yearOfBirth}.");

int number = AskForNumberInRange("User 1, enter a number (1-100):", 1, 100);
Console.Clear();
Console.WriteLine("User2, guess the number:");

bool correctGuess = false;
while (!correctGuess)
{
    int guess = AskForNumber("Guess the number");
    if (guess > number)
        Console.WriteLine($"Your guess ({guess}) is too high");
    else if (guess < number)
        Console.WriteLine($"Your guess ({guess}) is too low");
    else
        correctGuess = true;
}
Console.WriteLine($"You guessed the number!");

/// <summary>
/// Getting a number from a user
/// </summary>
int AskForNumber(string text) 
{
    Console.Write(text + " ");
    return Convert.ToInt32(Console.ReadLine());
}

/// <summary>
/// Enter number between min and max values
/// </summary>
int AskForNumberInRange(string text, int min, int max)
{
    bool correctInput = false;
    int number;
    do
    {
        number = AskForNumber(text);
        if (number >= min && number <= max)
            correctInput = true;
   
    } while (!correctInput);
   
    return number;
}