using System;
using Class.GameSystem.Info;
using UnityEngine;

namespace Class.GameSystem.Interaction
{
    [Serializable]
    public class LockItem<T> : ILockAble<T>
    {

        [SerializeField]
        protected Sprite icon;

        [SerializeField]
        protected bool isLocked;

        [SerializeField]
        protected bool isCurrent;

        [SerializeField]
        protected T price; 

        public Sprite Icon
        {
            get => icon;
            set => icon = value;
        }

        public bool IsLocked
        {
            get => isLocked;
            set => isLocked = value;
        }

        public bool IsCurrent
        {
            get => isCurrent;
            set => isCurrent = value;
        }

        public T Price
        {
            get => price;
            set => price = value;
        }
    }
}