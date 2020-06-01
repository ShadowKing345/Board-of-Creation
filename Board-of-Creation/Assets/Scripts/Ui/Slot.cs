using System;
using Objects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ui
{
    public class Slot : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Image image;
        [SerializeField] private Text text;
        public Itemstack stack;
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject itemUiObjPrefab;
        private GameObject _itemUiObj;

        private void Update()
        {
            text.text = (stack.Amount < 2) ? "" : stack.Amount.ToString() ;
            if (!stack.IsEmpty())
                image.sprite = stack.item.image;
        }

        public void OnPointerDown(PointerEventData eventData) { }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(stack.IsEmpty()) return;
            _itemUiObj = Instantiate(itemUiObjPrefab, transform);
            _itemUiObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            _itemUiObj.GetComponent<Item>().stack = stack;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(stack.IsEmpty()) return;
            _itemUiObj.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Destroy(_itemUiObj);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) return;
            
            var obj = eventData.pointerDrag;
            var slot = obj.GetComponent<Slot>();
            
            if (slot == null || slot.stack.IsEmpty()) return;
            
            stack = slot.stack;
            slot.stack = new Itemstack();
        }
    }
}
