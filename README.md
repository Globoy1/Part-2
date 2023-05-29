# Part-2
C#
A. Explanation:
Classes:
Ingredient: A recipe ingredient with features such as name, quantity, unit, calories, and food type.
Step: A step in a recipe that includes a description.
Recipe: Represents a recipe and includes features such as the recipe's name, a list of ingredients, a list of steps, and the total calories.
RecipeManager: This class manages a collection of recipes and includes methods for adding, removing, and retrieving them.
UI: Takes care of the user interface and provides methods for interacting with the Recipe Manager.

Explanation:
This code allows a recipe management system to create, remove, and display recipes, as well as conduct actions like scaling and quantity resetting. It also checks for total calories in recipes and alerts the user if a recipe exceeds the calorie limit.

The RecipeManager class: The recipes field is a private list of recipes that stores all of the Recipe Manager's recipes.
The AddRecipe function is used to add a recipe to the list.
The RemoveRecipe method is used to delete a recipe from the list.
The GetRecipeList function returns a recipe list.
The GetRecipeByName method searches the list for a recipe based on its name.

The User Interface (UI) class:
The Run method begins the user interface loop by displaying a menu of options and executing the option that is selected.
The AddRecipe method allows the user to enter recipe details such as name, ingredients, and steps and adds them to the Recipe Manager.
By giving its name, the RemoveRecipe method allows the user to delete a recipe from the Recipe Manager.
The DisplayRecipeList function returns a list of all the names of the recipes.
The DisplayRecipeDetails function allows the user to choose a recipe from the list and view its details, which include ingredients, steps, and total calories. It also checks to see whether the recipe contains more than 300 calories and displays a warning if it does.
The ScaleRecipe method allows the user to scale a recipe by entering a new scale factor, and the recipe is updated as a result.
The ResetRecipeQuantities method allows the user to restore the original quantities of ingredients in a recipe.
The ClearAllData function asks the user to acknowledge the deletion of all recipes in the Recipe Manager before clearing the data.

Additional changes: The RecipeNotification delegate is introduced to handle notifications when a recipe contains more than 300 calories.
The CheckRecipeCalorieLimit method determines whether a recipe has more than 300 calories and notifies the notificationDelegate if it does.
When a recipe has more than 300 calories, the notificationDelegate is notified and a warning notice is displayed.

The following changes have been made to the modified code:
A RecipeNotification delegate has been added to handle notifications when a recipe has more than 300 calories.
The Recipe class has been modified to allow for the addition of an unlimited number of recipes as well as the calculation of total calories.
Each recipe now has the option for the user to enter a name.
The RecipeManager class has been modified to arrange the recipe list alphabetically by name.
To integrate the needed functionalities, I implemented the AddRecipe, RemoveRecipe, DisplayRecipeList, DisplayRecipeDetails, ScaleRecipe, ResetRecipeQuantities, and ClearAllData methods.
To manage notifications when a recipe exceeds 300 calories, I implemented the RecipeExceedsCalorieLimit method.
In the AddRecipe method, a check for the recipe's calorie limit has been added.

B. Link to Github:

C. Brief description of what changed based on the feedback: 

Based on the first feedback states that no error handling has been implemented. Therefore, in part 2 I have implemented error handling, if the user types an incorrect value the code will immediately ask the user to enter the correct values in order to proceed with the application.
Based on the second feedback the feedback says that the layout of the ingredients and steps should be improved. The correction that I made based on the feedback was that I have set up an easy layout for users to see clearly without confusion.
Based on the third feedback states that there are a few minor errors in the class structure. I have fixed the errors by correcting referencing each method to the class called Recipe.
Based on the fourth feedback which states that the array size can be managed a little better. In part 2 of the POE, we are asked to no longer use an array to store information on the recipes but instead, we have been asking to use the generic collections List method to store information, therefore all recipe information’s stored in the generic collections List.
Based on the fifth feedback that states the code is well structured with minor errors, therefore I have fixed the errors by rearranging the code structure.
Based on the sixth feedback I was asked to give well-detailed information about running the app, there I have fully detailed the App so that users understand not only how to run the app but understanding as well the codes implemented in the App.



















