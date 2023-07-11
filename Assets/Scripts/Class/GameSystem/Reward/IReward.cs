using UnityEngine;

namespace Class.GameSystem.Reward
{
    public interface IReward<T, TV>
    {
        TV GetOldReward();
        TV GenerateValueAndIncrementClaim(bool increment = true);
        void SetReward(TV value);
        int GetClaimCount();
        void SetClaimCount(int count);
        int GetMaxClaimCount();
        void SetMaxClaimCount(int count);
        
        AnimationCurve GetAnimationCurve();
        
        void SetAnimationCurve(AnimationCurve curve);
        void Reset();
        void IncrementClaimCount();
        bool IsClaimable();
    }
}