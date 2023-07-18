using System;
using System.Collections.Generic;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    [Serializable]
    public class RewardFullEnumRanged<T, TV> : IRewardFullEnumRanged<T, TV>
        where T : System.Enum where TV : struct, IComparable<TV>
    {
        [SerializeField] private List<RewardEnumRanged<T, TV>> rewards;

        public RewardFullEnumRanged()
        {
            Array enumType = System.Enum.GetValues(typeof(T));
            var enumSize = enumType.Length;
            rewards = new(enumSize);
            for (int i = 0; i < enumSize; i++)
            {
                rewards.Add(new RewardEnumRanged<T, TV>((T)enumType.GetValue(i), default));
            }
        }

        public RewardEnumRanged<T, TV> Get(object type)
        {
            int index = (int)type;
            if (index < rewards.Count) return rewards[index];
            return default;
        }

        public List<RewardEnumRanged<T, TV>> GenerateValueAndIncrementClaim(bool increment = true)
        {
            foreach (var r in rewards)
            {
                if (r) r.GetGeneratedValueAndIncrementClaim(increment);
            }

            return rewards;
        }

        public void Set(object type, TV value)
        {
            int index = (int)type;
            if (index < rewards.Count) rewards[index].ObjectCount = value;
        }

        public int GetLength()
        {
            return rewards.Count;
        }

        public static implicit operator int(RewardFullEnumRanged<T, TV> v)
        {
            return v.rewards.Count;
        }

        public static implicit operator bool(RewardFullEnumRanged<T, TV> v)
        {
            foreach (var r in v.rewards)
            {
                if (r) return true;
            }

            return false;
        }

        public override string ToString()
        {
            string s = "";
            foreach (var r in rewards)
            {
                s += r.ToString() + "\n";
            }

            return s;
        }
    }
}