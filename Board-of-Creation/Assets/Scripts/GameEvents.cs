using System;
using Objects;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current;
    private void Awake()
    {
        Current = this;
    }

    public event Action<Item> OnCratingItemSlotChange;
    public void CraftingSlotItemChangeEvent(Item item)
    {
        OnCratingItemSlotChange?.Invoke(item);
    }

    public event Action<Item> OnRecipeResultSlotChange;
    public void RecipeResultSlotAction(Item item)
    {
        OnRecipeResultSlotChange?.Invoke(item);
    }

    public event Action OnItemInventoryChangeEvent;

    public void UpdateItemInventory()
    {
        OnItemInventoryChangeEvent?.Invoke();
    }
}