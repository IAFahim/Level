using System;
using UnityEngine;

namespace Class.Currency
{
    public interface ICurrencyGenerator<T, TComparable> : ICurrency<T,TComparable>
        where T : System.Enum where TComparable : struct, IComparable<TComparable>
    {
        RewardFunctionType RewardFunctionType { get; set; }
        Func<ICurrencyGenerator<T, TComparable>, TComparable> CustomRewardFunction { get; set; }
        void SetToCustomRewardFunction(Func<ICurrencyGenerator<T, TComparable>, TComparable> function);
        public TComparable Generate();
        AnimationCurve Curve { get; set; }
    }
}