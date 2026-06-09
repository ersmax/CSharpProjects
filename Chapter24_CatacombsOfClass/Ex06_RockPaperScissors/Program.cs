Console.Title = "Rock-Paper-Scissors";

Game aGame = new Game();
PlayGame(aGame);

void PlayGame(Game aGame)
{
    while (true)
    {
        aGame.ShowResults();
        Console.Write("Continue to play? (y/n): ");
        string answer = Console.ReadLine() ?? "not valid";
        if (answer == "n")
            break;
        Console.Clear();
        aGame.PlayAnotherRound();
    }
}

public class Game
{
    private Round _round;
    public static int GameN { get; private set; }
    public Records HistoricalRecord { get; private set; }

    public Game()
    {
        _round = new Round();
        HistoricalRecord = new Records(null, 0, _round.RoundState);
        GameN += 1;
    }

    public void PlayAnotherRound()
    {
        _round = new Round();
        HistoricalRecord = new Records(HistoricalRecord.Statistics, GameN, _round.RoundState);
        GameN++;
    }

    public void ShowResults()
    {
        Console.WriteLine($"Game number: {GameN}");
        if (_round.RoundState == State.Draw)
            Console.ForegroundColor = ConsoleColor.DarkRed;
        else
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Round winner: {_round.RoundState}");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        
        HistoricalRecord.ShowStatistics();
        Console.ForegroundColor = ConsoleColor.White;
    }
}

public class Records
{
    public State[] Statistics { get; }

    public Records(State[]? oldStatistics, int rounds, State newOutcome)
    {
        Statistics = new State[rounds + 1];
        CopyOldStatistics(oldStatistics, rounds);
        Statistics[rounds] = newOutcome;
    }

    public void ShowStatistics()
    {
        if (Statistics.Length == 0) return;
        for (int idx = 0; idx < Statistics.Length; idx++)
            Console.WriteLine($"Round {idx + 1, 2} outcome: {Statistics[idx]}");
    }

    private void CopyOldStatistics(State[]? oldStatistics, int rounds)
    {
        if (rounds == 0 || oldStatistics == null) return;
        for (int idx = 0; idx < rounds; idx++)
            Statistics[idx] = oldStatistics[idx]; 
    }
}

public class Round
{
    public State RoundState { get; }

    private Player[] Players { get; } = new Player[2];
    public Round()
    { 
        Console.WriteLine("Player 1 turn");
        Players[0] = new Player();
        Console.WriteLine("Player 2 turn");
        Players[1] = new Player();
        RoundState = PlayRound();
    }

    private State PlayRound()
    {
        if (Players[0].Tool == Tool.Rock && Players[1].Tool == Tool.Scissor) return State.Player1;
        if (Players[0].Tool == Tool.Rock && Players[1].Tool == Tool.Paper) return State.Player2;
        if (Players[0].Tool == Tool.Scissor && Players[1].Tool == Tool.Paper) return State.Player1;
        if (Players[0].Tool == Tool.Scissor && Players[1].Tool == Tool.Rock) return State.Player2;
        if (Players[0].Tool == Tool.Paper && Players[1].Tool == Tool.Rock) return State.Player1;
        if (Players[0].Tool == Tool.Paper && Players[1].Tool == Tool.Scissor) return State.Player2;
        return State.Draw;
    }
}

public class Player
{
    public Tool Tool { get; }

    public Player()
    {
        Tool = EnterTool();
    }

    private Tool EnterTool()
    {
        string[] options = Enum.GetNames<Tool>();
        string display = "";
        foreach (string option in options)
            display += $" \"{option}\"";
        bool valid = false;
        string input = "not valid";
        while (!valid)
        {
            Console.WriteLine($"Enter one type: {display}");
            Console.Write("> ");
            input = Console.ReadLine() ?? "not valid";
            foreach (string option in options)
                if (option.ToLower() == input.ToLower())
                    valid = true;
        }
        return Enum.Parse<Tool>(input, true);
    }
}

public enum Tool { Rock, Paper, Scissor}
public enum State { Player1, Player2, Draw}