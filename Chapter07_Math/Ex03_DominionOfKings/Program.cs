Console.WriteLine("Melik's kingdom");
Console.Write("Enter number of estates: ");
uint estates = Convert.ToUInt32(Console.ReadLine());
Console.Write("Enter number of duchies: ");
uint duchies = Convert.ToUInt32(Console.ReadLine());
Console.Write("Enter number of provinces: ");
uint provinces = Convert.ToUInt32(Console.ReadLine());

uint points = estates * 1 + duchies * 3 + provinces * 6;
Console.WriteLine("Tot points: " + points);

