using BoardOfCreation.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace BoardOfCreation.Ui.Slot.PhantomItem
{
    public class PhantomItemStack : MonoBehaviour, IPhantomItem
    {
        [SerializeField] private Text text;
        [SerializeField] private ItemStack stack;
        [SerializeField] private Image image;

        private void Awake()
        {
            if (stack == null)
                stack = new ItemStack();

            UpdateImage();
            transform.position = Input.mousePosition;
        }

        private void UpdateImage()
        {
            if(!image || stack.HasNoItem()) return;
            image.sprite = stack.item.image;
            
            if (!text) return;
            text.enabled = stack.Amount > 0;
            text.text = stack.Amount.ToString();
        }

        public void SetItemStack(ItemStack itemStack)
        {
            stack = itemStack;
            UpdateImage();
        }

        public void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}
