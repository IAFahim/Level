using System;
using Class.GameSystem.Interaction;
using UnityEngine;

namespace Class.GameSystem.Currency
{
    [Serializable]
    public class CurrencyRange<T, TComparable> : BaseCurrency<T, TComparable>, IRange<TComparable>
        where T : System.Enum
        where TComparable : struct, IComparable<TComparable>
    {
        public CurrencyRange(T type, TComparable count) : base(type, count)
        {
        }

        [SerializeField] protected TComparable lower;
        [SerializeField] protected TComparable upper;

        public TComparable Lower
        {
            get => lower;
            set => lower = value;
        }

        public TComparable Upper
        {
            get => upper;
            set => upper = value;
        }

        public void SetRange(TComparable lowerBound, TComparable upperBound)
        {
            Lower = lowerBound;
            Upper = upperBound;
        }
    }
}