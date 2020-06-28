using UnityEngine.EventSystems;

namespace BoardOfCreation.Ui.Slot.ItemSlot
{
    public class ResultSlot : ItemSlotBase
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            if(!item) return;
            GameEvents.Current.RecipeResultSlotAction(item);
        }
    }
}