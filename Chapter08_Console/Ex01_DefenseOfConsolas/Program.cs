Console.Title = "Defense of Consolas";
Console.Write("Target Row (1-8)? ");
int targetRow = Convert.ToInt32(Console.ReadLine());
Console.Write("Target Column (1-8)? ");
int targetColumn = Convert.ToInt32(Console.ReadLine());

// ensure target is in range
targetRow = Math.Clamp(targetRow, 1, 8);
targetColumn = Math.Clamp(targetColumn, 1, 8);

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine($"Target is at (row, column): ({targetRow}, {targetColumn})");
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("Deploy to:");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"({targetRow - 1}, {targetColumn})");
Console.WriteLine($"({targetRow}, {targetColumn + 1})");
Console.WriteLine($"({targetRow + 1}, {targetColumn})");
Console.WriteLine($"({targetRow}, {targetColumn - 1})");
Console.Beep();

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Press a key to exit");
Console.ReadKey(true);