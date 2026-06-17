Console.Title = "The Old Robot";

Robot aRobot = new Robot();
while (true)
{
    Command input = ChooseCommand();
    RobotCommand command = input switch
    {
        Command.On => new OnCommand(),
        Command.Off => new OffCommand(),
        Command.North => new NorthCommand(),
        Command.South => new SouthCommand(),
        Command.East => new EastCommand(),
        Command.West => new WestCommand(),
    };
    aRobot.AddCommand(command);
    Console.WriteLine("Enter new command? (y/n)");
    string? quit = Console.ReadLine()?.ToLower();
    if (quit == "n") break;
    Console.Clear();
}
Console.Clear();
aRobot.Run();


Command ChooseCommand()
{
    string[] options = Enum.GetNames<Command>();
    string display = "";
    foreach (string option in options)
        display += $" \"{option}\"";
    
    string input = "not valid";
    bool validInput = false;
    while (!validInput)
    {
        Console.WriteLine($"Write an option: {display}");
        Console.Write("> ");
        input = Console.ReadLine() ?? "not valid";
        foreach (string option in options)
            if (option.ToLower() == input.ToLower())
            {
                validInput = true;
                break;
            }
        Console.Clear();
    }
    return Enum.Parse<Command>(input, true);
}

public class Robot 
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; private set; } = Array.Empty<RobotCommand>();

    public void AddCommand(RobotCommand aCommand)
    {
        RobotCommand?[] temp = Commands;
        Array.Resize(ref temp, temp.Length + 1);
        temp[^1] = aCommand;
        Commands = temp;
    }

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"Position: (x:{X}, y:{Y}). Is powered: {IsPowered}");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot aRobot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot aRobot) => aRobot.IsPowered = true;
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot aRobot) => aRobot.IsPowered = false;
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot aRobot) { if (aRobot.IsPowered) aRobot.Y++; }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot aRobot) { if (aRobot.IsPowered) aRobot.Y--; }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot aRobot) { if (aRobot.IsPowered) aRobot.X--; }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot aRobot) { if (aRobot.IsPowered) aRobot.X++; }
}

public enum Command {On, Off, North, South, West, East}