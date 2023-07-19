using System;
using Class.GameSystem.Reward;
using UnityEngine;

namespace Class.GameSystem.Interaction
{
    public interface IRange<T, TComparable> where TComparable : struct, IComparable<TComparable>
    {
        RewardFunctionType RewardFunctionType { get; set; }
        TComparable Lower { get; set; }
        TComparable Upper { get; set; }
        Func<T, TComparable> CustomRewardFunction { get; set; }
        void SetRange(TComparable lowerBound, TComparable upperBound);
        AnimationCurve Curve { get; set; }
    }
}