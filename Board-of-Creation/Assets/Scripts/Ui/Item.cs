using System;
using Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Text text;
        public Itemstack stack = null;
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            if(stack == null) return;
            
            _image.sprite = stack.item.image;
            text.text = stack.Amount.ToString();
        }
    }
}
