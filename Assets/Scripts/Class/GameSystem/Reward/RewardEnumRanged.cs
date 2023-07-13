using System;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("type")]
    [DeclareHorizontalGroup("vars")]
    [DeclareHorizontalGroup("condition")]
    [Serializable]
    public class RewardEnumRanged<T, TV> : IRewardEnumRanged<T, TV>
        where T : System.Enum where TV : struct, IComparable<TV>
    {
        public string title;

        [Multiline(3)] public string description;

        [SerializeField] private TV oldValue;
        
        [Group("type")] public T type;

        [Group("type")] public RewardType funcType;

        public Func<TV, TV, TV, TV> rewardFunction;

        public AnimationCurve animationCurve;

        [Group("vars")] public TV min;

        [Group("vars")] public TV max;

        [Group("condition")] public int claimCount;

        [Group("condition")] public int maxClaimCount = 1;

        public RewardEnumRanged(T type, TV oldValue)
        {
            this.type = type;
            this.oldValue = oldValue;
            funcType = RewardType.Min;
        }

        public RewardEnumRanged(T type, TV min, TV max)
        {
            this.type = type;
            this.min = min;
            this.max = max;
            this.funcType = RewardType.Random;
        }

        public RewardEnumRanged(T type, TV min, TV max, AnimationCurve animationCurve)
        {
            this.type = type;
            this.min = min;
            this.max = max;
            this.animationCurve = animationCurve;
            funcType = RewardType.RandomOnCurve;
        }

        public RewardEnumRanged(T type, TV min, TV max, Func<TV, TV, TV, TV> rewardFunction,
            AnimationCurve animationCurve)
        {
            this.type = type;
            this.min = min;
            this.max = max;
            this.rewardFunction = rewardFunction;
            this.animationCurve = animationCurve;
            funcType = RewardType.Custom;
        }

        public void SetRewardType(RewardType rewardType)
        {
            funcType = rewardType;
            if (rewardType == RewardType.Random)
            {
                rewardFunction = RandomFunc;
            }
            else if (rewardType == RewardType.RandomOnCurve)
            {
                rewardFunction = RandomOnCurveFunc;
            }
            else if (rewardType == RewardType.Min)
            {
                rewardFunction = NoneFunc;
            }
        }

        public void SetCustomRewardFunction(Func<TV, TV, TV, TV> rewardFunction)
        {
            funcType = RewardType.Custom;
            this.rewardFunction = rewardFunction;
        }

        public TV GetOldReward()
        {
            return oldValue;
        }

        private TV GenerateNewReward()
        {
            SetRewardType(funcType);
            oldValue = rewardFunction(oldValue, min, max);
            return oldValue;
        }

        public TV GenerateValueAndIncrementClaim(bool increment = true)
        {
            if (increment) IncrementClaimCount();
            return GenerateNewReward();
        }

        public void SetReward(TV value)
        {
            this.oldValue = value;
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

        public void SetRange(TV min, TV max)
        {
            this.min = min;
            this.max = max;
        }

        public AnimationCurve GetAnimationCurve()
        {
            return animationCurve;
        }

        public void SetAnimationCurve(AnimationCurve curve)
        {
            animationCurve = curve;
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

        public static implicit operator float(RewardEnumRanged<T, TV> rewardEnumRanged)
        {
            return Convert.ToSingle(rewardEnumRanged.GetOldReward());
        }

        public static implicit operator int(RewardEnumRanged<T, TV> rewardEnumRanged)
        {
            return Convert.ToInt32(rewardEnumRanged.GetOldReward());
        }

        public static implicit operator bool(RewardEnumRanged<T, TV> rewardEnumRanged)
        {
            return rewardEnumRanged.IsClaimable();
        }


        public TV NoneFunc(TV value, TV min, TV max)
        {
            return min;
        }

        public TV RandomFunc(TV value, TV min, TV max)
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

        public TV RandomOnCurveFunc(TV value, TV min, TV max)
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

            if (typeof(List<>) == typeof(TV))
            {
                List<TV> list = (List<TV>)(object)min;
                int index = Mathf.RoundToInt(Mathf.Lerp(0, list.Count - 1, mappedTime));
                return list[index];
            }

            if (mappedTime > 0.5) return max;
            return min;
        }


        public override string ToString()
        {
            string rewardString = $"{{\"Type\":\"{funcType}\", \"Value\":\"{oldValue}\"";
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