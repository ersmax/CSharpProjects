Countdown
-
Note: This challenge requires reading The Basics of Recursion side quest to attempt.

The Council of Freach has summoned you. New writing has appeared on the Tomb of Algol the Wise, the
last True Programmer to wander this land. The writing strikes fear and awe into the hearts of the looploving
people of Freach: “The next True Programmer shall be able to write any looping code with a
method call instead.” The Senior Counselor, scared of a world without loops, asks you to put your skill to
the test and rewrite the following code, which counts down from 10 to 1, with no loops:
```C#
for (int x = 10; x > 0; x--)
	Console.WriteLine(x);
```

As you consider the words on the Tomb of Algol the Wise, you begin to think it might be correct and that
you might be able to write this code using recursion instead of a loop.

---
#### Objectives:
- Write code that counts down from 10 to 1 using a recursive method.
- Hint: Remember that you must have a base case that ends the recursion and that every time you
call the method recursively, you must be getting closer and closer to that base case.

