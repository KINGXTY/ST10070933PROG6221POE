using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10070933PROG6221POE.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public double ScaleFactor { get; private set; } = 1;

        public int TotalCalories => Ingredients.Sum(i => i.Calories);

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }


        public void Scale(double newScaleFactor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= newScaleFactor / ScaleFactor;
            }
            ScaleFactor = newScaleFactor;
        }
    }
}