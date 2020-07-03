using System.Collections;
using System.Linq;
using BoardOfCreation.Crafting;
using BoardOfCreation.Inventory;
using BoardOfCreation.Objects;
using BoardOfCreation.Ui.Slot;
using BoardOfCreation.Ui.Slot.ItemSlot;
using UnityEngine;

namespace BoardOfCreation.Ui.Containers
{
    public class CraftingContainer : Container
    {
        [SerializeField] private CraftingSlot input1;
        [SerializeField] private CraftingSlot input2;
        [SerializeField] private ResultSlot resultSlot;
        
        [SerializeField] private ItemInventory itemInventory;
        [SerializeField] private GameObject contentView;

        private void Start()
        {
            Clear();
            
            EventManager.current.OnSlotUpdated += slot =>
            {
                if (new ISlot[] {input1, input2}.Contains(slot))
                    UpdateResult();
            };
            EventManager.current.OnResultSlotUpdated += slot =>
            {
                if (slot != resultSlot) return;
                AddItemToList(slot.Item);
                ClearCraftingSlots();
            };

            AddSlot(input1);
            AddSlot(input2);
            AddSlot(resultSlot);
            
            ClearCraftingSlots();

            StartCoroutine(InventoryCreation());
        }

        private void AddItemToList(Item item)
        {
            itemInventory.AddItem(item);
            UpdateItemInventory();
        }
        
        private void ClearCraftingSlots()
        {
            input1.ClearSlot();
            input2.ClearSlot();
            resultSlot.ClearSlot();
        }

        public override void MoveItemStack(int fromId, int toId)
        {
            if (new ISlot[] {input1, input2}.Contains(slots[toId]))
            {
                ISlot from = slots[fromId], to = slots[toId];
                to.Stack = from.Stack;
            }
        }

        private void UpdateResult()
        {
            Item result = CraftingManager.current.FindRecipeResult(input1.Item, input2.Item);
            if (result) resultSlot.Item = result;
            else resultSlot.ClearSlot();
        }

        private void UpdateItemInventory()
        {
            for (int i = 0; i < itemInventory.slots.Length; i++)
            {
                slots[i + 3].Item = itemInventory.slots[i];
            }
        }

        private IEnumerator InventoryCreation()
        {
            var wait = new WaitForFixedUpdate();
            foreach (var item in itemInventory.slots)
            {
                var slot = Instantiate(slotsPrefab, contentView.transform);
                yield return wait;
                AddSlot(slot.GetComponent<ISlot>(), new ItemStack() {item = item});
            }
        }
    }
}