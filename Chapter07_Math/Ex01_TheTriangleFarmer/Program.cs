double theBase, theHeight;
Console.Write("Enter the base: ");
theBase = Convert.ToDouble(Console.ReadLine());
Console.Write("Enter the height: ");
theHeight = Convert.ToDouble(Console.ReadLine());

double theArea = theBase * theHeight / 2.0;
Console.WriteLine("The area of a triangle with base: " + 
                  theBase + " and height " + theHeight +
                  " is: " + theArea);