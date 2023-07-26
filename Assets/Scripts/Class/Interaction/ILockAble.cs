namespace Class.Interaction
{
    public interface ILockAble<T>
    {
        T Price { get; set; }
        bool IsLocked { get; set; }
        
    }
}