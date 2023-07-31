using System;
using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Class.Interaction
{
    [Serializable]
    public class Equipped : IEquipAble, ICheckAble
    {
        [SerializeField] [OnValueChanged(nameof(Check))]
        protected bool equip;

        public UnityEvent onEquipped;
        public UnityEvent onUnEquipped;

        public bool Equip
        {
            get => equip;
            set
            {
                equip = value;
                if (equip)
                {
                    onEquipped?.Invoke();
                }
                else
                {
                    onUnEquipped?.Invoke();
                }
            }
        }

        public void Check()
        {
            Equip = equip;
        }
    }
}