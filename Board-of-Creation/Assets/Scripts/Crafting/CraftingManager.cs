using System;
using BoardOfCreation.Crafting.Recipe;
using BoardOfCreation.Objects;
using UnityEngine;

namespace BoardOfCreation.Crafting
{
    public class CraftingManager : MonoBehaviour
    {
        public static CraftingManager current;
        public void Awake()
        {
            current = this;
        }

        public Item FindRecipeResult(Item input1, Item input2)
        {
            var recipe = RecipeManager.current.FindRecipe(input1, input2);
            return !recipe ? null : recipe.result;
        }
    }
}