namespace Class.Interaction
{
    public interface ILockAble<T> : ICheckAble
    {
        T Price { get; set; }
        T Offer { get; set; }
        bool IsLocked { get; set; }
        bool TryToUnlock(T value);
    }
}