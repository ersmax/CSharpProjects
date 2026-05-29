Console.Title = "Defense of Consolas";
Console.Write("Target Row? ");
int targetRow = Convert.ToInt32(Console.ReadLine());
Console.Write("Target Column? ");
int targetColumn = Convert.ToInt32(Console.ReadLine());

// ensure target is in range
targetRow = Math.Clamp(targetRow, 1, 8);
targetColumn = Math.Clamp(targetColumn, 1, 8);

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine($"Target is at (row, column): ({targetRow}, {targetColumn})");
Console.ForegroundColor = ConsoleColor.White;

int rowPawn1 = targetRow - 1;
int colPawn1 = targetColumn;
int rowPawn2 = targetRow;
int colPawn2 = targetColumn + 1;
int rowPawn3 = targetRow + 1;
int colPawn3 = targetColumn;
int rowPawn4 = targetRow;
int colPawn4 = targetColumn - 1;


Console.WriteLine("Deploy to:");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"({rowPawn1}, {colPawn1})");
Console.WriteLine($"({rowPawn2}, {colPawn2})");
Console.WriteLine($"({rowPawn3}, {colPawn3})");
Console.WriteLine($"({rowPawn4}, {colPawn4})");
Console.Beep();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Press a key to exit");
Console.ReadKey(true);