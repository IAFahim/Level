using System;
using Class.GameSystem.SaveAble;

namespace Class.GameSystem.Reward
{
    public interface IReward<out TComparable>: ISaveAble
        where TComparable : struct, IComparable<TComparable>
    {
        string Title { get; set; }
        string Description { get; set; }
        TComparable ObjectCount { get; }
        public void SetTypeAsKey();
        int ClaimCount { get; set; }
        int MaxClaimCount { get; set; }
        void IncrementClaimCount();
        bool IsClaimable();
    }
}