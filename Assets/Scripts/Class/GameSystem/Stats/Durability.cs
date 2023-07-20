using System;
using UnityEngine;

namespace Class.GameSystem.Stats
{
    [Serializable]
    public class Durability : IDurability
    {
        [SerializeField] protected float currentDurability;
        [SerializeField] protected float maxDurability;
        public float CurrentDurability
        {
            get => currentDurability;
            set => currentDurability = value;
        }
        public float MaxDurability
        {
            get => maxDurability;
            set => maxDurability = value;
        }
    }
}