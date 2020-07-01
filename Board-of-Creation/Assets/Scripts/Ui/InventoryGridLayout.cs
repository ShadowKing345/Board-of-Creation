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

            RectOffset padding1;
            cellSize.x = cellSize.y = rectTransform.rect.width / columns - spacing.x / columns * (columns - 1) -
                                      (padding1 = padding).left / (float) columns - padding1.right / (float) columns;
            
            for (var i = 0; i < rectChildren.Count; i++)
            {
                var item = rectChildren[i];

                var xPos = (cellSize.x + spacing.x) * (i % columns) + padding1.left;
                var yPos = (cellSize.y + spacing.y) * (i / columns) + padding1.left;
                
                SetChildAlongAxis(item, 0, xPos, cellSize.x);
                SetChildAlongAxis(item, 1, yPos, cellSize.y);
            }
        }

        public override void CalculateLayoutInputVertical()
        {
        }

        public override void SetLayoutHorizontal()
        {
        }

        public override void SetLayoutVertical()
        {
        }
    }
}
