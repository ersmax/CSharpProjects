Console.Title = "Tic-Tac-Toe";

Game newGame = new Game();
newGame.RunGame();

/// <summary>
/// This class allows to play next rounds
/// </summary>
public class Game
{
    private readonly Board _theBoard;
    private readonly RenderedBoard _theRenderedBoard;
    private Player _currentPlayer;

    public Game()
    {
        _theBoard = new Board();
        _theRenderedBoard = new RenderedBoard();
    }

    // Create player instances, choose tile, display the results
    public void RunGame()
    {
        Player xPlayer = new Player(Sign.X);
        Player oPlayer = new Player(Sign.O);

        Random random = new Random();
        int turn = random.Next(1, 3);
        _currentPlayer = (turn % 2 == 0) ? xPlayer : oPlayer; ;
        while (!Win(_currentPlayer.Positions) && _theBoard.PositionsLeft > 0 )
        {
            _currentPlayer = (turn % 2 == 0) ? xPlayer : oPlayer;
            bool validPosition = false;
            int position = 0;
            while (!validPosition)
            {
                Console.Clear();
                Console.Write("It is ");
                if (_currentPlayer.Name == Sign.X)      Console.ForegroundColor = ConsoleColor.DarkMagenta;
                else if (_currentPlayer.Name == Sign.O) Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{_currentPlayer.Name}");
                Console.ResetColor();
                Console.WriteLine("'s turn.");

                _theRenderedBoard.Display(_theBoard.Grid);
                position = _currentPlayer.EnterSquare(_theBoard.Dimension, _theRenderedBoard);
                validPosition = _theBoard.Place(_currentPlayer.Name, position);
                if (!validPosition)
                {
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey(true);
                }
            }
            _currentPlayer.UpdatePositions(position);
            turn++;
        }

        if (Win(_currentPlayer.Positions))
        {
            if (_currentPlayer.Name == Sign.X)      Console.ForegroundColor = ConsoleColor.DarkMagenta;
            else if (_currentPlayer.Name == Sign.O) Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.Write($"{_currentPlayer.Name}");
            Console.ResetColor();
            Console.WriteLine(" won!");
        }
        else if (_theBoard.PositionsLeft == 0)
            Console.WriteLine("This game is a tie.");

        _theRenderedBoard.Display(_theBoard.Grid);
        Console.WriteLine("Press a key to exit");
        Console.ReadKey(true);
    }

    // Check if the player won
    private bool Win(int[] positions)
    {
        bool[] numbers = new bool[9];
        for (int idx = 0; idx < numbers.Length; idx++)
            numbers[idx] = false;

        for (int idx = 0; idx < positions.Length; idx++)
        {
            int idxNumber = positions[idx] - 1;
            numbers[idxNumber] = true;
        }

        if (RowWin(positions, numbers)) return true;
        if (ColumnWin(positions, numbers)) return true;
        if (DiagonalWin(positions, numbers)) return true;
        return false;
    }

    private bool RowWin(int[] positions, bool[] numbers)
    {
        return (numbers[0] && numbers[1] && numbers[2] ||
                numbers[3] && numbers[4] && numbers[5] ||
                numbers[6] && numbers[7] && numbers[8]);
    }

    private bool ColumnWin(int[] positions, bool[] numbers)
    {
        return (numbers[0] && numbers[3] && numbers[6] ||
                numbers[1] && numbers[4] && numbers[7] ||
                numbers[2] && numbers[5] && numbers[8]);
    }

    private bool DiagonalWin(int[] positions, bool[] numbers)
    {
        return (numbers[0] && numbers[4] && numbers[8] ||
                numbers[2] && numbers[4] && numbers[6]);
    }
}

/// <summary>
/// This class handles the choices of player and updates the chosen position in grid
/// </summary>
public class Player
{
    public Sign Name { get; }

    public int[] Positions { get; private set; }

    public Player(Sign name)
    {
        Name = name;
        Positions = Array.Empty<int>();
    }
    
    // Choose the tile
    public int EnterSquare(int dimension, RenderedBoard renderedRenderedBoard)
    {
        int input;
        int numberSquares = dimension * dimension;
        do
        {
            Console.WriteLine($"What square do you want to play in? (1-{numberSquares})");
            renderedRenderedBoard.DisplayChoices(dimension);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("> ");
            input = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
        } while (input < 1 || input > numberSquares);

        return input;
    }

    // Update the positions chosen by the player so far
    public void UpdatePositions(int position)
    {
        int[] temp = Positions;
        Array.Resize(ref temp, temp.Length + 1);
        temp[^1] = position;
        Positions = temp;
    }
}

/// <summary>
/// This class handles the display of the Board
/// </summary>
public class RenderedBoard
{
    // Show the state of the grid with moves of each player
    public void Display(Sign[,] aGrid)
    {
        for (int row = 0; row < aGrid.GetLength(0); row++)
        {
            for (int col = 0; col < aGrid.GetLength(1); col++)
            {
                Console.Write(" ");
                if (aGrid[row, col] == Sign.O)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("O");
                    Console.ResetColor();
                }
                else if (aGrid[row, col] == Sign.X)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("X");
                    Console.ResetColor();
                }
                else if (aGrid[row, col] == Sign.Empty)
                    Console.Write(" ");

                Console.Write(" ");
                if (col + 1 != aGrid.GetLength(1))
                    Console.Write("|");
                else 
                    Console.Write(" ");
            }
            Console.WriteLine();
            if (row + 1 != aGrid.GetLength(0))
                Console.WriteLine("---+---+---");
        }
    }

    // Show the possible moves with numbers as position (e.g. 1, 2, 3 for the first row)
    public void DisplayChoices(int dimension)
    {
        int position = 1;
        for (int row = 0; row < dimension; row++)
        {
            for (int col = 0; col < dimension; col++)
            {
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(position);
                Console.ResetColor();
                Console.Write(" ");
                if (col + 1 != dimension)
                    Console.Write("|");
                else
                    Console.Write(" ");
                position++;
            }
            Console.WriteLine();
            if (row + 1 != dimension)
                Console.WriteLine("---+---+---");
        }
    }
}

/// <summary>
/// This class validates the placement in the grid
/// </summary>
public class Board
{
    public int PositionsLeft { get; private set; }
    
    public Sign[,] Grid { get; }
    public int Dimension { get; }

    public Board()
    {
        Dimension = 3;
        PositionsLeft = Dimension * Dimension;
        Grid = new Sign[Dimension, Dimension];
        for (int row = 0; row < Grid.GetLength(0); row++)
            for (int col = 0; col < Grid.GetLength(1); col++)
                Grid[row, col] = Sign.Empty;
    }

    // Returns whether the chosen position is okay to move to or busy
    public bool Place(Sign playerSign, int position)
    {
        int x = ParsePosition(position).Item1;
        int y = ParsePosition(position).Item2;

        if (Grid[x, y] == Sign.Empty)
        {
            Grid[x, y] = playerSign;
            PositionsLeft--;
            return true;
        }

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Square already chosen");
        Console.ResetColor();
        return false;
    }

    // Translate the position (e.g. 1, 2, 3 in first row) into
    //   a set of coordinates [e.g. (0,0), (0, 1), (0, 2)]
    public (int, int) ParsePosition(int position)
    {
        (int, int) coordinates = position switch
        {
            1 => (0, 0),
            2 => (0, 1),
            3 => (0, 2),
            4 => (1, 0),
            5 => (1, 1),
            6 => (1, 2), 
            7 => (2, 0),
            8 => (2, 1),
            9 => (2, 2),
        };
        return coordinates;
    } 
}

public enum Sign { Empty, X, O}