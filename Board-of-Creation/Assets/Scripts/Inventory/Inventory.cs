using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
        public Itemstack[] slots;

        public Itemstack GetItemStackFromSlot(int slot)
        {
            return slots[slot];

        }

        // todo: implements binary search.
        public int ContainsItemstack(Itemstack itemstack)
        {
            for (var index = 0; index < slots.Length; index++)
            {
                var slot = slots[index];
                if (slot.IsEmpty()) continue;

                if (slot.item == itemstack.item)
                    return index;
            }

            return -1;
        }

        public Itemstack AddItemStack(Itemstack stack)
        {
            var index = ContainsItemstack(stack);
            if (index != -1)
            {
                return slots[index].Add(stack.Amount);
            }
            else
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].IsEmpty())
                    {
                        slots[i] = stack;
                        return new Itemstack();
                    }

                }
            }

            return null;
        }

        public Itemstack RemoveItemStackFromSlot(int index)
        {
            if (slots[index].IsEmpty()) return new Itemstack();

            var result = new Itemstack(slots[index]);
            return result;
        }
        
        // todo: implements a sort.
        public void Sort()
        {
            
        }
    }
}