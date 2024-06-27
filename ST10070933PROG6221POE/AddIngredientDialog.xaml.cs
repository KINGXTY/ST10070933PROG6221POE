using ST10070933PROG6221POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ST10070933PROG6221POE
{
    public partial class AddIngredientDialog : Window
    {
        public Ingredient NewIngredient { get; private set; }

        public AddIngredientDialog()
        {
            InitializeComponent();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e) //adding ingredients feature 
        {
            NewIngredient = new Ingredient
            {
                Name = IngredientNameTextBox.Text,
                Quantity = double.Parse(IngredientQuantityTextBox.Text),
                Unit = IngredientUnitTextBox.Text,
                Calories = int.Parse(IngredientCaloriesTextBox.Text),
                FoodGroup = IngredientFoodGroupTextBox.Text
            };

            DialogResult = true;
        }
    }
}