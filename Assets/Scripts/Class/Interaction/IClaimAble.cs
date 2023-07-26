namespace Class.Interaction
{
    public interface IClaimAble
    {
        int ClaimCount { get; set; }
        int MaxClaimCount { get; set; }
        void IncrementClaimCount();
        bool IsClaimable();
    }
}