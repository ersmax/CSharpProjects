The Properties of Arrows
-
The first pedestal asks you to create a Point class to store a point in two dimensions. Each point is
represented by an x-coordinate (x), a side-to-side distance from a special central point called the origin,
and a y-coordinate (y), an up-and-down distance away from the origin.

---
#### Objectives:
- Define a new Point class with properties for X and Y.
- Add a constructor to create a point from a specific x- and y-coordinate.
- Add a parameterless constructor to create a point at the origin (0, 0).
- In your main method, create a point at (2, 3) and another at (-4, 0). Display these points on the 
  console window in the format (x, y) to illustrate that the class works.
- Answer this question: Are your X and Y properties immutable? Why did you choose what you did?

---
Answers:

- X and Y properties are immutable, since they have private access modifier.
- It is so to preserve the information hiding OOP: only the object itself should 
  directly access its data.
