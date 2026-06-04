Console.Title = "Simula’s Soup";

var theSoup = ChooseSoup();
DisplaySoup(theSoup);



// --------- MAIN's METHOD ---------

void DisplaySoup((Type myType, MainIngredient myMainIngredient, Seasoning mySeasoning) aSoup)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"{aSoup.mySeasoning} {aSoup.myMainIngredient} {aSoup.myType}");
    Console.ForegroundColor = ConsoleColor.Gray;
}

(Type TheType, MainIngredient TheMainIngredient, Seasoning TheSeasoning) ChooseSoup()
{
    Console.WriteLine("\t\tPick ingredients");
    Type theType = ChooseType();
    MainIngredient theMainIngredient = ChooseMainIngredient();
    Seasoning theSeasoning = ChooseSeasoning();
    return (theType, theMainIngredient, theSeasoning);
}

Type ChooseType()
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Choose among these: Soup, Stew, Gumbo");
        Console.ForegroundColor = ConsoleColor.Gray;

        string input = Console.ReadLine().ToLower();    // lowercase-ify
        if (input == "soup") return Type.Soup;
        if (input == "stew") return Type.Stew;
        if (input == "gumbo") return Type.Gumbo;

        Console.WriteLine("Not a valid type");
    }
}

MainIngredient ChooseMainIngredient()
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Choose among these: Mushrooms, Chicken, Carrots, Potatoes");
        Console.ForegroundColor = ConsoleColor.Gray;

        string input = Console.ReadLine().ToLower();    // lowercase-ify
        if (input == "mushrooms") return MainIngredient.Mushrooms;
        if (input == "chicken") return MainIngredient.Chicken;
        if (input == "carrots") return MainIngredient.Carrots;
        if (input == "potatoes") return MainIngredient.Potatoes;

        Console.WriteLine("Not a valid main ingredient");
    }
}
Seasoning ChooseSeasoning()
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Choose among these: Spicy, Salty, Sweet");
        Console.ForegroundColor = ConsoleColor.Gray;

        string input = Console.ReadLine().ToLower();    // lowercase-ify
        if (input != "spicy" && input != "salty" && input != "sweet")
        {
            Console.WriteLine("Not a valid seasoning");
            continue;
        }

        return input switch
        {
            "spicy" => Seasoning.Spicy,
            "salty" => Seasoning.Salty,
            "sweet" => Seasoning.Sweet,
        };
    }
}


// --------- ENUMERABLE ---------
enum Type { Soup, Stew, Gumbo };
enum MainIngredient { Mushrooms, Chicken, Carrots, Potatoes };
enum Seasoning { Spicy, Salty, Sweet };