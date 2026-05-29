Console.Write("Enter the number of chocolate eggs picked up today: ");
ushort eggs = Convert.ToUInt16(Console.ReadLine());

int sisterEggs = eggs / 4;
int duckbearEggs = eggs % 4;

Console.WriteLine("Each sister gets " + sisterEggs + " eggs.");
Console.WriteLine("Duckbear gets " + duckbearEggs + " eggs.");

// If we had 3 eggs, sisters would get no eggs and the duckbear all 3.
// If we had 7 eggs, sisters would get 1 egg each and the duckbear 3.
// If we had 11 eggs, sisters would get 2 eggs each and the duckbear 3.
// At 15 eggs, they would get equal amount of eggs.
// Beyond that, sisters would have more eggs than duckbear.
// A solution could be a loop, to count how many more eggs duckbear would have than sisters.