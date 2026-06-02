var test = 127L;
int bigNumber = 1_000_000_000;
double avogadrosNumber = 6.022e23;
Console.WriteLine(int.MaxValue);
Console.WriteLine(double.MinValue);
Console.WriteLine(double.PositiveInfinity);
Console.WriteLine(double.NegativeInfinity);
Console.WriteLine(double.NaN);
// Testing division by 0
// NaN because 0 is interpreted as small quantity for double division
Console.WriteLine(avogadrosNumber / 0);

// Testing casting
int anInt = 2568;
byte aByte = (byte)anInt;
Console.WriteLine(aByte);

// Testing overflow
byte maxByte = 255;
byte overflowByte = (byte)(maxByte + 1);
Console.WriteLine(overflowByte);

double maxDouble = double.MaxValue;
double overflowDouble = maxDouble * 2;
Console.WriteLine(overflowDouble);

// Testing roundoff error
float a = 100000;
float b = 0.000001f;
float resultAandB = a + b;
Console.WriteLine(resultAandB);

// Testing Console methods
Console.WriteLine("Press any key to continue..");
//Console.ReadKey();
//Console.ReadKey(true);    // Does not show up the keys on screen
//Console.BackgroundColor = ConsoleColor.Black;
//Console.ForegroundColor = ConsoleColor.Green;
//Console.Clear();    // Erase text on screen
Console.Title = "My title";
//Console.Beep(440, 500);
Console.WriteLine($"The result of a ({a}) + a is equal to {a + a} ");

// Testing String interpolation
//string name1 = Console.ReadLine();
//string name2 = Console.ReadLine();
//Console.WriteLine($"#1: {name1, 20}");
//Console.WriteLine($"#2: {name2, 20}");

// Testing arrays
int[] scores = new int[] {1, 2, 3};
int[] scores2 = scores[..];
scores2[^1] = 10;
for (int idx = 0; idx < scores.Length; idx++)
    Console.WriteLine(scores[idx]);

int[][] matrix = new int[3][];
matrix[0] = new int[] { 1, 2 };
matrix[1] = new int[] { 3, 4 };
matrix[2] = new int[] { 5, 6 };

foreach (int[] row in matrix)
{
    foreach (int col in row)
        Console.Write($"{col} ");
    Console.WriteLine();
}

int[,] matrixCopy = new int[3,2] {{6, 5}, {4, 3}, {2, 1}};

for (int row = 0; row < matrixCopy.GetLength(0); row++)
{
    for (int col = 0; col < matrixCopy.GetLength(1); col++)
        Console.Write(matrixCopy[row,col] + " ");
    Console.WriteLine();

}


