Console.Title = "Labeling Inventory";

Pack backpack = new Pack(10, 20, 30);
string answer = "y";
while (answer != "n")
{
    Console.Clear();
    string text = backpack.ToString() + '\n';
    text += "Backpack capacity:\n";
    text += $"Items: {backpack.CurrentItems} / {backpack.MaxItems}\n";
    text += $"Weight: {backpack.CurrentWeight:F1} / {backpack.MaxWeight:f1}\n";
    text += $"Volume: {backpack.CurrentVolume:F1} / {backpack.MaxVolume:f1}\n";
    Item option = ChooseItem(text);
    InventoryItem item = option switch
    {
        Item.Arrow => Arrow.CreateArrow(),
        Item.Bow => Bow.CreateBow(),
        Item.Food => FoodRations.CreateFoodRations(),
        Item.Rope => Rope.CreateRope(),
        Item.Sword => Sword.CreateSword(),
        Item.Water => Water.CreateWater()
    };
    if (!backpack.Add(item))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Max capacity reached");
        Console.ResetColor();
    }
    Console.WriteLine(item);
    //backpack.ShowBackpack();
    Console.WriteLine("Continue? (y/n)");
    answer = Console.ReadLine()?.ToLower() ?? "y";
}

Item ChooseItem(string text)
{
    string[] options = Enum.GetNames<Item>();
    string display = "";
    for (int idx = 0; idx < options.Length; idx++)
        display += $"{idx + 1,2}. {options[idx]}\n";

    int option = -1;
    while (option < 0 || option >= options.Length)
    {
        Console.Clear();
        Console.WriteLine(text);
        Console.WriteLine("Enter a number of the item of your choice.");
        Console.WriteLine($"{display}");
        Console.Write("> ");

        option = Convert.ToInt32(Console.ReadLine());
        option--;
    }
    string item = options[option];
    return Enum.Parse<Item>(item, true);
}

public class Pack
{
    private InventoryItem[] _backpack = Array.Empty<InventoryItem>();

    public int MaxItems { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }
    public int CurrentItems { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }

    public Pack(int items, float weight, float volume)
    {
        MaxItems = items;
        MaxWeight = weight;
        MaxVolume = volume;
    }

    //method not needed anymore
    //public void ShowBackpack()
    //{
    //    for (int idx = 0; idx < _backpack.Length; idx++)
    //        Console.WriteLine($"Item {idx + 1,2}: {_backpack[idx]}");
    //}

    public override string ToString()
    {
        if (_backpack.Length == 0) return "Pack is empty";
        
        string items = "Pack containing ";
        foreach (InventoryItem item in _backpack) 
            items += $"{item.ToString()} ";
        return items;
    }

    public bool Add(InventoryItem item)
    {
        if (!CanBeAdded(item)) return false;

        Array.Resize(ref _backpack, _backpack.Length + 1);
        _backpack[^1] = item;
        CurrentItems++;
        CurrentWeight += item.Weight;
        CurrentVolume += item.Volume;
        return true;
    }

    private bool CanBeAdded(InventoryItem item)
    {
        if (MaxItems < CurrentItems + 1) return false;
        if (MaxWeight < CurrentWeight + item.Weight) return false;
        if (MaxVolume < CurrentVolume + item.Volume) return false;
        return true;
    }
}

public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.05f) { }
    public static Arrow CreateArrow() => new Arrow();

    public override string ToString() => "Arrow";
}

public class Bow : InventoryItem
{
    public Bow() : base(1.0f, 4.0f) { }
    public static Bow CreateBow() => new Bow();

    public override string ToString() => "Bow";
}

public class Rope : InventoryItem
{
    public Rope() : base(1.0f, 1.5f) { }
    public static Rope CreateRope() => new Rope();

    public override string ToString() => "Rope";
}

public class Water : InventoryItem
{
    public Water() : base(2.0f, 3.0f) { }
    public static Water CreateWater() => new Water();

    public override string ToString() => "Water";
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1.0f, 0.5f) { }
    public static FoodRations CreateFoodRations() => new FoodRations();

    public override string ToString() => "Food";
}

public class Sword : InventoryItem
{
    public Sword() : base(5.0f, 3.0f) { }
    public static Sword CreateSword() => new Sword();

    public override string ToString() => "Sword";
}

public enum Item { Arrow, Bow, Rope, Water, Food, Sword }