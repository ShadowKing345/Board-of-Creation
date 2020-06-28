using Objects;
using UnityEngine.EventSystems;

namespace BoardOfCreation.Ui.Slot.ItemSlot
{
    public class CraftingSlot : ItemSlotBase
    {
        public override void SetItem(Item item)
        {
            base.SetItem(item);
            GameEvents.Current.CraftingSlotItemChangeEvent(item);
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            SetItem(null);
        }

        public override void OnDrop(PointerEventData eventData)
        {
            var obj = eventData.pointerDrag;
            if (!obj) return;

            var itemSlot = obj.GetComponent<ItemSlotBase>();
            if (!itemSlot || !itemSlot.GetItem()) return;

            SetItem(itemSlot.GetItem());
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            SetItem(null);
        }
    }
}
