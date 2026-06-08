Console.Title = "The Card";

Colors[] colorList = new Colors[] { Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow };
Ranks[] rankList = new Ranks[] {Ranks.One, Ranks.Two, Ranks.Three, Ranks.Four, Ranks.Five,
                                Ranks.Six, Ranks.Seven, Ranks.Eight, Ranks.Nine, Ranks.Ten,
                                Ranks.DollarSign, Ranks.Percent, Ranks.Caret, Ranks.Ampersand };

int totCard = colorList.Length * rankList.Length;
int idx = 0;
Card[] cards = new Card[totCard];
foreach (Colors color in colorList)
    foreach (Ranks rank in rankList)
        cards[idx++] = new Card(color, rank);

foreach (Card card in cards)
    Console.Write($"The {card.Color} {card.Rank}. ");

public class Card
{
    public Colors Color { get; }
    public Ranks Rank { get; }

    public Card() : this(default, default) { }
    
    public Card(Colors color, Ranks rank)
    {
        Color = color;
        Rank = rank;
    }

    public bool IsSymbol => Rank == Ranks.DollarSign || Rank == Ranks.Percent ||
                            Rank == Ranks.Caret || Rank == Ranks.Ampersand;
       
    public bool IsNumber => !IsSymbol;
}

public enum Colors { Red, Green, Blue, Yellow}
public enum Ranks { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand}
