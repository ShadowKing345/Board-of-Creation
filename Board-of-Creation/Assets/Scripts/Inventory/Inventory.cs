using BoardOfCreation.Objects;
using UnityEngine;

namespace BoardOfCreation.Inventory
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
        public ItemStack[] slots;
    }
}