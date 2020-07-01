using BoardOfCreation.Objects;
using UnityEngine;

namespace BoardOfCreation.Crafting.Recipe
{
    [CreateAssetMenu(fileName = "New Recipe", menuName = "Crafting/Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        public Item input1;
        public Item input2;
        public Item result;
        public int timeTaken;
    }
}
