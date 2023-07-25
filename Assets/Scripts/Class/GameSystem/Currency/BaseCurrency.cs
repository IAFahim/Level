using System;
using UnityEngine;

namespace Class.GameSystem.Currency
{
    [Serializable]
    public class BaseCurrency<T,TComparable>: ICurrency<T,TComparable> where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField]
        protected T target;

        [SerializeField]
        protected TComparable value;

        public BaseCurrency(T type, TComparable value)
        {
            this.target = type;
            this.value = value;
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
    }
}