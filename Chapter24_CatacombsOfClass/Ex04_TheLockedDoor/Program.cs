Console.Title = "The Locked Door";

Door aDoor = new Door(EnterNumber("Enter passcode:"), ChooseStatus());
Console.Clear();
while (true)
{
    handleChoice(aDoor);
    Console.Write("Exit (y/n)? ");
    if (Console.ReadLine()?.ToLower() == "y")
        break;
}

Status ChooseStatus()
{
    string[] options = Enum.GetNames<Status>();
    string display = "";
    foreach (string option in options)
        display += $" \"{option}\"";

    bool valid = false;
    string? inputString;
    do
    {
        valid = false;
        Console.WriteLine($"What option do you choose among these? {display}");
        inputString = Console.ReadLine();
        foreach (string option in options)
            if (inputString?.ToLower() == option.ToLower())
            {
                valid = true;
                break;
            }
      
    } while (!valid || inputString == null);

    Status input = Enum.Parse<Status>(inputString, true);
    return input;
}

void handleChoice(Door aDoor)
{
    Console.WriteLine($"Door status: {aDoor.Status}.");
    Console.WriteLine("Enter action among these ('Open', 'Close', 'Lock', 'Unlock', 'Changing passcode')");
    Console.Write("> ");
    string? input = Console.ReadLine()?.ToLower();
    switch (input)
    {
        case "open":
            aDoor.Open();
            break;
        case "close":
            aDoor.Close();
            break;
        case "lock":
            aDoor.Lock();
            break;
        case "unlock":
            aDoor.Unlock();
            break;
        case "changing passcode":
            int oldPasscode = EnterNumber("Enter old passcode:");
            aDoor.ChangePasscode();
            break;
        default:
            Console.WriteLine("Not a valid option");
            break;
    }
}

int EnterNumber(string text)
{
    Console.Write(text + " ");
    return Convert.ToInt32(Console.ReadLine());
}
public class Door
{
    private int _passcode;
    public Status Status { get; private set; }

    public Door() : this(1234, Status.Open) { }

    public Door(int passcode) : this(passcode, Status.Open) { }

    public Door(int passcode, Status status)
    {
        _passcode = passcode;
        Status = status;
    }

    public void Close()
    {
        if (Status == Status.Open)
            Status = Status.Closed;
    }
    public void Open()
    {
        if (Status == Status.Closed)
            Status = Status.Open;
    }
    public void Lock() 
    {
        if (Status == Status.Closed)
            Status = Status.Locked;
    }
    public void Unlock()
    {
        Console.Write("Enter password: ");
        int input = Convert.ToInt32(Console.ReadLine());
        if (Status == Status.Locked && input == _passcode)
            Status = Status.Closed;
    }

    public void ChangePasscode()
    {
        Console.Write("Enter the old passcode: ");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input != _passcode)
        {
            Console.WriteLine("Passcode does not match. Abort");
            return;
        }
        Console.Write("Enter new password: ");
        input = Convert.ToInt32(Console.ReadLine());
        _passcode = input;
    }

}

public enum Status { Open, Closed, Locked }
