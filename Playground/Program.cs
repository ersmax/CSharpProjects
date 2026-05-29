var test = 127L;
int bigNumber = 1_000_000_000;
double avogadrosNumber = 6.022e23;
Console.WriteLine(int.MaxValue);
Console.WriteLine(double.MinValue);
Console.WriteLine(double.PositiveInfinity);
Console.WriteLine(double.NegativeInfinity);
Console.WriteLine(double.NaN);
// NaN because 0 is interpreted as small quantity for double division
Console.WriteLine(avogadrosNumber / 0); 