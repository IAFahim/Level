using System;
using System.Collections.Generic;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    [Serializable]
    public class Rewards<T, TV> : IRewards<T, TV>
    {
        [SerializeField] private List<Reward<T, TV>> _rewards;

        public Rewards()
        {
            Type type = typeof(T);
            if (type.IsEnum)
            {
                Array enumType = System.Enum.GetValues(typeof(T));
                var enumSize = enumType.Length;
                _rewards = new(enumSize);
                for (int i = 0; i < enumSize; i++)
                {
                    _rewards.Add(new Reward<T, TV>((T)enumType.GetValue(i), default));
                }
            }
            else
            {
                _rewards = new();
            }
        }

        public Reward<T, TV> Get(object type)
        {
            int index = (int)type;
            if (index < _rewards.Count) return _rewards[index];
            return default;
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