Rock-Paper-Scissors
-
The first design pedestal requires you to provide an object-oriented design—a set of objects, classes,
and how they interact—for the game of Rock-Paper-Scissors, described below:
- Two human players compete against each other.
- Each player picks Rock, Paper, or Scissors.
- Depending on the players’ choices, a winner is determined: Rock beats Scissors, Scissors beats Paper, Paper beats Rock. If both players pick the same option, it is a draw.
- The game must display who won the round.
- The game will keep running rounds until the window is closed but must remember the historical record of how many times each player won and how many draws there were.

---
#### Objectives:
- Use CRC cards (or a suitable alternative) to outline the objects and classes that may be needed to 
  make the game of Rock-Paper-Scissors. You do not need to create this full game; just come up 
  with a potential design as a starting point.


---
My solution (CRC class-responsibilities-collaborators):

- The first class PLAYER manages the single users

|PLAYER | |
|---|---|
|knows the enum type   |   |
|get a choice from user   |   |
|   |   |

- The second class ROUND manages the logic of each game round

|ROUND | |
|---|---|
|knows each player move   | Player  |
|determines the winner    |   |
|display the result		  |   |
|   |   |

- The third class STATISTICS keeps track of who won and draws

|STATISTICS | |
|---|---|
|knows each round outcomes   |   |
|   |   |

- The last class GAME orchestrates the Game rounds and update stats

|GAME | |
|---|---|
|knows each player | Player  |
|run the rounds    | Round  |
|update the stas   | Statistics  |
|   |   |
