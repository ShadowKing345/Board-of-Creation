using System;
using Objects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ui
{
    public class ItemStackSlot : MonoBehaviour
    {
        public Itemstack stack;
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
