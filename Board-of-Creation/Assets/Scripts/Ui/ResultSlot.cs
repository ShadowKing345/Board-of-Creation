using UnityEngine.EventSystems;

namespace Ui
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