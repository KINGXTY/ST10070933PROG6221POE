using ST10070933PROG6221POE.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10070933PROG6221POE
{
    public partial class MainWindow : Window
    {
        private RecipeManager recipeManager;

        public MainWindow()
        {
            InitializeComponent();
            recipeManager = new RecipeManager();
            UpdateRecipeList();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e) //adding recipe 
        {
            var addRecipeDialog = new AddRecipeDialog();
            if (addRecipeDialog.ShowDialog() == true)
            {
                recipeManager.AddRecipe(addRecipeDialog.NewRecipe);
                UpdateRecipeList();
            }
        }

        private void RemoveRecipeButton_Click(object sender, RoutedEventArgs e) //removes recipe
        {
            string selectedRecipeName = RecipeListBox.SelectedItem as string;
            if (selectedRecipeName != null)
            {
                Recipe recipeToRemove = recipeManager.GetRecipeByName(selectedRecipeName);
                if (recipeToRemove != null)
                {
                    recipeManager.RemoveRecipe(recipeToRemove);
                    UpdateRecipeList();
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to remove.");
            }
        }

        private void DisplayRecipeDetailsButton_Click(object sender, RoutedEventArgs e) //displays recipe details 
        {
            string selectedRecipeName = RecipeListBox.SelectedItem as string;
            if (selectedRecipeName != null)
            {
                Recipe recipe = recipeManager.GetRecipeByName(selectedRecipeName);
                if (recipe != null)
                {
                    MessageBox.Show($"Recipe '{recipe.Name}' details:\n" +
                                    $"Ingredients:\n{string.Join("\n", recipe.Ingredients.Select(i => $"- {i.Name}: {i.Quantity} {i.Unit}, {i.Calories} calories, {i.FoodGroup} food group"))}\n" +
                                    $"Steps:\n{string.Join("\n", recipe.Steps.Select((s, index) => $"{index + 1}. {s.Description}"))}\n" +
                                    $"Total calories: {recipe.TotalCalories}");
                }
                else
                {
                    MessageBox.Show($"Recipe '{selectedRecipeName}' not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to view details.");
            }
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)  //to scale the recipe 
        {
            string selectedRecipeName = RecipeListBox.SelectedItem as string;
            if (selectedRecipeName != null)
            {
                Recipe recipe = recipeManager.GetRecipeByName(selectedRecipeName);
                if (recipe != null)
                {
                    var scaleRecipeDialog = new ScaleRecipeDialog();
                    if (scaleRecipeDialog.ShowDialog() == true)
                    {
                        double newScaleFactor = scaleRecipeDialog.ScaleFactor;
                        recipe.Scale(newScaleFactor);
                        MessageBox.Show($"Recipe '{selectedRecipeName}' scaled successfully!");
                    }
                }
                else
                {
                    MessageBox.Show($"Recipe '{selectedRecipeName}' not found!");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to scale.");
            }
        }
        private void ApplyFiltersButton_Click(object sender, RoutedEventArgs e) //applying the filters to search 
        {
            string ingredientFilter = IngredientFilterTextBox.Text.Trim();
            string foodGroupFilter = (FoodGroupFilterComboBox.SelectedItem as ComboBoxItem)?.Content as string;
            int maxCaloriesFilter;
            bool hasMaxCaloriesFilter = int.TryParse(MaxCaloriesFilterTextBox.Text.Trim(), out maxCaloriesFilter);

            List<Recipe> filteredRecipes = recipeManager.FilterRecipes(ingredientFilter, foodGroupFilter, maxCaloriesFilter);

            RecipeListBox.Items.Clear();
            foreach (var recipe in filteredRecipes)
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }

        private void ClearFiltersButton_Click(object sender, RoutedEventArgs e) //to clear the filters 
        {
            IngredientFilterTextBox.Text = "";
            FoodGroupFilterComboBox.SelectedIndex = -1;
            MaxCaloriesFilterTextBox.Text = "";

            UpdateRecipeList(); 
        }

        private void ResetRecipeQuantitiesButton_Click(object sender, RoutedEventArgs e) //button to reset the recipe quantities 
        {
            string selectedRecipeName = RecipeListBox.SelectedItem as string;
            if (selectedRecipeName != null)
            {
                Recipe recipe = recipeManager.GetRecipeByName(selectedRecipeName);
                if (recipe != null)
                {
                    recipe.ResetQuantities();
                    MessageBox.Show("Recipe quantities reset successfully.");
                }
                else
                {
                    MessageBox.Show($"Recipe '{selectedRecipeName}' not found.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset quantities.");
            }
        }

        private void ClearAllDataButton_Click(object sender, RoutedEventArgs e) //clear all the data from the recipe list 
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear all data?", "Confirm", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                recipeManager.ClearRecipes();
                UpdateRecipeList();
                MessageBox.Show("All data has been cleared.");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e) //to exit the application 
        {
            Application.Current.Shutdown();
        }

        private void UpdateRecipeList()
        {
            RecipeListBox.Items.Clear();
            foreach (var recipe in recipeManager.GetRecipeList())
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }
    }
}