Console.Title = "The Properties of Arrows";

Arrow myArrow = GetArrow();
Console.WriteLine($"\nYour {myArrow.ArrowType} with head {myArrow.Arrowhead}, " +
    $"fletching {myArrow.Fletching} " +
    $"and length {myArrow.Length} " +
    $"costs {myArrow.Cost:F2} gold");

// Choose a new arrow instance variables
Arrow GetArrow()
{
    Console.WriteLine("Choose your arrow");
    ArrowType arrowType = ChooseArrowType();
    Arrow newArrow = arrowType switch
    {
        ArrowType.EliteArrow => Arrow.CreateEliteArrow(),
        ArrowType.BeginnerArrow => Arrow.CreateBeginnerArrow(),
        ArrowType.MarksmanArrow => Arrow.CreateMarksmanArrow(),
        ArrowType.CustomArrow => GetCustomArrow(),
    };
    return newArrow;
}

ArrowType ChooseArrowType()
{
    string[] types = Enum.GetNames<ArrowType>();
    string options = "";
    
    // Transform 'PascalCase' word into 'Pascal Case' word
    int wordCounter = 1;
    foreach (string word in types)
    {
        string adjustedWord = "";
        for (int idxChar = 0; idxChar < word.Length; idxChar++)
        {
            if (idxChar > 0 && char.IsUpper(word[idxChar]))
            {
                adjustedWord += " ";
                adjustedWord += char.ToLower(word[idxChar]);
            }
            else
                adjustedWord += word[idxChar];
        }

        options += $"{wordCounter,3} - \"{adjustedWord}\"\n";
        wordCounter++;
    }

    int choice = 0;
    while (choice < 1 || choice > types.Length)
    {
        Console.Write($"Enter a number for a type of arrow\n{options}");
        Console.Write("> ");
        choice = Convert.ToInt32(Console.ReadLine());
    }
    choice--;   // zero-index adjustment
    string type = types[choice];
    ArrowType chosenType = Enum.Parse<ArrowType>(type, true);
    return chosenType;
}

Arrow GetCustomArrow()
{
    Console.WriteLine("Create your custome arrow");
    Arrowhead newArrowhead = ChooseArrowhead();
    Fletching newFletching = ChooseFletching();
    float newShaftLength = ChooseShaftLength();
    return Arrow.CreateArrow(newArrowhead, newFletching, newShaftLength);
}

// Choose new arrow head and parse enumerable
Arrowhead ChooseArrowhead()
{
    string[] arrowheads = Enum.GetNames<Arrowhead>();
    string choices = "";
    for (int idx = 0; idx < arrowheads.Length; idx++)
        choices += $"{idx + 1,3} - \"{arrowheads[idx]}\"\n";

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
            {
                adjustedWord += ' ';
                adjustedWord += char.ToLower(word[idxChar]);
            }
            else 
                adjustedWord += word[idxChar];
        }
        choices += $"{wordCounter,3} - \"{adjustedWord}\"\n";
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
public class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public float Length { get; }

    public ArrowType ArrowType { get; }
    public Arrow() : this(default, default, 60, ArrowType.CustomArrow) { }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float shaftLength, ArrowType arrowType)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = shaftLength;
        ArrowType = arrowType;
    }

    public static Arrow CreateArrow() => new Arrow();

    public static Arrow CreateArrow(Arrowhead arrowhead, Fletching fletching, float shaftLength)
        => new Arrow(arrowhead, fletching, shaftLength, ArrowType.CustomArrow);
    
    public static Arrow CreateEliteArrow() 
        => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95f, ArrowType.EliteArrow);
    public static Arrow CreateBeginnerArrow() 
        => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75f, ArrowType.BeginnerArrow);
    public static Arrow CreateMarksmanArrow() 
        => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65f, ArrowType.MarksmanArrow);

    // Property Cost
    public float Cost
    {
        get
        {
            float arrowheadCost = Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5,
                _ => throw new NotImplementedException(),
            };
            float fletchingCost = Fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3,
                _ => throw new NotImplementedException(),
            };
            float shaftCost = Length * 0.05f;

            return arrowheadCost + fletchingCost + shaftCost;
        }
    }
}

public enum ArrowType
{
    EliteArrow,
    BeginnerArrow,
    MarksmanArrow,
    CustomArrow,
}
public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }