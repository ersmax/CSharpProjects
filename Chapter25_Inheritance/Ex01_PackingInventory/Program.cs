Console.Title = "Packing Inventory";

Pack backpack = new Pack(10, 20, 30);
string answer = "y";
while (answer != "n")
{
    Console.Clear();
    Console.WriteLine("Backpack capacity:");
    Console.WriteLine($"Items: {backpack.ItemsCount} / {backpack.MaxItems}");
    Console.WriteLine($"Weight: {backpack.WeightCount:F} / {backpack.MaxWeight}");
    Console.WriteLine($"Volume: {backpack.VolumeCount:F} / {backpack.MaxVolume}");
    Item option = ChooseItem();
    InventoryItem item = option switch
    {
        Item.Arrow => Arrow.CreateArrow(),
        Item.Bow => Bow.CreateBow(),
        Item.Food => FoodRations.CreateFoodRations(),
        Item.Rope => Rope.CreateRope(),
        Item.Sword => Sword.CreateSword(),
        Item.Water => Water.CreateWater()
    };
    backpack.Add(item);
    Console.WriteLine("Continue? (y/n)");
    answer = Console.ReadLine()?.ToLower() ?? "y";
}
Pack.ShowBackpack();

Item ChooseItem()
{
    string[] options = Enum.GetNames<Item>();
    string display = "";
    for (int idx = 0; idx < options.Length; idx++)
        display += $"{idx + 1,2}. {options[idx]}\n";

    int option = -1;
    while (option < 0 || option >= options.Length)
    {
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
    private static InventoryItem[] Backpack = Array.Empty<InventoryItem>();
    
    public int MaxItems { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }
    public int ItemsCount { get; private set; }
    public float WeightCount { get; private set; }
    public float VolumeCount { get; private set; }

    public Pack(int items, float weight, float volume)
    {
        MaxItems = items;
        MaxWeight = weight;
        MaxVolume = volume;
    }

    public static void ShowBackpack()
    {
        for (int idx = 0; idx < Backpack.Length; idx++)
            Console.WriteLine($"Item {idx + 1, 2}: {Backpack[idx].ToString()}");
    }

    public bool Add(InventoryItem item)
    {
        if (!CanBeAdded(item))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Cannot add this element");
            Console.ResetColor();
            return false;
        }
        Array.Resize(ref Backpack, Backpack.Length + 1);
        Backpack[^1] = item;
        ItemsCount++;
        WeightCount += item.Weight;
        VolumeCount += item.Volume;
        return true;
    }

    private bool CanBeAdded(InventoryItem item)
    {
        if (MaxItems < ItemsCount + 1) return false;
        if (MaxWeight < WeightCount + item.Weight) return false;
        if (MaxVolume < VolumeCount + item.Volume) return false;
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
}

public class Bow : InventoryItem
{
    public Bow() : base(1.0f, 4.0f) { }
    public static Bow CreateBow() => new Bow();
}

public class Rope : InventoryItem
{
    public Rope() : base(1.0f, 1.5f) { }
    public static Rope CreateRope() => new Rope();
}

public class Water : InventoryItem
{
    public Water() : base(2.0f, 3.0f) { }
    public static Water CreateWater() => new Water();
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1.0f, 0.5f) { }
    public static FoodRations CreateFoodRations() => new FoodRations();
}

public class Sword : InventoryItem
{
    public Sword() : base(5.0f, 3.0f) { }
    public static Sword CreateSword() => new Sword();
}

public enum Item { Arrow, Bow, Rope, Water, Food, Sword}