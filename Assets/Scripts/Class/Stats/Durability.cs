using System;
using TriInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Class.Stats
{
    [Serializable]
    public class Durability : IDurability 
    {
        [SerializeField] [OnValueChanged(nameof(Check))]
        protected float currentDurability;

        [SerializeField] [OnValueChanged(nameof(Check))]
        protected float maxDurability;

        public UnityEvent<float> onCurrentDurabilityChanged;
        public UnityEvent<float> onMaxDurabilityChanged;
        public UnityEvent<bool> onBroken;

        public float CurrentDurability
        {
            get => currentDurability;
            set
            {
                currentDurability = value;
                IsBroken();
                onCurrentDurabilityChanged?.Invoke(currentDurability);
            }
        }

        public float MaxDurability
        {
            get => maxDurability;
            set
            {
                maxDurability = value;
                IsBroken();
                onMaxDurabilityChanged?.Invoke(maxDurability);
            }
        }

        public bool IsBroken()
        {
            bool broken = currentDurability <= 0;
            if (broken) onBroken?.Invoke(true);
            return broken;
        }
        
        [Button]
        public void Check()
        {
            IsBroken();
        }
    }
}