using System;
using System.Collections.Generic;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    [Serializable]
    public class Rewards<T, V> where V : struct
    {
        [SerializeField] private List<Reward<T, V>> _rewards;

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
                    _rewards.Add(new Reward<T, V>((T)enumType.GetValue(i), default, false));
                }
            }
            else
            {
                _rewards = new();
            }
        }

        public Reward<T, V> Get(object type)
        {
            int index = (int)type;
            if (index < _rewards.Count) return _rewards[index];
            return default;
        }

        public void Set(object type, V value)
        {
            int index = (int)type;
            if (index < _rewards.Count) _rewards[index].value = value;
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
                result += $"\"{_rewards[i].stats}\": \"{_rewards[i].value}\"";
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