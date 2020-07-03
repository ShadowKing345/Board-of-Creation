using System;
using BoardOfCreation.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace BoardOfCreation.Ui.Slot.HoverUiElement
{
    public class HoverUiElement : MonoBehaviour
    {
        [SerializeField] private Vector2 offset;
        
        public Item Item
        {
            set { item = value;
                UpdateView();
            }
        }
        [SerializeField] private Item item; 
        [SerializeField] private Image image;
        [SerializeField] private Text nameText;
        [SerializeField] private Text descriptionText;

        [SerializeField] private RectTransform rect;
        private void Start() => Move();
        private void Update() => Move();

        private void Move() 
        {
            Vector3 screenSize = new Vector3(Screen.width, Screen.height);
            Vector3 size = rect.rect.size;
            Vector3 mousePos = Input.mousePosition;
            
            float mouseOf = mousePos.y / screenSize.y;
            Vector3 pos = mousePos + new Vector3(size.x, mouseOf >= 0.5f ? size.y * -1: size.y, 0) / 2 + new Vector3(offset.x, mouseOf >= 0.5f ? offset.y : offset.y * -1, 0);
            
            transform.position = new Vector3(pos.x < size.x ? size.x / 2: pos.x > screenSize.x ? screenSize.x - size.x / 2 : pos.x , pos.y, 0);
        }

        public void UpdateView()
        {
            if (!item) return;
            if (image) image.sprite = item.image;
            if (nameText) nameText.text = item.name;
            if (descriptionText) descriptionText.text = item.description;
        }
    }
}