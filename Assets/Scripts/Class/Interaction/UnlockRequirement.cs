using System;
using UnityEngine;

namespace Class.Interaction
{
    [Serializable]
    public class UnlockRequirement<T> : ILockAble<T>
    {
        [SerializeField]
        protected bool isLocked;

        [SerializeField]
        protected T price;
        
        public bool IsLocked
        {
            get => isLocked;
            set => isLocked = value;
        }

        public T Price
        {
            get => price;
            set => price = value;
        }
    }
}