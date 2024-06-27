using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10070933PROG6221POE.Models
{
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }

        public List<Recipe> GetRecipeList()
        {
            return recipes;
        }
        public List<Recipe> FilterRecipes(string ingredientNameFilter, string foodGroupFilter, int maxCaloriesFilter)
        {
            return recipes.Where(recipe =>
            {
                bool ingredientMatch = string.IsNullOrEmpty(ingredientNameFilter) ||
                                       recipe.Ingredients.Any(ingredient => ingredient.Name.ToLower().Contains(ingredientNameFilter.ToLower()));

                bool foodGroupMatch = string.IsNullOrEmpty(foodGroupFilter) ||
                                      recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.Equals(foodGroupFilter, StringComparison.OrdinalIgnoreCase));

                bool maxCaloriesMatch = maxCaloriesFilter <= 0 || recipe.TotalCalories <= maxCaloriesFilter;

                return ingredientMatch && foodGroupMatch && maxCaloriesMatch;
            }).ToList();
        }

        public Recipe GetRecipeByName(string name)
        {
            return recipes.FirstOrDefault(r => r.Name == name);
        }

        public void ClearRecipes()
        {
            recipes.Clear();
        }
    }
}