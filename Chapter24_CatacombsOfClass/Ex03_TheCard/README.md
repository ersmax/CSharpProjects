The Card
-
The digital Realms of C# have playing cards like ours but with some differences. Each card has a color
(red, green, blue, yellow) and a rank (the numbers 1 through 10, followed by the symbols $, %, ^, and &).
The third pedestal requires that you create a class to represent a card of this nature.

---
#### Objectives:
- Define enumerations for card colors and card ranks.
- Define a Card class to represent a card with a color and a rank, as described above.
- Add properties or methods that tell you if a card is a number or symbol card (the equivalent of a 
  face card).
- Create a main method that will create a card instance for the whole deck (every color with every rank) and display each (for example, “The Red Ampersand” and “The Blue Seven”).
- Answer this question: Why do you think we used a color enumeration here but made a color class in the previous challenge?

---

Enumeration is useful because it allows to enter only valid input among those that
are presented to the user. If we used byte to represent the three channels of RGB for 
each color, we would get too many options (thousands) when we in fact need only 4 colors.

