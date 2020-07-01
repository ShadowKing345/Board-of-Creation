using BoardOfCreation.Ui.Containers;
using UnityEngine.EventSystems;

namespace BoardOfCreation.Ui.Slot.ItemSlot
{
    public class ResultSlot : SlotBase
    {
        public override void OnDrop(PointerEventData eventData) { }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (!Stack.HasNoItem())
                EventManager.current.ResultSlotUpdated(this);
        }
        
        public override void OnEndDrag(PointerEventData eventData)
        {
            base.OnEndDrag(eventData);
            if (!Stack.HasNoItem())
                EventManager.current.ResultSlotUpdated(this);
        }
    }
}