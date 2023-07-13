using System;
using System.Collections.Generic;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    [Serializable]
    public class RewardsEnumRanged<T, TV> : IRewardsEnumRanged<T, TV>
        where T : System.Enum where TV : struct, IComparable<TV>
    {
        [SerializeField] private List<RewardEnumRanged<T, TV>> _rewards;

        public RewardsEnumRanged()
        {
            Type type = typeof(T);
            if (type.IsEnum)
            {
                Array enumType = System.Enum.GetValues(typeof(T));
                var enumSize = enumType.Length;
                _rewards = new(enumSize);
                for (int i = 0; i < enumSize; i++)
                {
                    _rewards.Add(new RewardEnumRanged<T, TV>((T)enumType.GetValue(i), default));
                }
            }
            else
            {
                _rewards = new();
            }
        }

        public RewardEnumRanged<T, TV> Get(object type)
        {
            int index = (int)type;
            if (index < _rewards.Count) return _rewards[index];
            return default;
        }

        public List<RewardEnumRanged<T, TV>> GenerateValueAndIncrementClaim(bool increment = true)
        {
            foreach (var r in _rewards)
            {
                if (r) r.GenerateValueAndIncrementClaim(increment);
            }

            return _rewards;
        }

        public void Set(object type, TV value)
        {
            int index = (int)type;
            if (index < _rewards.Count) _rewards[index].SetReward(value);
        }

        public int GetLength()
        {
            return _rewards.Count;
        }

        public static implicit operator int(RewardsEnumRanged<T, TV> v)
        {
            return v._rewards.Count;
        }
        
        public static implicit operator bool(RewardsEnumRanged<T, TV> v)
        {
            foreach (var r in v._rewards)
            {
                if (r) return true;
            }

            return false;
        }

        public override string ToString()
        {
            string result = "{";
            for (int i = 0; i < _rewards.Count; i++)
            {
                result += $"\"{_rewards[i].type}\": \"{_rewards[i]}\"";
                if (i < _rewards.Count - 1)
                {
                    result += ", ";
                }
            }

            result += "}";

            return result;
        }
    }
}