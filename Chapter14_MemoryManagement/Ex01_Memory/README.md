Memory
-
Check your knowledge with the following questions:
1. True/False. You can access anything on the stack at any time.
2. True/False. The stack keeps track of local variables.
3. True/False. The contents of a value type can be placed on the heap.
4. True/False. The contents of a value type are always placed on the heap.
5. True/False. The contents of reference types are always placed on the heap.
6. True/False. The garbage collector cleans up old, unused space on the heap and stack.
7. True/False. If a and b are array variables referencing the same object, modifying a affects b as well.
8. True/False. If a and b are ints with the same value, changing a will also affect b.
---
1. False. You can access only those local variables of the active stack frame.
   That is, you generally only have access to things in the top frame on the stack (and things on the heap).
2. True.
3. True. The contents of a value type can be placed on the stack, together with the reference to a 
   reference type, whose content is placed on the heap. Hence, value types can be placed on a heap
   iff they are part of a reference type (e.g. int[] array = new int[3]; will place the content of
   the array (the three ints) in the heap, while the reference to the array is placed in the stack.
4. False. If we deal with value types (e.g. floating-point types, char, boolean or integer types), 
   then they will be placed on the stack.
   The only time the value types are placed on the heap is when they are part of a reference type 
   like the array.
5. True. The reference types (a reference to memory location) live on the stack but their content 
   lives on the heap.
6. False. The garbage collector cleans only that part of the unsued and unreferenced memory on the heap.
7. True. This is because the array is a reference type. In general, arrays created this way refer to the 
   same object in memory. A change made through one variable affects that shared object and that change is 
   also seen through the other reference.
	8. False. The two int variables are value types. This means that their value is copied. So each variable
   holds an independent copy of the value from the other variable (deep copy).
   In fact, value types represent different memory locations. Modifying one variable will change its own 
   memory, but leave the memory location of the other variable untouched.
