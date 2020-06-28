using System;
using Objects;
using UnityEngine;
using UnityEngine.UI;

namespace BoardOfCreation.Ui.Slot
{
    public class PhantomItemStack : MonoBehaviour, IPhantomItem
    {
        [SerializeField] private Text text;
        [SerializeField] private Itemstack stack;
        [SerializeField] private Image image;

        private void Awake()
        {
            if (stack == null)
                stack = new Itemstack();

            UpdateImage();
        }

        private void UpdateImage()
        {
            if(!image || stack.item == null) return;
            image.sprite = stack.item.image;
            
            if (!text) return;
            text.enabled = stack.Amount > 0;
            text.text = stack.Amount.ToString();
        }

        public void SetItem(Item item)
        {
            stack.item = item;
            UpdateImage();
        }

        public void SetItemStack(Itemstack itemstack)
        {
            stack = itemstack;
            UpdateImage();
        }

        public void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}
