Console.Title = "The Locked Door";

Door aDoor = new Door(ChooseInitialPwd(), ChooseStatus());
Console.Clear();
while (true)
{
    handleChoice(aDoor);
    Console.Write("Exit (y/n)? ");
    if (Console.ReadLine().ToLower() == "y")
        break;
}

Status ChooseStatus()
{
    string[] options = Enum.GetNames<Status>();
    string display = "";
    foreach (string option in options)
        display += $" \"{option}\"";
    Console.WriteLine($"What option do you choose among these? {display}");
    Status input = Enum.Parse<Status>(Console.ReadLine(), true);
    return input;
}

string ChooseInitialPwd()
{
    Console.Write("Enter password: ");
    return Console.ReadLine();
}

void handleChoice(Door aDoor)
{
    Console.WriteLine($"Door status: {aDoor.Status}.");
    Console.WriteLine("Enter action among these ('open', 'close', 'locking', 'unlocking', 'changing passcode')");
    Console.Write("> ");
    string input = Console.ReadLine();
    switch (input)
    {
        case "open":
            aDoor.open();
            break;
        case "close":
            aDoor.close();
            break;
        case "locking":
            aDoor.locking();
            break;
        case "unlocking":
            aDoor.unlocking();
            break;
        case "changing passcode":
            aDoor.changePassword();
            break;
        default:
            Console.WriteLine("Not a valid option");
            break;
    }
}

public class Door
{
    private string Passcode { get; set; }
    public Status Status { get; private set; }

    public Door() : this("password", Status.Open) { }

    public Door(string password) : this(password, Status.Open) { }

    public Door(string password, Status status)
    {
        Passcode = password;
        Status = status;
    }

    public void close()
    {
        if (Status == Status.Open)
            Status = Status.Closed;
    }
    public void open()
    {
        if (Status == Status.Closed)
            Status = Status.Open;
    }
    public void locking() 
    {
        if (Status == Status.Closed)
            Status = Status.Locked;
    }
    public void unlocking()
    {
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        if (Status == Status.Locked && password == Passcode)
            Status = Status.Closed;
    }

    public void changePassword()
    {
        Console.Write("Enter the old password: ");
        string input = Console.ReadLine();
        if (input != Passcode)
        {
            Console.WriteLine("Password do not match. Abort");
            return;
        }
        while (true)
        { 
            Console.Write("Enter new password: ");
            input = Console.ReadLine();
            if (input == null)
                continue;
            else break;
        }
        Passcode = input;
    }

}

public enum Status { Open, Closed, Locked }
