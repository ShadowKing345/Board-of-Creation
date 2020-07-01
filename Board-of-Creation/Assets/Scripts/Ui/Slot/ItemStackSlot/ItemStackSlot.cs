using BoardOfCreation.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace BoardOfCreation.Ui.Slot.ItemStackSlot
{
    public class ItemStackSlot : MonoBehaviour
    {
        public ItemStack stack;
        [SerializeField] private Image image;
        [SerializeField] private Text text;
        [SerializeField] private Canvas canvas;

        private void UpdateImage()
        {
            image.enabled = stack.IsEmpty();
            image.sprite = stack.IsEmpty() ? stack.item.image : null;
        }

    }
}
