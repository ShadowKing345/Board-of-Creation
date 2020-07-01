using System;
using BoardOfCreation.Objects;
using BoardOfCreation.Ui.Slot;
using BoardOfCreation.Ui.Slot.ItemSlot;
using UnityEngine;

namespace BoardOfCreation
{
    public sealed class EventManager : MonoBehaviour
    {
        public static EventManager current;
        private void Awake()
        {
            current = this;
        }

        public event Action<ISlot> OnSlotUpdated;

        public void SlotUpdated(ISlot slot)
        {
            OnSlotUpdated?.Invoke(slot);
        }

        public event Action<ResultSlot> OnResultSlotUpdated;

        public void ResultSlotUpdated(ResultSlot slot)
        {
            OnResultSlotUpdated?.Invoke(slot);
        }
    }
}