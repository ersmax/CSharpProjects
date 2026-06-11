Hangman
-
The third pedestal in this room requires you to provide an object-oriented design for the game of
Hangman. In Hangman, the computer picks a random word for the player to guess. The player then
proceeds to guess the word by selecting letters from the alphabet, which get filled in, progressively
revealing the word. The player can only get so many letters wrong (a letter not found in the word) before
losing the game. An example run of this game could look like this:

```
Word: _ _ _ _ _ _ _ _ _ | Remaining: 5 | Incorrect:		  | Guess: e
Word: _ _ _ _ _ _ _ _ E | Remaining: 5 | Incorrect:		  | Guess: i
Word: I _ _ _ _ _ _ _ E | Remaining: 5 | Incorrect:		  | Guess: u
Word: I _ _ U _ _ _ _ E | Remaining: 5 | Incorrect:		  | Guess: o
Word: I _ _ U _ _ _ _ E | Remaining: 4 | Incorrect: O		| Guess: a
Word: I _ _ U _ A _ _ E | Remaining: 4 | Incorrect: O		| Guess: t
Word: I _ _ U T A _ _ E | Remaining: 4 | Incorrect: O		| Guess: s
Word: I _ _ U T A _ _ E | Remaining: 3 | Incorrect: OS		| Guess: r
Word: I _ _ U T A _ _ E | Remaining: 2 | Incorrect: OSR		| Guess: m
Word: I M M U T A _ _ E | Remaining: 2 | Incorrect: OSR		| Guess: l
Word: I M M U T A _ L E | Remaining: 2 | Incorrect: OSR		| Guess: b
Word: I M M U T A B L E
You won!
```

- The game picks a word at random from a list of words.
- The game’s state is displayed to the player, as shown above.
- The player can pick a letter. If they pick a letter they already chose, pick again.
- The game should update its state based on the letter the player picked.
- The game needs to detect a win for the player (all letters have been guessed).
- The game needs to detect a loss for the player (out of incorrect guesses).

---
#### Objectives:
- Use CRC cards (or a suitable alternative) to outline the objects and classes that may be needed to 
  make the game of Hangman. You do not need to create this full game; just come up with a
 potential design as a starting point.

---
My solution (CRC class-responsibilities-collaborators):

- The first class GENERATOR handles the generation of word

|GENERATOR |
|---|---|
|knows the list of words		|   |
|pick a word from the list	    |   |
|   |   |

- The second class PLAYER allows the user to play

|PLAYER |
|---|---|
|pick a guessing letter		| Game  |
|display the state of game	|   |
|   |   |

- The third class GAME handles the round 

|GAME |
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

|PROGRAM |
|---|---|
|Starts a game with a player and word	| Player	|
|										| Game		|
|										| Dictionary|
|										|			|

