using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Interaction
{
    [Serializable]
    public class UnlockRequirement<T> : ILockAble<T>
    {
        [SerializeField]
        protected bool isLocked;

        [FormerlySerializedAs("isEquiped")] [FormerlySerializedAs("isEqupied")] [FormerlySerializedAs("isCurrent")] [SerializeField]
        protected bool isEquipped;

        [SerializeField]
        protected T price;

        public bool IsLocked
        {
            get => isLocked;
            set => isLocked = value;
        }

        public bool IsEquipped
        {
            get => isEquipped;
            set => isEquipped = value;
        }

        public T Price
        {
            get => price;
            set => price = value;
        }
    }
}