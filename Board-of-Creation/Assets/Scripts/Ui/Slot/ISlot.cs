using BoardOfCreation.Objects;
using BoardOfCreation.Ui.Containers;
using UnityEngine.EventSystems;

namespace BoardOfCreation.Ui.Slot
{
    public interface ISlot: IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        Container Container { get; set; }
        int Id { get; set; }

        void UpdateSlot();

        Item Item
        {
            get;
            set;
        }

        ItemStack Stack
        {
            get;
            set;
        }

        void ClearSlot();
    }
}