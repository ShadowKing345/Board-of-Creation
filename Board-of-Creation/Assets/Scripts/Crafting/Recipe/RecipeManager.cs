using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Objects;
using Ui;

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
        
        public Recipe.Recipe FindRecipe(Item input1, Item input2)
        {
            return recipes.FirstOrDefault(recipe => recipe.input1 == input1 && recipe.input2 == input2);
        }
    }
}
