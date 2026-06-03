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
        
        string input = Console.ReadLine();
        if (input == "Soup")    return Type.Soup;
        if (input == "Stew")    return Type.Stew;
        if (input == "Gumbo")   return Type.Gumbo;
        
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

        string input = Console.ReadLine();
        if (input == "Mushrooms")   return MainIngredient.Mushrooms;
        if (input == "Chicken")     return MainIngredient.Chicken;
        if (input == "Carrots")     return MainIngredient.Carrots;
        if (input == "Potatoes")    return MainIngredient.Potatoes;

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

        string input = Console.ReadLine();
        if (input != "Spicy" && input != "Salty" && input != "Sweet")
        {
            Console.WriteLine("Not a valid seasoning");
            continue;
        }

        return input switch
        {
            "Spicy" => Seasoning.Spicy,
            "Salty" => Seasoning.Salty,
            "Sweet" => Seasoning.Sweet,
        };
    }
}


// --------- ENUMERABLE ---------
enum Type { Soup, Stew, Gumbo};
enum MainIngredient { Mushrooms, Chicken, Carrots, Potatoes};
enum Seasoning { Spicy, Salty, Sweet};
