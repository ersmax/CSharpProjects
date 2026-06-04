// switch based parsing using strings
ElixirType purchase;
do
{
    Console.WriteLine(
        "What type of elixir do you want? Options are 'invisibility', 'strength', 'regeneration', and 'coffee'.");
    string input = Console.ReadLine().ToLower();    // lowercase-ify
    purchase = input switch
    {
        "invisibility" => ElixirType.Invisibility,
        "strength" => ElixirType.Strength,
        "regeneration" => ElixirType.Regeneration,
        "coffee" => ElixirType.Coffee,
        _ => ElixirType.Invalid,
    };
    if (purchase == ElixirType.Invalid)
        Console.WriteLine("That wasn't a valid option. Try it again.");

} while (purchase == ElixirType.Invalid);




enum ElixirType
{
    Invisibility,
    Strength,
    Regeneration,
    Coffee,
    Invalid
};
