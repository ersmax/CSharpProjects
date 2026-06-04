// --- switch based parsing using strings ---
Console.WriteLine(
    "What type of elixir do you want? Options are 'invisibility', 'strength', 'regeneration', and 'coffee'.");
string input = Console.ReadLine().ToLower();    // lowercase-ify
ElixirType purchase = input switch
{
    "invisibility" => ElixirType.Invisibility,
    "strength" => ElixirType.Strength,
    "regeneration" => ElixirType.Regeneration,
    "coffee" => ElixirType.Coffee,
};

// --- switch based parsing using numbers ---
int inputNumber;
while (true)
{
    Console.WriteLine("What type of elixir do you want?");
    Console.WriteLine("1 - Invisibility");
    Console.WriteLine("2 - Strength");
    Console.WriteLine("3 - Regeneration");
    Console.WriteLine("4 - Coffee");
    Console.Write("> ");
    inputNumber = Convert.ToInt32(Console.ReadLine());
    if (inputNumber is >= 1 and <= 4)
        break;
    Console.WriteLine("Not a valid input");
}

ElixirType secondPurchase = inputNumber switch
{
    1 => ElixirType.Invisibility,
    2 => ElixirType.Strength,
    3 => ElixirType.Regeneration,
    4 => ElixirType.Coffee,
};

// --- Generalized approach with Type class ---
// there are many enum types. We get the specific enum type we want with typeof operator
Console.WriteLine("Generalized approach with Type class");
string[] elixirNames = Enum.GetNames(typeof(ElixirType));   
string options = "";
foreach (string elixirName in elixirNames)
    options += $" \"{elixirName}\"";
Console.WriteLine($"What type of elixir do you want? Options are {options}.");
//  Parse the string into the type of enum
// Enum.Parse doesn't know what to return, so it return an object.
// Fix that by casting the returned object into my enum
// Last parameter (true) allows to ingnore the Upper/Lower case
ElixirType thirdPurchase = (ElixirType)Enum.Parse(typeof(ElixirType), Console.ReadLine(), true);
Console.WriteLine($"You chose {thirdPurchase}");

// --- Generalized approach with Type class and number: use input as enum index -- 
Console.WriteLine("Generalized approach with Type class and number as a choice");
string[] theElixirNames = Enum.GetNames(typeof(ElixirType));
string theOptions = "";
for (int idx = 0; idx < theElixirNames.Length; idx++)
    theOptions += $"{idx + 1, 3} - \"{theElixirNames[idx]}\"\n";
Console.Write($"What type of elixir do you want? Enter a number:\n{theOptions}");
int choice;
do
{
    Console.Write("> ");
    choice = Convert.ToInt32(Console.ReadLine());
} while (choice > 0 &&  choice < theElixirNames.Length);

choice--;   // Zero index adjust
ElixirType fourthPurchase = (ElixirType)choice;
Console.WriteLine($"You chose {fourthPurchase}");

// --- Generalized approach with Type class and number: use input as array index -- 
Console.WriteLine("Generalized approach with Type class and number as a choice");
string[] anotherElixirNames = Enum.GetNames(typeof(ElixirType));
string anotherOptions = "";
for (int idx = 0; idx < anotherElixirNames.Length; idx++)
    anotherOptions += $"{idx + 1,3} - \"{anotherElixirNames[idx]}\"\n";
Console.Write($"What type of elixir do you want? Enter a number:\n{anotherOptions}");
int newChoice;
do
{
    Console.Write("> ");
    newChoice = Convert.ToInt32(Console.ReadLine());
} while (newChoice > 0 && newChoice < anotherElixirNames.Length);

newChoice--;   // Zero index adjust
string chosenOption = anotherElixirNames[newChoice];
ElixirType fifthPurchase = (ElixirType)Enum.Parse(typeof(ElixirType), chosenOption, true);
Console.WriteLine($"You chose {fifthPurchase}");

// --- Generalized approach with Generics ---
string[] myElixirNames = Enum.GetNames<ElixirType>();
string someOptions = "";
foreach (string elixirName in myElixirNames)
    someOptions += $" \"{elixirName}\"";
Console.WriteLine($"What type of elixir do you want? Options are: {someOptions}.");
ElixirType sixthPurchase = Enum.Parse<ElixirType>(Console.ReadLine(), true);
Console.WriteLine($"Your sixth and last purchase was {sixthPurchase}");

enum ElixirType
{
    Invisibility,
    Strength,
    Regeneration,
    Coffee
};