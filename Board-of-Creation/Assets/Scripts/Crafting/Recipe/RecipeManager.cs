using System.Linq;
using BoardOfCreation.Objects;
using UnityEngine;

namespace BoardOfCreation.Crafting.Recipe
{
    public class RecipeManager : MonoBehaviour
    {
        public static RecipeManager current;
        
        public void Awake()
        {
            current = this;
        }

        [SerializeField]
        private Recipe[] recipes;
        
        public void Start()
        {
            recipes = Resources.LoadAll<Recipe>("Recipes");
        }
        
        public Recipe FindRecipe(Item input1, Item input2)
        {
            return recipes.FirstOrDefault(recipe => recipe.input1 == input1 && recipe.input2 == input2);
        }
    }
}
