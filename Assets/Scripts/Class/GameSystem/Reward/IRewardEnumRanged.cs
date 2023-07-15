using System;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    public interface IRewardEnumRanged<T, TV> : IReward<TV>
        where T : System.Enum where TV : struct, IComparable<TV>
    {
        public T Type { get; set; }
        
        RewardFunctionType RewardFunctionType { get; set; }
        
        Func<TV, TV, TV, TV> CustomRewardFunction { get; set; }
        AnimationCurve Curve { get; set; }
        void SetRange(TV lowerBound, TV upperBound);
    }
}