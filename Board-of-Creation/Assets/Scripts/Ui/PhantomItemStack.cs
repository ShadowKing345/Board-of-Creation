using System;
using Objects;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class PhantomItemStack : MonoBehaviour
    {
        [SerializeField] private Text text;
        public Itemstack stack = null;
        private Image _image;
    }
}
