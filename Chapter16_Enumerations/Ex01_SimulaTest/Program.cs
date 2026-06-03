Console.Title = "Simula’s Test";

State current = State.locked;
while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Choice menu: open/close/lock/unlock");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write($"The chest is {current}. What do you want to do? ");
    string input = Console.ReadLine();
    if (input == "open" && current == State.unlocked) current = State.open;
    else if (input == "close" && current == State.open) current = State.unlocked;
    else if (input == "lock" && current == State.unlocked) current = State.locked;
    else if (input == "unlock" && current == State.locked) current = State.unlocked;
    else Console.WriteLine("Not a valid action");
}

enum State { open, unlocked, locked }
