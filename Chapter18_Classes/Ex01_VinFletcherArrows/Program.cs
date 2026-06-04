Console.Title = "Vin Fletcher’s Arrows";


Arrow myArrow = GetArrow();
Console.WriteLine($"\nYour arrow with head {myArrow._arrowhead}, " +
    $"fletching {myArrow._fletching} " +
    $"and length {myArrow._shaftLength} " +
    $"costs {myArrow.GetCost():F2}");

// Choose a new arrow instance variables
Arrow GetArrow()
{
    Console.WriteLine("Choose your arrow");
    Arrowhead newArrowhead = ChooseArrowhead();
    Fletching newFletching = ChooseFletching();
    float newShaftLength = ChooseShaftLength();
    return new Arrow(newArrowhead, newFletching, newShaftLength);
} 

// Choose new arrow head and parse enumerable
Arrowhead ChooseArrowhead()
{
    string[] arrowheads = Enum.GetNames<Arrowhead>();
    string choices = "";
    for (int idx = 0; idx < arrowheads.Length; idx++)
        choices += $"{idx + 1, 3} - \"{arrowheads[idx]}\"\n";
    
    int choice = 0;
    while (choice < 1 || choice > arrowheads.Length)
    {
        Console.Write($"Choose the type of arrowhead among these (enter a number):\n{choices}");
        Console.Write("> ");
        choice = Convert.ToInt32(Console.ReadLine());
    }
    choice--;   // Zero-index adjustment 
    string arrowhead = arrowheads[choice];
    Arrowhead chosenArrowhead = Enum.Parse<Arrowhead>(arrowhead, true);
    return chosenArrowhead;
}

// Choose arrow fletching, parse enumerable, convert PascalWords into words with space
Fletching ChooseFletching()
{
    string[] fletchings = Enum.GetNames<Fletching>();
    string choices = "";

    // Separate "PascalCase" words into "Pascal Case" words
    int wordCounter = 1;
    foreach (string word in fletchings)
    {
        string adjustedWord = "";
        for (int idxChar = 0; idxChar < word.Length; idxChar++)
        {
            if (idxChar > 0 && char.IsUpper(word[idxChar]))
                adjustedWord += ' ';
            adjustedWord += word[idxChar];
        }
        choices += $"{wordCounter, 3} - \"{adjustedWord}\"\n";
        wordCounter++;
    }

    int choice = 0;
    while (choice < 1 || choice > fletchings.Length)
    {
        Console.Write($"Choose a fletching type among these (enter a number):\n{choices}");
        Console.Write("> ");
        choice = Convert.ToInt32(Console.ReadLine());
    }
    choice--; // Zero-index adjustment
    string fletching = fletchings[choice];
    Fletching chosenFletching = Enum.Parse<Fletching>(fletching, true);
    return chosenFletching;
}

// Choose arrow length
float ChooseShaftLength()
{
    float length = 0f;
    while (length < 60 || length > 100)
    {
        Console.Write("Choose a shaft length between 60 and 100 (cm): ");
        length = Convert.ToSingle(Console.ReadLine());
    }
    return length;
}
class Arrow
{
    public Arrowhead _arrowhead;
    public Fletching _fletching;
    public float _shaftLength;

    public Arrow(): this(default, default, 60) { }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float shaftLength)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _shaftLength = shaftLength;
    }

    // Compute cost of an arrow based on the instance variables
    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
            _ => throw new NotImplementedException(),
        };

        float fletchingCost = _fletching switch 
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
            _ => throw new NotImplementedException(),
        };

        float shaftCost = _shaftLength * 0.05f;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}
enum Arrowhead { Steel, Wood, Obsidian }
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }