using UnityEngine;

namespace Class.GameSystem.Reward
{
    public interface IRewardUnlockAbleList <T>
    {
        T GetOldReward();
        T GenerateValueAndIncrementClaim(bool increment = true);
        void SetReward(T value);
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