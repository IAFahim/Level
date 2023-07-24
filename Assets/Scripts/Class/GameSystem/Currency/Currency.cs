using System;
using Class.GameSystem.Info;
using TriInspector;
using UnityEngine;

namespace Class.GameSystem.Currency
{
    [Serializable]
    public class Currency<T, TComparable> : UiInfo, ICurrency<T, TComparable>
        where TComparable : struct, IComparable<TComparable>
    {
        [OnValueChanged(nameof(SetTargetAsKey))] [SerializeField]
        protected T target;

        [SerializeField]
        protected TComparable count;


        public T Target
        {
            get => target;
            set => target = value;
        }

        public TComparable Count
        {
            get => count;
            set => count = value;
        }

        public Currency(T type, TComparable count)
        {
            this.target = type;
            this.count = count;
        }

        public void SetTargetAsKey()
        {
            Key = target.ToString();
        }
    }
}