Console.Title = "15-Puzzle";

Game aGame = new Game();
aGame.Play();

/// <summary>
/// This class GAME orchestrates the whole play
/// </summary>
public class Game
{
    // Initialize the board, slide the tiles, count moves, show win
    public void Play()
    {
        Board grid = new Board();
        Player player = new Player();
        grid.ShowGrid();
        
        while (!grid.Win())
        {
            Console.WriteLine($"Number of moves: {player.MoveCount}");
            player.AttemptToMove(grid);
            Console.WriteLine("Press a key to continue");
            Console.ReadKey(true);
            Console.Clear();
            grid.ShowGrid();
        }

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Game over!");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"Number of moves: {player.MoveCount}");
        Console.ResetColor();
        Console.WriteLine("Press a key to exit");
        Console.ReadKey(true);
    }
}

/// <summary>
/// This class PLAYER allows the user to play by choosing tiles to slide
/// </summary>
public class Player
{
    public int MoveCount { get; private set; }

    // Choose the tile to move
    public sbyte ChooseTile(int maxValue)
    {
        sbyte tile;
        do
        {
            Console.WriteLine($"Choose a valid tile to move (1-{maxValue})");
            Console.Write("> ");
            tile = Convert.ToSByte(Console.ReadLine());
        } while (tile <= 0 && tile > maxValue);

        return tile;
    }

    // Choose the direction to move the tile
    public Moves ChooseMove()
    {
        string[] options = Enum.GetNames<Moves>();
        string display = "";
        foreach (string option in options)
            display += $" \"{option}\"";
        
        bool validInput = false;
        string input = "not valid";
        while (!validInput)
        {
            Console.WriteLine($"Choose one of the following moves: {display}");
            Console.Write("> ");
            input = Console.ReadLine()?.Trim() ?? "not valid";
            foreach (string option in options)
                if (option.ToLower() == input.ToLower())
                    validInput = true;
        }

        return Enum.Parse<Moves>(input, true);
    }

    // Allow the player to move the tile into the chosen direction
    public void AttemptToMove(Board aBoard)
    {
        sbyte tile = ChooseTile(aBoard.MaxValue);
        Moves aMove = ChooseMove();
        if (aBoard.Slide(aMove, tile))
            MoveCount++;
    }
}

/// <summary>
/// This class BOARD handles the logic to move a tile 
/// </summary>
public class Board
{
    public sbyte[,] Grid { get; }
    public sbyte MaxValue { get; }
    
    public Board()
    {
        MaxValue = 15;
        Grid = new Generator().InitializeBoard(MaxValue);
    }

    public void ShowGrid()
    {
        for (int row = 0; row < Grid.GetLength(0); row++)
        {
            for (int col = 0; col <  Grid.GetLength(1); col++) 
                if (Grid[row, col] < 0)
                    Console.Write($"{"", 3}");
                else    
                    Console.Write($"{Grid[row, col], 3}");
            Console.WriteLine();
        }
    }

    // Check if the tiles are in order, including rows wrap-around
    public bool Win()
    {
        int lastRow = Grid.GetLength(0) - 1;
        int lastColumn = Grid.GetLength(1) - 1;
        int lastColumnNumber = Grid[0, lastColumn];

        for (int row = 0; row < Grid.GetLength(0) - 1; row++)
        {
            // first element in the next row is greater than the last element in the prev row 
            if (row > 0 && Grid[row, 0] < lastColumnNumber) return false;

            for (int col = 1; col < Grid.GetLength(1); col++)
                if (Grid[row, col] < Grid[row, col - 1])
                    return false;
            
            lastColumnNumber = Grid[row, lastColumn];
        }

        // first element int the last row is greater than the last element in the prev row
        if (Grid[lastRow, 0] < lastColumnNumber) return false;
        
        for (int col = 1; col < Grid.GetLength(1) - 1; col++)
        {

            if (Grid[lastRow, col] < Grid[lastRow, col - 1])
                    return false;
        }

        return Grid[lastRow, lastColumn] < 0;
    }

    // Allows the player to slide a tile if the chosen direction is valid and inform so
    public bool Slide(Moves move, sbyte tile)
    {
        if (!ValidMove(move, tile))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not a valid move");
            Console.ResetColor();
            return false;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Tile moved!");
        Console.ResetColor();
        return true;
    }

    // Check whether the move is valid and update the Grid
    private bool ValidMove(Moves move, sbyte tile)
    {
        byte row = new Coordinate(Grid, tile).PositionX;
        byte column = new Coordinate(Grid, tile).PositionY;

        bool validMove = false;
        sbyte newRow = (sbyte)row;
        sbyte newColumn = (sbyte)column;
        switch (move)
        {
            case Moves.Up:
                newRow = (sbyte)(row - 1);
                if (newRow >= 0 && Grid[newRow, column] < 0) validMove = true;
                break;
            case Moves.Down:
                newRow = (sbyte)(row + 1);
                if (newRow < Grid.GetLength(0) && Grid[newRow, column] < 0) validMove = true;
                break;
            case Moves.Left:
                newColumn = (sbyte)(column  - 1);
                if (newColumn >= 0 && Grid[row, newColumn] < 0) validMove = true;
                break;
            case Moves.Right:
                newColumn = (sbyte)(column + 1);
                if (newColumn < Grid.GetLength(1) && Grid[row, newColumn] < 0) validMove = true;
                break;
        }

        if (validMove)
        {
            sbyte emptyTyle = Grid[newRow, newColumn];
            Grid[newRow, newColumn] = tile;
            Grid[row, column] = emptyTyle;
        }
        return validMove;
    }
}


/// <summary>
/// Initialize board to pre-defined values. -1 denotes empty
/// </summary>
public class Generator
{
    public sbyte[,] InitializeBoard(sbyte maxValue)
    {
        sbyte[,] matrix = new sbyte[4, 4]
        {
            { 1, 3, 10, 13 },
            { 4, 2, -1, 6 },
            { 11, 8, 7, 12 },
            { 9, 14, 5, maxValue }
        };
        return matrix;
    }
}

/// <summary>
/// Compute the correct coordinates on the grid
/// </summary>
public class Coordinate
{
    public byte PositionX { get; private set; }
    public byte PositionY { get; private set; }

    public Coordinate(sbyte[,] grid, sbyte tile)
    {
        ComputeCoordinate(grid, tile);
    }

    private void ComputeCoordinate(sbyte[,] grid, sbyte tile)
    {
        for (byte row = 0; row < grid.GetLength(0); row++)
            for (byte col = 0; col < grid.GetLength(1); col++)
                if (grid[row, col] == tile)
                {
                    PositionX = row;
                    PositionY = col;
                }
    }
}
public enum Moves { Up, Down, Left, Right}