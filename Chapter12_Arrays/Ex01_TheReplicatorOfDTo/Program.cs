Console.Title = "The Replicator of D’To";

int[] container = new int[5];
for (int idx = 0; idx < container.Length; idx++)
{
    Console.Write($"Enter a number for the {idx + 1} element: ");
    container[idx] = Convert.ToInt32(Console.ReadLine());
}

int[] replicator = container[..];   // copy all element

for (int idx = 0; idx < container.Length; idx++)
{
    Console.WriteLine($"Element {idx + 1,-2} of container: {container[idx]}");
    Console.WriteLine($"Element {idx + 1,-2} of replicator: {replicator[idx]}");
}
