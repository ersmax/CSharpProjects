Tic-Tac-Toe
-
Completing designs for the three games in the Chamber of Design causes the pedestals to light up red
again, and another door opens, letting you into the final chamber. This chamber has only a single large,
broad pedestal. Inscribed on the stone floor in a circle around the pedestal are the engraved words, “Only
a True Programmer can build object-oriented programs.”

More text engraved on the pedestal describes what you recognize as the game of Tic-Tac-Toe, stating
that in ancient times, inhabitants of the land would use this as a Battle of Wits to determine the outcome
of political strife. Instead of fighting wars, they would battle it out in a game of Tic-Tac-Toe.

Your job is to recreate the game of Tic-Tac-Toe, allowing two players to compete against each other. The
following features are required:
- Two human players take turns entering their choice using the same keyboard.
- The players designate which square they want to play in. Hint: You might consider using the number 
  pad as a guide. For example, if they enter 7, they have chosen the top left corner of the board.
- The game should prevent players from choosing squares that are already occupied. If such a move
  is attempted, the player should be told of the problem and given another chance.
- The game must detect when a player wins or when the board is full with no winner (draw/”cat”).
- When the game is over, the outcome is displayed to the players.
- The state of the board must be displayed to the player after each play. Hint: One possible way to 
  show the board could be like this:

```
It is X's turn.
   | X |
---+---+---
   | O | X
---+---+---
 O |   |
What square do you want to play in?
```

---
#### Objectives:
- Build the game of Tic-Tac-Toe as described in the requirements above. Starting with CRC cards is 
  recommended, but the goal is to make working software, not CRC cards.
- Answer this question: How might you modify your completed program if running multiple rounds 
  was a requirement (for example, a best-out-of-five series)?

---
My solution (CRC class-responsibilities-collaborators):

- The first class GENERATOR handles the generation of word

|GENERATOR ||
|---|---|
|knows the list of words		|   |
|pick a word from the list	    |   |
|   |   |

- The second class PLAYER allows the user to play

|PLAYER ||
|---|---|
|pick a guessing letter		| Game  |
|display the state of game	|   |
|   |   |

- The third class GAME handles the round 

|GAME ||
|---|---|
|knows the word to guess			| Player   |
|knows the remaining guesses		|   |
|knows the incorrect/correct letter	|	|
|runs the game:						|   |
|- ask the player for letter			|	|
|- update state with correct letter	|	|
|- check for win/lose					|	|
|									|	|

- The fourth class PROGRAM orchestrates the game

|PROGRAM ||
|---|---|
|Starts a game with a player and word	| Player	|
|										| Game		|
|										| Dictionary|
|										|			|

