namespace Class.GameSystem.Reward
{
    public interface IRewards<T, TV>
    {
        Reward<T, TV> Get(object type);
        void Set(object type, TV value);
        int GetLength();
        string ToString();
    }
}