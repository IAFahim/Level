using System;

namespace Class.GameSystem.Reward
{
    public interface IRewardFullEnumRanged<TEnum, TComparable> where TEnum : System.Enum
        where TComparable : struct, IComparable<TComparable>
    {
        RewardEnumRanged<TEnum, TComparable> Get(object type);
        void Set(object type, TComparable value);
        int GetLength();
        string ToString();
    }
}