Console.WriteLine("What kind of thing are we talking about?");

// A thing
string thing = Console.ReadLine();  
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");

// An adjective
string adjective = Console.ReadLine();  
string whom = "Doom";
string number = "3000";
Console.WriteLine("The " + adjective + " " + thing + " of " + whom + " " + number + "!");