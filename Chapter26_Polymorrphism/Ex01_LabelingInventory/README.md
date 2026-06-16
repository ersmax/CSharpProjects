Labeling Inventory
-
You realize that your inventory items are not easy to sort through. If you could make it easy to label all
of your inventory items, it would be easier to know what items you have in your pack.

Modify your inventory program from the previous level as described below.

---
#### Objectives:
- Override the existing ToString method (from the object base class) on all of your inventory item
  subclasses to give them a name. For example, new Rope().ToString() should return "Rope".
- Override ToString on the Pack class to display the contents of the pack. If a pack contains water,
  rope, and two arrows, then calling ToString on that Pack object could look like "Pack
  containing Water Rope Arrow Arrow".
- Before the user chooses the next item to add, display the pack’s current contents via its new
  ToString method.

---

### Differences:
1) The main differences compared to the preivous version in folder 25_Inheritance is that
   now each derived class Arrow, Bow, Rope, Water, FoodRations and Sword needs to override
   the ToString method directly (if we want to use the `Console.WriteLine(new Arrow())` for 
   example without calling methods such as `new Arrow().display()` or properties such as
   `Console.WriteLine(new Arrow().Name)`).

2) Another difference is that now we need to override the ToString() also in Pack class to 
   display the content of the pack.

3) Finally, we don't need anymore the specific method ShowBackpack() that was defined in 
   the class Pack, because we overried directly the method ToString() in the same class.
   So instead of calling in the program `backpack.ShowBackpack()` we would do 
   `Console.WriteLine(backpack)`, which is a bit more intuitive.

My design solution considering the changes is the following (CRC class-responsibilities-collaborators):

- The first class PROGRAM allows to create a new backpack and add items

|PROGRAM ||
|---|---|
|Create new backpack		|Pack   |
|Knows all items			|InventoryItem   |
|Add items (factory method) |   |
|							|	|

- The second class PACK knows the properties, add to the pack the chosen item, display the pack's content

|PACK ||
|---|---|
|knows items		|InventoryItem   |
|knows Items Limit  |Arrow   |
|knows Weight Limit |Bow   |
|knows Volume Limit |Rope   |
|add item			|Water   |
|check limits		|FoodRations   |
|display the content|Sword   |
|					|   |

- The third class INVENTORY ITEM knows the properties of each item and the subtypes

|INVENTORY ITEM ||
|---|---|
|Knows weight 				|Arrow, Bow, etc.  |
|Knows volume				|   |


- The remaining classes ARROW, BOW, ROPE, WATER, FOOD RATIONS, SWORD overrided the 
  ToString display logic, and know the parent class INVENTORY ITEM.
  Class ARROW is taken as example below:

|ARROW ||
|---|---|
|	|InventoryItem 	|
|	|   |


