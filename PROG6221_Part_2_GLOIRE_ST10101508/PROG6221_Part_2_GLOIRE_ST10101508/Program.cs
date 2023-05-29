using System;
using System.Collections.Generic;

namespace RecipeManager
{
    /*Ingredient: Represents an ingredient in a recipe and contains properties such as name, quantity, unit, calories, and food group.*/
    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

    }
    /*Represents a step in a recipe and contains a description.*/
    class Step
    {
        public string Description { get; set; }
    }
    /*Recipe: Represents a recipe and contains properties such as name, a list of ingredients, a list of steps, and the total calories of the recipe.*/
    class Recipe
    {
        /*Public accessors allow any object to read and write these properties. It's sometimes desirable, however, to exclude one of the accessors. */
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public int TotalCalories { get; private set; }
  
       

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
            TotalCalories = 0;
        }
        /*void as the return type of a method (or a local function) to specify that the method doesn't return a value.*/
        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            var ingredient = new Ingredient
            {
                Name = name,
                Quantity = quantity,
                Unit = unit,
                Calories = calories,
                FoodGroup = foodGroup,
           
            };

            Ingredients.Add(ingredient);
            TotalCalories += calories;
        }

        public void AddStep(string description)
        {
            var step = new Step { Description = description };
            Steps.Add(step);
        }
        /*NotImplementedException is simply an exception that is used when the code for what you're trying to do isn't written yet. 
         * It's often used in snippets as a placeholder until you fill in the body of whatever has been generated with actual code.*/
        
    }
    /*Manages a collection of recipes and provides methods to add, remove, and retrieve recipes.*/
    class RecipeManager
    {
        /*The recipes field is a private list of recipes that stores all the recipes managed by the Recipe Manager.*/
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }
        /*The AddRecipe method adds a recipe to the list.*/
        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));
        }
        /*The RemoveRecipe method removes a recipe from the list.*/
        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }
        /*The GetRecipeList method returns the list of recipes.*/
        public List<Recipe> GetRecipeList()
        {
            return recipes;
        }
        /*The GetRecipeByName method retrieves a recipe from the list based on its name.
*/
        public Recipe GetRecipeByName(string name)
        {
            return recipes.Find(recipe => recipe.Name == name);
        }

    }

    delegate void RecipeNotification(Recipe recipe);

    /*Handles the user interface and provides methods to interact with the Recipe Manager.*/
    class UI
    {
        private RecipeManager recipeManager;
        private RecipeNotification notificationDelegate;

        public UI()
        {
            recipeManager = new RecipeManager();
            notificationDelegate = RecipeExceedsCalorieLimit;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Welcome To The Recipe App");
                Console.WriteLine("*************************");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. Remove a recipe");
                Console.WriteLine("3. Display recipe list");
                Console.WriteLine("4. Display recipe details");
                Console.WriteLine("5. Clear all data");
                Console.WriteLine("6. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.White;
                        AddRecipe();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        RemoveRecipe();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        DisplayRecipeList();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        DisplayRecipeDetails();
                        break;
     
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        ClearAllData();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine();
            }
        }
        /*The AddRecipe method allows the user to enter the details of a recipe, 
       * including name, ingredients, and steps, and adds it to the Recipe Manager.*/
        private void AddRecipe()
        {
            Console.WriteLine("Enter recipe name:");
            string name = Console.ReadLine();

            Recipe recipe = new Recipe(name);

            Console.WriteLine("Enter number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1} name:");
                string ingredientName = Console.ReadLine();

                Console.WriteLine($"Enter ingredient {i + 1} quantity:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter ingredient {i + 1} unit of measurement:");
                string unitOfMeasurement = Console.ReadLine();

                Console.WriteLine($"Enter ingredient {i + 1} calories:");
                int calories = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter ingredient {i + 1} food group:");
                string foodGroup = Console.ReadLine();

                recipe.AddIngredient(ingredientName, quantity, unitOfMeasurement, calories, foodGroup);
            }

            Console.WriteLine("Enter number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1} description:");
                string description = Console.ReadLine();
                recipe.AddStep(description);
            }

            recipeManager.AddRecipe(recipe);
            CheckRecipeCalorieLimit(recipe);
            Console.WriteLine($"Recipe '{name}' added successfully!");
        }
        /*The RemoveRecipe method allows the user to remove a recipe from the Recipe Manager by entering its name.*/
        private void RemoveRecipe()
        {
            Console.WriteLine("Enter recipe name to remove:");
            string name = Console.ReadLine();
            Recipe recipe = recipeManager.GetRecipeByName(name);

            if (recipe != null)
            {
                recipeManager.RemoveRecipe(recipe);
                Console.WriteLine($"Recipe '{name}' removed successfully!");
            }
            else
            {
                Console.WriteLine($"Recipe '{name}' not found!");
            }
        }
        /*The DisplayRecipeList method displays a list of all the recipes' names.*/
        private void DisplayRecipeList()
        {
            List<Recipe> recipeList = recipeManager.GetRecipeList();

            Console.WriteLine("Recipe list:");

            foreach (Recipe recipe in recipeList)
            {
                Console.WriteLine(recipe.Name);
            }
        }
        /*The DisplayRecipeDetails method allows the user to select a recipe from the list and displays its details, including ingredients, steps, and total calories. 
         * It also checks if the recipe exceeds 300 calories and displays a warning if it does.*/
        private void DisplayRecipeDetails()
        {
            Console.WriteLine("Enter recipe name to display details:");
            string name = Console.ReadLine();

            Recipe recipe = recipeManager.GetRecipeByName(name);

            if (recipe != null)
            {
                Console.WriteLine($"Recipe '{name}' details:");
                Console.WriteLine("Ingredients:");

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}, {ingredient.Calories} calories, {ingredient.FoodGroup} food group");
                }

                Console.WriteLine("Steps:");

                foreach (Step step in recipe.Steps)
                {
                    Console.WriteLine($"- {step.Description}");
                }

                Console.WriteLine($"Total calories: {recipe.TotalCalories}");

                if (recipe.TotalCalories > 300)
                {
                    notificationDelegate(recipe);
                }
            }
            else
            {
                Console.WriteLine($"Recipe '{name}' not found!");
            }
        }
       
        private void ClearAllData()
        {
            Console.WriteLine("Are you sure you want to clear all data? (Yes/No)");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "YES")
            {
                recipeManager = new RecipeManager();
                Console.WriteLine("All data has been cleared.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        /*The RecipeNotification delegate is introduced to handle notifications when a recipe exceeds 300 calories.*/
        private void RecipeExceedsCalorieLimit(Recipe recipe)
        {
            Console.WriteLine("WARNING: Recipe exceeds 300 calories!");
        }
        /*The CheckRecipeCalorieLimit method checks if a recipe exceeds 300 calories and triggers the notificationDelegate if it does.*/
        private void CheckRecipeCalorieLimit(Recipe recipe)
        {
            if (recipe.TotalCalories > 300)
            {
                notificationDelegate(recipe);
            }
        }
    }

    class Program
    {
        /*The Run method starts the user interface loop, displaying a menu of options and executing the selected option.*/
        static void Main(string[] args)
        {
            UI ui = new UI();
            ui.Run();
        }
    }
}