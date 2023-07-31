using System;
using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Class.Interaction
{
    [Serializable]
    public class Locked<T> : ILockAble<T> where T : IComparable<T>
    {
        [SerializeField] protected bool isLocked;

        [SerializeField] [OnValueChanged(nameof(Check))]
        protected T price;

        [SerializeField] [OnValueChanged(nameof(Check))]
        protected T offer;


        public UnityEvent onLocked;
        public UnityEvent onUnlocked;

        public bool IsLocked
        {
            get => isLocked;
            set
            {
                isLocked = value;
                if (isLocked)
                {
                    onLocked?.Invoke();
                }
                else
                {
                    onUnlocked?.Invoke();
                }
            }
        }

        public T Price
        {
            get => price;
            set => price = value;
        }

        public T Offer
        {
            get => offer;
            set
            {
                offer = value;
                TryToUnlock(offer);
            }
        }

        public bool TryToUnlock(T value)
        {
            if (value.CompareTo(price) >= 0)
            {
                IsLocked = false;
                return true;
            }

            return false;
        }


        public void Check()
        {
            Offer = offer;
        }
    }
}