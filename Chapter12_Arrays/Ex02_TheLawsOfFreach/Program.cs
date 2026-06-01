using System.Linq.Expressions;

Console.Title = "The Laws of Freach";

int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

int minimum = int.MaxValue;
float total = 0f;
for (int idx = 0; idx <  array.Length; idx++)
{
    minimum = (array[idx] <  minimum) ? array[idx] : minimum;
    total += array[idx];
}

double average = total / array.Length;
Console.WriteLine($"Minimum: {minimum, 10}");
Console.WriteLine($"Average: {average, 10:F2}");

// Foreach part
minimum = int.MaxValue;
total = 0f;
foreach (int number in array)
{
    minimum = (number < minimum) ? number : minimum;
    total += number;
}
average = total / array.Length;
Console.WriteLine($"Minimum: {minimum,10}");
Console.WriteLine($"Average: {average,10:F}");
