Console.Title = "Tic-Tac-Toe";

Board aBoard = new Board();
BoardRender boardRender = new BoardRender();
boardRender.Display(aBoard.Grid);

public class BoardRender
{
    public void Display(Sign[,] aGrid)
    {
        for (int row = 0; row < aGrid.GetLength(0); row++)
        {
            for (int col = 0; col < aGrid.GetLength(1); col++)
            {
                Console.Write(" ");
                if (aGrid[row, col] == Sign.Circle) 
                    Console.Write("O");
                else if (aGrid[row, col] == Sign.Cross)
                    Console.Write("X");
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
}

public class Board
{
    public Sign[,] Grid { get; private set; }

    public Board()
    {
        Grid = new Sign[3, 3];
        for (int row = 0; row < Grid.GetLength(0); row++)
            for (int col = 0; col < Grid.GetLength(1); col++)
                Grid[row, col] = Sign.Empty;

    }

    public bool Place(Sign playerSign, int position)
    {
        int x = ParsePosition(position).Item1;
        int y = ParsePosition(position).Item2;

        if (Grid[x, y] == Sign.Empty)
        {
            Grid[x, y] = playerSign;
            return true;
        }
        return false;
    }

    public (int, int) ParsePosition(int position)
    {
        (int, int) coordinates;
        coordinates = position switch
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

public enum Sign { Empty, Cross, Circle}