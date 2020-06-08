using System.Linq;
using Objects;
using UnityEngine;

namespace Inventory
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
                GameEvents.Current.UpdateItemInventory();
                return null;
            }

            return item;
        }
    }
}