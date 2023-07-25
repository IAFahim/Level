using System;
using Class.GameSystem.Info;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Currency
{
    [Serializable]
    public class Currency<T, TComparable> : UiInfo, ICurrency<T, TComparable>, IKey
        where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField] [DisableInEditMode] protected string key;
        [OnValueChanged(nameof(SetAskKey))] [SerializeField]
        protected T target;

        [FormerlySerializedAs("count")] [SerializeField]
        protected TComparable value;
        
        public string Key => key;
        
        public void SetAskKey()
        {
            this.key = key;
        }

        public T Target
        {
            get => target;
            set => target = value;
        }

        public TComparable Value
        {
            get => value;
            set => this.value = value;
        }

        public Currency(T type, TComparable value)
        {
            this.target = type;
            this.value = value;
        }

        
    }
}