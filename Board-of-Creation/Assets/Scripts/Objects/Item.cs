using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Objects
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public Sprite image;
        [TextArea(10, 20)] public string description;
    }

    [System.Serializable]
    public class Itemstack
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
        
        public Itemstack(){}

        public Itemstack(Item item, int amount, int stackSize)
        {
            this.item = item;
            this.amount = amount;
            this.stackSize = stackSize;
        }

        public Itemstack(Itemstack itemstack)
        {
            item = itemstack.item;
            amount = itemstack.amount;
            stackSize = itemstack.stackSize;
        }

        public Itemstack Add(int addBy)
        {
            var remainder = new Itemstack {item = item};

            amount += addBy;
            if (amount <= stackSize) return remainder;

            remainder.amount = amount - stackSize;
            amount = stackSize;

            return remainder;
        }

        public Itemstack Subtract(int subtractBy)
        {
            var remainder = new Itemstack {item = item, amount = subtractBy};

            amount -= subtractBy;

            if (amount >= 0) return remainder;

            remainder.amount += amount;
            amount = 0;

            return remainder;
        }

        public bool IsEmpty()
        {
            return amount <= 0 || item == null;
        }
    }
}