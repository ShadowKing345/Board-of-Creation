using Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class PhantomItem : MonoBehaviour
    {
        [SerializeField] private Item item = null;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetItem(Item item)
        {
            this.item = item;
            _image.enabled = (bool) this.item;
            _image.sprite = this.item ? this.item.image : null;
        }
    }
}