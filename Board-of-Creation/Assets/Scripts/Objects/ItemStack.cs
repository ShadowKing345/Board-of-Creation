using System;
using UnityEngine;

namespace BoardOfCreation.Objects
{
    [Serializable]
    public class ItemStack
    {
        public Item item;
        [SerializeField]
        private int amount;
        public int Amount
        {
            get => amount;
            set => amount = Math.Abs(value);
        }
        public int stackSize = 999;
        public bool HasNoItem() => !item;
        public bool IsEmpty() => amount <= 0 || HasNoItem();
        
        public ItemStack(){}

        public ItemStack(Item item, int amount, int stackSize)
        {
            this.item = item;
            this.amount = amount;
            this.stackSize = stackSize;
        }

        public ItemStack(ItemStack itemStack)
        {
            item = itemStack.item;
            amount = itemStack.amount;
            stackSize = itemStack.stackSize;
        }

        public ItemStack Add(int addBy)
        {
            var remainder = new ItemStack {item = item};

            amount += addBy;
            if (amount <= stackSize) return remainder;

            remainder.amount = amount - stackSize;
            amount = stackSize;

            return remainder;
        }

        public ItemStack Subtract(int subtractBy)
        {
            var remainder = new ItemStack {item = item, amount = subtractBy};

            amount -= subtractBy;

            if (amount >= 0) return remainder;

            remainder.amount += amount;
            amount = 0;

            return remainder;
        }
    }
}