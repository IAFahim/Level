﻿using System;
using Class.Interaction;
using UnityEngine;

namespace Class.Currency
{
    [Serializable]
    public class CurrencyRange<T, TComparable> : BaseCurrency<T, TComparable>, IRange<TComparable>
        where T : System.Enum
        where TComparable : struct, IComparable<TComparable>
    {
        public CurrencyRange(T type, TComparable value) : base(type, value)
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