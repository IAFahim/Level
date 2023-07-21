using System;
using Class.GameSystem.Reward;
using UnityEngine;

namespace Class.GameSystem.Interaction
{
    public interface IRangeCurveFunction<T, TComparable>: IRange<TComparable> where TComparable : struct, IComparable<TComparable>
    {
        RewardFunctionType RewardFunctionType { get; set; }
        Func<T, TComparable> CustomRewardFunction { get; set; }
        AnimationCurve Curve { get; set; }
    }
}