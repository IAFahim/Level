using System;

namespace Class.GameSystem.Reward
{
    public interface IReward<out TComparable>
        where TComparable : struct, IComparable<TComparable>
    {
        string Title { get; set; }
        string Description { get; set; }
        TComparable CurrentValue { get; }
        TComparable GetGeneratedValueAndIncrementClaim(bool increment = true);
        int ClaimCount { get; set; }
        int MaxClaimCount { get; set; }
        void Reset();
        void IncrementClaimCount();
        bool IsClaimable();
    }
}