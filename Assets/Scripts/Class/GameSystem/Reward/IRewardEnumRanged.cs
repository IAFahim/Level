using System;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    public interface IRewardEnumRanged<T, TComparable> : IReward<TComparable>
        where T : System.Enum where TComparable : struct, IComparable<TComparable>
    {
        public T Type { get; set; }
        RewardFunctionType RewardFunctionType { get; set; }
        public TComparable Lower { get; set; }
        public TComparable Upper { get; set; }
        Func<IRewardEnumRanged<T, TComparable>, TComparable> CustomRewardFunction { get; set; }
        void SetToCustomRewardFunction(Func<IRewardEnumRanged<T, TComparable>, TComparable> function);
        public TComparable GenerateNewReward();
        TComparable GetGeneratedValueAndIncrementClaim(bool increment = true);
        AnimationCurve Curve { get; set; }
        void SetRange(TComparable lowerBound, TComparable upperBound);
    }
}