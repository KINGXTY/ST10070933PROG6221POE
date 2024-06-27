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
    public partial class AddRecipeDialog : Window
    {
        public Recipe NewRecipe { get; private set; }

        private List<Ingredient> ingredients;
        private List<Step> steps;

        public AddRecipeDialog()
        {
            InitializeComponent();
            ingredients = new List<Ingredient>();
            steps = new List<Step>();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e) //Adding ingredients feature 
        {
            AddIngredientDialog dialog = new AddIngredientDialog();
            if (dialog.ShowDialog() == true)
            {
                Ingredient ingredient = dialog.NewIngredient;
                ingredients.Add(ingredient);
                IngredientsListBox.Items.Add($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }
        }

        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e) //removing ingredients from list 
        {
            int selectedIndex = IngredientsListBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                ingredients.RemoveAt(selectedIndex);
                IngredientsListBox.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select an ingredient to remove.");
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e) //to add different steps 
        {
            string stepDescription = Microsoft.VisualBasic.Interaction.InputBox("Enter step description:", "Add Step", "");
            if (!string.IsNullOrWhiteSpace(stepDescription))
            {
                Step step = new Step { Description = stepDescription };
                steps.Add(step);
                StepsListBox.Items.Add(step.Description);
            }
        }

        private void RemoveStepButton_Click(object sender, RoutedEventArgs e)  // to remove steps 
        {
            int selectedIndex = StepsListBox.SelectedIndex;
            if (selectedIndex >= 0)
            {
                steps.RemoveAt(selectedIndex);
                StepsListBox.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a step to remove.");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) //to save the information that was input 
        {
            string recipeName = RecipeNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(recipeName))
            {
                MessageBox.Show("Recipe name cannot be empty.");
                return;
            }

            if (ingredients.Count == 0)
            {
                MessageBox.Show("Please add at least one ingredient.");
                return;
            }

            if (steps.Count == 0)
            {
                MessageBox.Show("Please add at least one step.");
                return;
            }

            NewRecipe = new Recipe
            {
                Name = recipeName,
                Ingredients = ingredients,
                Steps = steps
            };

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}