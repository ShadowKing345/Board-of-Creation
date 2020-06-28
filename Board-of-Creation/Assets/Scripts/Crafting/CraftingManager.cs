using System.Collections.Generic;
using BoardOfCreation.Ui.Slot.ItemSlot;
using Inventory;
using Objects;
using Ui;
using UnityEngine;

namespace Crafting
{
    public class CraftingManager : MonoBehaviour
    {
        [SerializeField] private CraftingSlot input1;
        [SerializeField] private CraftingSlot input2;
        [SerializeField] private ResultSlot resultSlot;
        
        [SerializeField] private ItemInventory itemInventory;
        [SerializeField] private List<GameObject> slots = new List<GameObject>();
        [SerializeField] private GameObject contentView;
        [SerializeField] private GameObject slotsPrefab;

        private void Start()
        {
            GameEvents.Current.OnCratingItemSlotChange += OnCratingIngredientsChange;
            GameEvents.Current.OnRecipeResultSlotChange += item =>
            {
                itemInventory.AddItem(item);
                input1.SetItem(null);
                input2.SetItem(null);
                resultSlot.SetItem(null);
            };
            GameEvents.Current.OnItemInventoryChangeEvent += UpdateItemList;

            foreach (var item in itemInventory.slots)
            {
                var slot = Instantiate(slotsPrefab, contentView.transform);
                slot.GetComponent<ItemSlot>().SetItem(item);
                slots.Add(slot);
            }
        }

        private void OnCratingIngredientsChange(Item item)
        {
            var recipe = RecipeManager.Instance.FindRecipe(input1.GetItem(), input2.GetItem());
            resultSlot.SetItem(recipe ? recipe.result : null);
        }

        private void UpdateItemList()
        {
            for (var i = 0; i < itemInventory.slots.Length; i++)
            {
                if (!itemInventory.slots[i]) continue;
                ItemSlot slot = slots[i].GetComponent<ItemSlot>();
                slot.SetItem(itemInventory.slots[i]);
            }
        }
    }
}