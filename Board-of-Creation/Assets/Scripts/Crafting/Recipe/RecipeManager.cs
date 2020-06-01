using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Objects;
using Item = Ui.Item;

namespace Crafting
{
    public class RecipeManager : MonoBehaviour
    {
        public static RecipeManager Instance;
        
        public void Awake()
        {
            Instance = this;
        }

        [SerializeField]
        private Recipe.Recipe[] recipes;
        
        public void Start()
        {
            recipes = Resources.LoadAll<Recipe.Recipe>("Recipes");
        }
        
        public List<Recipe.Recipe> FindRecipe(Item input1, Item input2)
        {
            return recipes.Where(recipe => recipe.input1 == input1 && recipe.input2 == input2).ToList();
        }
    }
}
