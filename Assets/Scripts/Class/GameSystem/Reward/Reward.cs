using System;
using UnityEngine;
using TriInspector;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("type")]
    [DeclareHorizontalGroup("vars")]
    [DeclareHorizontalGroup("condition")]
    [Serializable]
    public class Reward<T, TV> : IReward<T, TV>
    {
        [Group("type")] public T type;

        [Group("type")] public RewardType funcType;

        public Func<TV, TV, TV> rewardFunction;

        public string title;

        [Multiline(3)] public string description;

        [SerializeField] private TV value;

        public AnimationCurve animationCurve;

        [Group("vars")] public TV min;

        [Group("vars")] public TV max;

        [Group("condition")] public int claimCount;

        [Group("condition")] public int maxClaimCount = 1;

        public Reward(T type, TV value)
        {
            this.type = type;
            this.value = value;
            funcType = RewardType.Min;
        }

        public Reward(T type, TV min, TV max)
        {
            this.type = type;
            this.min = min;
            this.max = max;
            this.funcType = RewardType.Random;
        }

        public Reward(T type, TV min, TV max, AnimationCurve animationCurve)
        {
            this.type = type;
            this.min = min;
            this.max = max;
            this.animationCurve = animationCurve;
            funcType = RewardType.RandomOnCurve;
        }

        public Reward(T type, TV min, TV max, Func<TV, TV, TV> rewardFunction, AnimationCurve animationCurve)
        {
            this.type = type;
            this.min = min;
            this.max = max;
            this.rewardFunction = rewardFunction;
            this.animationCurve = animationCurve;
            funcType = RewardType.Custom;
        }

        public void SetRewardType(RewardType type)
        {
            funcType = type;
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
            funcType = RewardType.Custom;
            this.rewardFunction = rewardFunction;
        }

        public TV GetOldReward()
        {
            return value;
        }

        private TV GenerateNewReward()
        {
            SetRewardType(funcType);
            value = rewardFunction(min, max);
            return value;
        }

        public TV GenerateValueAndIncrementClaim(bool increment = true)
        {
            if (increment) IncrementClaimCount();
            return GenerateNewReward();
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

        public AnimationCurve GetAnimationCurve()
        {
            return animationCurve;
        }

        public void SetAnimationCurve(AnimationCurve curve)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            claimCount = 0;
        }

        public void IncrementClaimCount()
        {
            claimCount++;
        }

        public bool IsClaimable()
        {
            return claimCount < maxClaimCount;
        }

        public static implicit operator float(Reward<T, TV> reward)
        {
            return Convert.ToSingle(reward.GetOldReward());
        }

        public static implicit operator int(Reward<T, TV> reward)
        {
            return Convert.ToInt32(reward.GetOldReward());
        }

        public static implicit operator bool(Reward<T, TV> reward)
        {
            return reward.IsClaimable();
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
            string rewardString = $"{{\"Type\":\"{funcType}\", \"Value\":\"{value}\"";
            rewardString += $", \"Stats\":\"{type}\"";
            rewardString += $", \"Min\":\"{min}\", \"Max\":\"{max}\"";
            rewardString += $", \"ClaimCount\":\"{claimCount}\", \"MaxClaimCount\":\"{maxClaimCount}\"";
            rewardString += $", \"Title\":\"{title}\"";
            rewardString += $", \"Description\":\"{description}\"";
            rewardString += "}";

            return rewardString;
        }

    }
}