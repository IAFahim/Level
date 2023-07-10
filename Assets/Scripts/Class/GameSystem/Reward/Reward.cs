using System;
using UnityEngine;
using TriInspector;
using UnityEngine.Serialization;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("type")]
    [DeclareHorizontalGroup("vars")]
    [DeclareHorizontalGroup("condition")]
    [Serializable]
    public class Reward<T, TV>
    {
        [Group("type")] public T stats;

        [Group("type")] public RewardType rewardType;

        public Func<TV, TV, TV> rewardFunction;

        public string title;

        [Multiline(3)] public string description;

        public TV value;

        public AnimationCurve animationCurve;

        [Group("vars")] public TV min;

        [Group("vars")] public TV max;

        [Group("condition")] public int claimCount;

        [Group("condition")] public int maxClaimCount = 1;

        public Reward(T stats, TV value)
        {
            this.stats = stats;
            this.value = value;
            rewardType = RewardType.Min;
        }

        public Reward(T stats, TV min, TV max, RewardType rewardType)
        {
            this.stats = stats;
            this.rewardType = rewardType;
            this.min = min;
            this.max = max;
        }

        public Reward(T stats, TV min, TV max, AnimationCurve animationCurve)
        {
            this.stats = stats;
            this.min = min;
            this.max = max;
            this.animationCurve = animationCurve;
            rewardType = RewardType.RandomOnCurve;
        }

        public Reward(T stats, TV min, TV max, Func<TV, TV, TV> rewardFunction, AnimationCurve animationCurve)
        {
            this.stats = stats;
            this.min = min;
            this.max = max;
            rewardType = RewardType.Custom;
            this.rewardFunction = rewardFunction;
            this.animationCurve = animationCurve;
        }

        public void SetRewardType(RewardType type)
        {
            rewardType = type;
            if (type == RewardType.Random)
            {
                rewardFunction = RandomFunc;
            }
            else if (type == RewardType.RandomOnCurve)
            {
                rewardFunction = RandomOnCurveFunc;
            }
            else if (type == RewardType.Min)
            {
                rewardFunction = NoneFunc;
            }
        }

        public void SetCustomRewardFunction(Func<TV, TV, TV> rewardFunction)
        {
            rewardType = RewardType.Custom;
            this.rewardFunction = rewardFunction;
        }

        public TV GetReward()
        {
            SetRewardType(rewardType);
            value = rewardFunction(min, max);
            return value;
        }

        public void SetReward(TV value)
        {
            this.value = value;
        }

        public int GetClaimCount()
        {
            return claimCount;
        }

        public void SetClaimCount(int count)
        {
            claimCount = count;
        }

        public int GetMaxClaimCount()
        {
            return maxClaimCount;
        }

        public void SetMaxClaimCount(int count)
        {
            maxClaimCount = count;
        }

        public void Reset()
        {
            claimCount = 0;
        }

        public void IncrementClaimCount()
        {
            claimCount++;
        }

        public bool StillClaimable()
        {
            return claimCount < maxClaimCount;
        }

        public static implicit operator float(Reward<T, TV> reward)
        {
            return Convert.ToSingle(reward.value);
        }

        public static implicit operator int(Reward<T, TV> reward)
        {
            return Convert.ToInt32(reward.value);
        }

        public static implicit operator bool(Reward<T, TV> reward)
        {
            return reward.StillClaimable();
        }


        public TV NoneFunc(TV min, TV max)
        {
            return min;
        }

        public TV RandomFunc(TV min, TV max)
        {
            if (typeof(TV) == typeof(int))
            {
                int minValue = Convert.ToInt32(min);
                int maxValue = Convert.ToInt32(max);
                int randomValue = UnityEngine.Random.Range(minValue, maxValue + 1);
                return (TV)(object)randomValue;
            }

            if (typeof(TV) == typeof(float))
            {
                float minValue = Convert.ToSingle(min);
                float maxValue = Convert.ToSingle(max);
                float randomValue = UnityEngine.Random.Range(minValue, maxValue);
                return (TV)(object)randomValue;
            }

            // For other types, generate a random value between 0 and 1
            float randomFloat = UnityEngine.Random.value;
            if (randomFloat < 0.5f)
            {
                return min;
            }
            else
            {
                return max;
            }
        }

        public TV RandomOnCurveFunc(TV min, TV max)
        {
            float randomTime = UnityEngine.Random.value;
            float mappedTime = animationCurve.Evaluate(randomTime);

            if (typeof(TV) == typeof(int))
            {
                int minValue = Convert.ToInt32(min);
                int maxValue = Convert.ToInt32(max);
                int interpolatedValue = Mathf.RoundToInt(Mathf.Lerp(minValue, maxValue, mappedTime));
                return (TV)(object)interpolatedValue;
            }

            if (typeof(TV) == typeof(float))
            {
                float minValue = Convert.ToSingle(min);
                float maxValue = Convert.ToSingle(max);
                float interpolatedValue = Mathf.Lerp(minValue, maxValue, mappedTime);
                return (TV)(object)interpolatedValue;
            }

            if (mappedTime > 0.5) return max;
            return min;
        }

        public override string ToString()
        {
            string rewardString = $"{{\"Type\":\"{rewardType}\", \"Value\":\"{value}\"";
            rewardString += $", \"Stats\":\"{stats}\"";
            rewardString += $", \"Min\":\"{min}\", \"Max\":\"{max}\"";
            rewardString += $", \"ClaimCount\":\"{claimCount}\", \"MaxClaimCount\":\"{maxClaimCount}\"";
            rewardString += $", \"Title\":\"{title}\"";
            rewardString += $", \"Description\":\"{description}\"";
            rewardString += "}";

            return rewardString;
        }
    }
}