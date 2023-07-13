using System;

namespace Class.GameSystem.Reward
{
    public interface IRewardsEnumRanged<T, TV> where T : System.Enum
        where TV : struct, IComparable<TV>
    {
        RewardEnumRanged<T, TV> Get(object type);
        void Set(object type, TV value);
        int GetLength();
        string ToString();
    }
}