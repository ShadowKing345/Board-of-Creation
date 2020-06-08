using Objects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ui
{
    public class ItemSlotBase : MonoBehaviour,IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler
    {
        [SerializeField] protected Image image;
        [SerializeField] protected Item item;
        [SerializeField] protected GameObject phantomItemPrefab;
        private GameObject _phantomItem;

        private void Start()
        {
            UpdateItemImagePreview();
        }
        
        protected virtual void UpdateItemImagePreview()
        {
            image.enabled = (bool) item;
            image.sprite = item ? item.image : null;
        }

        public virtual void SetItem(Item item)
        {
            this.item = item;
            UpdateItemImagePreview();
        }

        public virtual Item GetItem()
        {
            return item;
        }

        public virtual void OnDrop(PointerEventData eventData)
        {
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
        }
        
        public virtual void OnDrag(PointerEventData eventData)
        {
            
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (!item) return;
            if (!phantomItemPrefab) return;
            
            _phantomItem = Instantiate(phantomItemPrefab, GetComponentInParent<Canvas>().transform);
            
            var hold = _phantomItem.GetComponent<PhantomItem>();
            if (hold) 
                hold.SetItem(item);
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            Destroy(_phantomItem);
        }
    }
}