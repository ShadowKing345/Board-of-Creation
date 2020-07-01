using BoardOfCreation.Objects;
using UnityEngine.EventSystems;

namespace BoardOfCreation.Ui.Slot.ItemSlot
{
    public class CraftingSlot : SlotBase
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            Item = null;
        }
        
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            Item = null;
        }
    }
}
