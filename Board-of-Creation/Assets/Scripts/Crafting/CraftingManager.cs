using System;
using System.Collections.Generic;
using Ui;
using UnityEngine;

namespace Crafting
{
    public class CraftingManager : MonoBehaviour
    {
        public static CraftingManager Instance;

        public void Awake()
        {
            Instance = this;
        }

        [SerializeField] private Slot input1Slot;
        [SerializeField] private Slot input2Slot;
        [SerializeField] private Slot resultSlot;
        
        [SerializeField] private Inventory.Inventory craftingInventory;
        [SerializeField] private List<GameObject> slots = new List<GameObject>();
        [SerializeField] private GameObject contentView;
        [SerializeField] private GameObject slotsPrefab;
        
        private void Start()
        {
            foreach (var stack in craftingInventory.slots)
            {
                var slot = Instantiate(slotsPrefab, contentView.transform);
                slot.GetComponent<Slot>().stack = stack;
                slots.Add(slot);
            }
        }
    }
}