using System;

namespace Class.GameSystem.Reward
{
    public interface IReward<out TComparable>
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
        string ToJson();
        void Save();
        void Load();
        void Reset();
    }
}