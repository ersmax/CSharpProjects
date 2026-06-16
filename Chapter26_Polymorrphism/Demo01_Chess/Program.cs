Console.Title = "Chess moves";
King theKing = new King();
//Console.WriteLine(theKing.IsLegalMove(3, 5));
Queen theQueen = new Queen();
Console.WriteLine(theQueen.IsLegalMove(1, 3));  // False
Console.WriteLine(theQueen.IsLegalMove(4, 2));  // False
Console.WriteLine(theQueen.IsLegalMove(7, 7));  // False
Console.WriteLine(theQueen.IsLegalMove(0, 6));  // False
Console.WriteLine(theQueen.IsLegalMove(7, 0));  // True
Console.WriteLine(theQueen.IsLegalMove(4, 7));  // True
Console.WriteLine(theQueen.IsLegalMove(6, 5));  // True
Console.WriteLine(theQueen.IsLegalMove(2, 7));  // True

public class ChessPiece
{
    public int Row { get; set; } = 2;
    public int Column { get; set; } = 5;

    public virtual bool IsLegalMove(int row, int column) => IsOnBoard(row, column) && !IsCurrentLocation(row, column);

    protected bool IsOnBoard(int row, int column) => (row >= 0 && row < 8) && (column >= 0 && column < 8);

    protected bool IsCurrentLocation(int row, int column) => (row == Row) && (column == Column);
}

public class King : ChessPiece 
{
    public override bool IsLegalMove(int row, int column)
    {
        if (!base.IsLegalMove(row, column)) return false;

        // Moving more than one row or one column is not legal for king
        if (Math.Abs(row - Row) > 1) return false;
        if (Math.Abs(column - Column) > 1) return false;
        return true;
    }
}

public class Queen : ChessPiece
{
    public override bool IsLegalMove(int row, int column)
    {
        if (!base.IsLegalMove(row, column)) return false;
        
        // Queen's moves: horizontally, vertically, diagonally
        if (row == Row) return true;        
        if (column == Column) return true;  
        if (Math.Abs(column - Column) == Math.Abs(row - Row)) return true;  

        return false;
    }

}