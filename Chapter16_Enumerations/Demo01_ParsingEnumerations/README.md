Parsing Enumerations
-

There are different ways to convert an enumeration type into a string.
In the program, 4 main ways are explored:
1. Switch-Based Parsing using Strings
2. Switch-Based Parsing using Numbers
3. Generalized Approaches with Type class. It uses:
   - Enum methods GetNames and Parse, with typeof() operator of Type class
   - Casting the returned object into the enum type
4. The Generalized Approach with Generics. It uses:
   - Enum methods GetNames and Parse
   - No parsing in needed (the type is denoted in angle brackets <>) 


