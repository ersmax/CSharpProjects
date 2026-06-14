Tic-Tac-Toe
-
This program is another solution to the previous game Tic Tac Toe developed by RB Whitaker.

---
Notable similarities:
-
- Use of enumeration to identify the players (X, O, Empty)

### Class "Board":
- Same data structure for the grid: Grid[,]
- The class Board use a similar method to set the value (X or O) of a field (FillCell),
  although with different signature

### Class "BoardRenderer"
- A similar software design choice is made to render the board, although with different
  code

### Class "Player"
- Both the solutions have the property Name to store the sign X or O 

### Class "TicTacToeGame"
- Both classes define the logic of Win() in a method with different logic
- 


Notable differences:
-
### Class "Board"
- The class Board keeps private the variable of grid instead of using a property
- The class Board use a specific Getter (ContentsOf) to retrieve the data (X or O)
  instead of relying on property
- The class Board use Setters (FillCell) with different signature: it passes the 
  Object sign (X or O) like I did, but it passes the row and column to identify the cell,
  instead of relying to a position in grid and parsing later in class.
- Another difference is that the setter (FillCell) does not check if the square is already
  chosen or empty. However, the class provides a method to do so, so it is responsibility of 
  the caller to use such function.

### Class "Square"
- This class serves to identify the proper row and column in grid.
  In my program, I relied on the use of Parse method under class Board

### Class "BoardRenderer"
- This class use a private method to identify the symbol (X, O).
  Then it proceeds to print all in one line with space and symbol.
  In my case, I decided to use double loops to change colors according to the symbol.

### Class "Player"
- The class adds the parsing of coordinate starting from an input of the player.
  In my solution, such parsing was added inside the class "Board" to get the right coordinates
  with a private method
- Such parsing with method PickSquare returns a class object with properties Row and Column
  In my case, the parsing done inside class Board is kept private.
- Another difference is that Player in my solution explicitily store 
  all the positions chosen by the player in an array in order to check later if the player won

### Class "TicTacToe Game"
- The main difference of HasWon method to Win in my class is that HasWon checks each value
  of the grid one by one instead of relying to a Property of saved positions inside the 
  class of Player
- The logic of method Run is also simpler, but the main core remain: Display the rendered board
  (called here Draw), EnterSquare to choose the right position (called here PickSquare), 
  and Place the sign X or O in the chosen square (called FillCell here).
- The difference is that while my code repeat the validation and display inside Game class 
  with a function having a bool signature (Place) inside Board class, 
  in this code the validity of the chosen tile is done inside the class Player with function
  PickSquare, which relies in turn to IsEmpty defined in class Board.
  Hence, the responsibilities are split betwen Board and Player, while in my code, the check 
  is done between Board and the Game.
- Another difference is that this version of the game instantiate all the needed variable
  inside the method Run for a narrow scope as a good practice.
  In my case, the needed variables are stored as private immutable member variables and instantiate 
  in the constructor. Though, they could be easily declared inside the method Run as well.
- A final difference is the condition of the loop. This version explicitily states 9,
  but my version consider the Win method and pass the current player.
  My method Run then check the Win passing the current player again. 
  This is because I wanted to separate the clutter that comes from colouring and resetting
  the console color, without putting everything inside the loop with the simple condition
  of checking tilesLeft > 0.

