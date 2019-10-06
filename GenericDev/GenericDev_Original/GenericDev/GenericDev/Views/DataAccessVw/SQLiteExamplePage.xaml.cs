using GenericDev.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.DataAccessVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteExamplePage : ContentPage
    {
        private RecipeRepository recipeRepository = new RecipeRepository();
        private ObservableCollection<Recipe> recipes;

        public SQLiteExamplePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await recipeRepository.Setup();
            LoadRecipes();
        }

        private async void LoadRecipes()
        {
            var recipesLoad = await recipeRepository.List();
            recipes = new ObservableCollection<Recipe>(recipesLoad);
            recipeList.ItemsSource = recipes;
        }

        private async void addBtn_Clicked(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await recipeRepository.Insert(recipe);
            recipes.Add(recipe);
        }

        private async void updateBtn_Clicked(object sender, EventArgs e)
        {
            var recipe = recipeList.SelectedItem as Recipe;
            recipe.Name = "Recipe Updated " + DateTime.Now.Ticks;
            if (recipe != null)
            {
                await recipeRepository.Update(recipe);
            }
        }

        private async void removeBtn_Clicked(object sender, EventArgs e)
        {
            var recipe = recipeList.SelectedItem as Recipe;
            if (recipe != null)
            {
                await recipeRepository.Delete(recipe);
                recipes.Remove(recipe);
            }
        }
    }
}