Console.Title = "The Old Robot";

// TODO : orchestrate main

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
            Console.WriteLine($"[Position: {X} {Y}. Is powered: {IsPowered}]");
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