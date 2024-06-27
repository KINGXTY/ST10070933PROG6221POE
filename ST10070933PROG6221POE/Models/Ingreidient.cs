using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10070933PROG6221POE.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        private double originalQuantity;

        public Ingredient()
        {
            originalQuantity = Quantity;
        }

        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }
    }
}