using System.Collections.Generic;
using BoardOfCreation.Objects;
using BoardOfCreation.Ui.Slot;
using UnityEngine;

namespace BoardOfCreation.Ui.Containers
{
    public class Container : MonoBehaviour
    {
        [SerializeField] protected List<ISlot> slots = new List<ISlot>();

        [SerializeField] protected GameObject slotsPrefab;

        protected void AddSlot(ISlot slot)
        {
            var id = slots.Count;
            slot.Container = this;
            slot.Id = id;
            slots.Add(slot);
        }

        protected void AddSlot(ISlot slot, ItemStack itemStack)
        {
            AddSlot(slot);
            slot.Stack = itemStack;
        }

        public void Clear()
        {
            slots.Clear();
        }

        public virtual void MoveItemStack(int fromId, int toId)
        {
            
        }
    }
}