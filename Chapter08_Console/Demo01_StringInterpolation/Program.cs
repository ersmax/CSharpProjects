// Some examples of string interpolation in console
Console.Write("Enter first name: ");
string name1 = Console.ReadLine();
Console.Write("Enter second name: ");
string name2 = Console.ReadLine();

// Space before the whitespace
Console.WriteLine($"#1: {name1,20}");
Console.WriteLine($"#2: {name2,20}");

// Space after the whitespace
Console.WriteLine($"{name1, -20} - 1 place");
Console.WriteLine($"{name2,-20} - 2 place");

// Format necessary digits
Console.Write("Enter a number: ");
double number = Convert.ToDouble(Console.ReadLine());
Console.Write("Enter a second number: ");
double number2 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"The first number is {number:0.##} and the second is: {number2:0.##}");
Console.WriteLine($"The first number is {number:F} and the second is: {number2:F5}");
Console.WriteLine($"That is {number / number2:0.0##%}");
Console.WriteLine($"That is {number / number2:P}");
Console.WriteLine($"That is {number / number2:P3}");

