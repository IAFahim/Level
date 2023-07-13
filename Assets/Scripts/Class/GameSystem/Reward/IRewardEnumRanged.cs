using System;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    public interface IRewardEnumRanged<T, TV> : IRewardSystem<T, TV>
        where T : System.Enum where TV : struct, IComparable<TV>
    {
        new TV GetOldReward();
        new TV GenerateValueAndIncrementClaim(bool increment = true);
        new void SetReward(TV value);
        new int GetClaimCount();
        new void SetClaimCount(int count);
        new int GetMaxClaimCount();
        new void SetMaxClaimCount(int count);
        void SetRange(TV min, TV max);
        new AnimationCurve GetAnimationCurve();
        new void SetAnimationCurve(AnimationCurve curve);
        new void Reset();
        new void IncrementClaimCount();
        new bool IsClaimable();
    }
}