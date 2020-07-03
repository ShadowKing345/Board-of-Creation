using System;
using UnityEngine;
using UnityEngine.UI;

namespace BoardOfCreation.Ui
{
    public class InventoryGridLayout : LayoutGroup
    {
        [SerializeField] private Vector2 spacing;
        [SerializeField] private int columns;
        [SerializeField] private Vector2 cellSize;

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            int childrenCount = rectChildren.Count;
            RectOffset padding1;
            cellSize.x = cellSize.y = rectTransform.rect.width / columns - spacing.x / columns * (columns - 1) -
                                      (padding1 = padding).left / (float) columns - padding1.right / (float) columns;
            
            for (var i = 0; i < childrenCount; i++)
            {
                var item = rectChildren[i];

                var xPos = (cellSize.x + spacing.x) * (i % columns) + padding1.left;
                var yPos = (cellSize.y + spacing.y) * (i / columns) + padding1.top;
                
                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }

            float rectSize = (float) (padding1.top + padding1.bottom + ( cellSize.y + spacing.y ) * Math.Ceiling((float)childrenCount / columns)); 
            SetLayoutInputForAxis(rectSize, rectSize, 1, 1);
        }

        public override void CalculateLayoutInputVertical() { }

        public override void SetLayoutHorizontal() { }
        

        public override void SetLayoutVertical() { }
    }
}
