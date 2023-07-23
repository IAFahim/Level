using System;

namespace Class.GameSystem.Interaction
{
    [Serializable]
    public class ClaimAble : IClaimAble
    {
        public int claimCount;
        public int maxClaimCount;

        public int ClaimCount
        {
            get => claimCount;
            set => claimCount = value;
        }
        
        public int MaxClaimCount
        {
            get => maxClaimCount;
            set => maxClaimCount = value;
        }
        
        
        public void IncrementClaimCount()
        {
            claimCount++;
        }

        public bool IsClaimable()
        {
            return claimCount < maxClaimCount;
        }
    }
}