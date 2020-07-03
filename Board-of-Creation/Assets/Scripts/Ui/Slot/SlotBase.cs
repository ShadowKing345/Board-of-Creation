using System;
using BoardOfCreation.Objects;
using BoardOfCreation.Ui.Containers;
using BoardOfCreation.Ui.Slot.PhantomItem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BoardOfCreation.Ui.Slot
{
    public class SlotBase : MonoBehaviour, ISlot
    {
        #region Varibles
        public Container Container { get => container; set => container = value; }
        [SerializeField] private Container container;
        public int Id { get => id; set => id = value; }
        [SerializeField] private int id;
        
        [SerializeField] protected Image image;
        [SerializeField] protected Text text;
        
        #region PhantomItem
            [SerializeField] protected GameObject phantomItemPrefab;
            private GameObject phantomItem;
        #endregion
        
        #region HoverUiElement
            [SerializeField] protected GameObject hoverUiElementPrefab;
            private GameObject hoverUiElement;
        #endregion
        
        #region ItemStack
        [SerializeField] protected ItemStack stack;
        public virtual ItemStack Stack
        {
            get => stack;
            set
            {
                stack = value ?? new ItemStack();
                UpdateSlot();
                EventManager.current.SlotUpdated(this);
            }
        }

        public virtual Item Item
        {
            get => stack.HasNoItem() ? null : stack.item;
            set => Stack = new ItemStack() {item = value};
        }

        #endregion

        private Canvas canvas;
        #endregion
        
        private void Start()
        {
            ClearSlot();
        }
        
        public virtual void UpdateSlot()
        {
            if(!image) return;
            if (!stack.HasNoItem())
            {
                image.enabled = true;
                image.sprite = stack.item.image;
            }
            else
            {
                image.enabled = false;
            }

            if (!text) return;
            text.enabled = stack.Amount > 0;
            text.text = stack.Amount.ToString();
        }

        public void ClearSlot()
        {
            Stack = new ItemStack();
        }

        #region MouseHandlers

        public virtual void OnDrop(PointerEventData eventData)
        {
            GameObject obj = eventData.pointerPress;
            ISlot slot = obj.GetComponent<ISlot>();
            if (slot != null)
            {
                if(slot.Stack.HasNoItem()) return;
                Container.MoveItemStack(slot.Id, id);
            }
        }

        public virtual void OnPointerClick(PointerEventData eventData) { }
        
        public virtual void OnDrag(PointerEventData eventData){ }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (stack.HasNoItem() || !phantomItemPrefab) return;
            if (!canvas) canvas = GetComponentInParent<Canvas>();
            
            phantomItem = Instantiate(phantomItemPrefab, canvas.transform);
            
            var hold = phantomItem.GetComponent<IPhantomItem>();
            hold.SetItemStack(stack);
        }

        public virtual void OnEndDrag(PointerEventData eventData) => Destroy(phantomItem);

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (!hoverUiElementPrefab || stack.HasNoItem()) return;
            if (!canvas) canvas = GetComponentInParent<Canvas>();

            hoverUiElement = Instantiate(hoverUiElementPrefab, canvas.transform);
            hoverUiElement.GetComponent<HoverUiElement.HoverUiElement>().Item = stack.item;
        }

        public virtual void OnPointerExit(PointerEventData eventData) => Destroy(hoverUiElement);

        #endregion
    }
}