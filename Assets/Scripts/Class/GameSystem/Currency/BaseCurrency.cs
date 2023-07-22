using System;
using UnityEngine;

namespace Class.GameSystem.Currency
{
    public class BaseCurrency<T,TComparable>: ICurrency<T,TComparable> where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField]
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

        public BaseCurrency(T type, TComparable count)
        {
            this.target = type;
            this.count = count;
        }
    }
}