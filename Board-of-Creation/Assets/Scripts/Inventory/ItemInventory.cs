using System.Linq;
using BoardOfCreation.Objects;
using UnityEngine;

namespace BoardOfCreation.Inventory
{
    [CreateAssetMenu(fileName = "New Item Inventory", menuName = "Inventory/Item Inventory", order = 1)]
    public class ItemInventory : ScriptableObject
    {
        public Item[] slots;

        public Item AddItem(Item item)
        {
            if (slots.Contains(item)) return item;

            for (var i = 0; i < slots.Length; i++)
            {
                if (slots[i] != null) continue;
                slots[i] = item;
                return null;
            }

            return item;
        }
    }
}