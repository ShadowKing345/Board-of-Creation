using UnityEngine;

namespace BoardOfCreation.Objects
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public Sprite image;
        [TextArea(10, 20)] public string description;
    }
}