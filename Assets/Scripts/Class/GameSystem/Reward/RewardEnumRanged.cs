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
        [SerializeField] private string title;

        [SerializeField] [Multiline(3)] private string description;

        [SerializeField] private TV currentValue;

        [SerializeField] [Group("type")] private T type;

        [SerializeField] [Group("type")] private RewardFunctionType rewardFunctionType;

        private Func<TV, TV, TV, TV> _rewardFunction;

        [Group("vars")] public TV lower;

        [Group("vars")] public TV upper;

        [SerializeField] [Group("condition")] private int claimCount;

        [SerializeField] [Group("condition")] private int maxClaimCount = 1;

        [SerializeField] private AnimationCurve curve;

        public RewardEnumRanged(T type, TV value)
        {
            this.type = type;
            currentValue = value;
        }

        public RewardEnumRanged(T type, TV lower, TV upper, Func<TV, TV, TV, TV> rewardFunction,
            AnimationCurve animationCurve)
        {
            this.type = type;
            this.lower = lower;
            this.upper = upper;
            if (rewardFunction != null)
            {
                RewardFunctionType = RewardFunctionType.Custom;
            }

            this.CustomRewardFunction = rewardFunction;
            Curve = animationCurve;
        }

        public string Title
        {
            get => title;
            set
            {
                var trim = value.Trim();
                if (trim.Length > 0)
                {
                    title = trim;
                }
            }
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public TV CurrentValue
        {
            get => currentValue;
            set => currentValue = value;
        }

        public int ClaimCount
        {
            get => claimCount;
            set => claimCount = value;
        }

        public int MaxClaimCount
        {
            get => maxClaimCount;
            set => maxClaimCount = value;
        }

        public TV Lower
        {
            get => lower;
            set => lower = value;
        }

        public TV Upper
        {
            get => upper;
            set => upper = value;
        }

        public T Type { get; set; }

        public RewardFunctionType RewardFunctionType
        {
            get => rewardFunctionType;
            set => rewardFunctionType = value;
        }

        public AnimationCurve Curve
        {
            get => curve;
            set => curve = value;
        }

        public Func<TV, TV, TV, TV> CustomRewardFunction
        {
            get => _rewardFunction;
            set => _rewardFunction = value;
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


        public void SetToCustomRewardFunction()
        {
            RewardFunctionType = RewardFunctionType.Custom;
        }

        public void SetToCustomRewardFunction(Func<TV, TV, TV, TV> function)
        {
            RewardFunctionType = RewardFunctionType.Custom;
            this.CustomRewardFunction = function;
        }


        public TV GenerateNewReward()
        {
            if (RewardFunctionType == RewardFunctionType.Min)
            {
                return MinFunc(currentValue, lower, upper);
            }

            if (RewardFunctionType == RewardFunctionType.Random)
            {
                return RandomFunc(currentValue, lower, upper);
            }

            if (RewardFunctionType == RewardFunctionType.RandomOnCurve)
            {
                return RandomOnCurveFunc(currentValue, lower, upper);
            }

            if (RewardFunctionType == RewardFunctionType.Custom)
            {
                return CustomRewardFunction(currentValue, lower, upper);
            }

            return default;
        }

        public TV GetGeneratedValueAndIncrementClaim(bool increment = true)
        {
            if (increment) IncrementClaimCount();
            return GenerateNewReward();
        }

        public void SetRange(TV lowerBound, TV upperBound)
        {
            Lower = lowerBound;
            Upper = upperBound;
        }

        public static implicit operator float(RewardEnumRanged<T, TV> rewardEnumRanged)
        {
            return Convert.ToSingle(rewardEnumRanged.currentValue);
        }

        public static implicit operator int(RewardEnumRanged<T, TV> rewardEnumRanged)
        {
            return Convert.ToInt32(rewardEnumRanged.currentValue);
        }

        public static implicit operator bool(RewardEnumRanged<T, TV> rewardEnumRanged)
        {
            return rewardEnumRanged.IsClaimable();
        }

        public TV MinFunc(TV value, TV lowerBound, TV upperBound)
        {
            return lowerBound;
        }

        public TV RandomFunc(TV value, TV lowerBound, TV upperBound)
        {
            if (typeof(TV) == typeof(int))
            {
                int minValue = Convert.ToInt32(lowerBound);
                int maxValue = Convert.ToInt32(upperBound);
                int randomValue = UnityEngine.Random.Range(minValue, maxValue + 1);
                return (TV)(object)randomValue;
            }

            if (typeof(TV) == typeof(float))
            {
                float minValue = Convert.ToSingle(lowerBound);
                float maxValue = Convert.ToSingle(upperBound);
                float randomValue = UnityEngine.Random.Range(minValue, maxValue);
                return (TV)(object)randomValue;
            }

            // For other types, generate a random value between 0 and 1
            float randomFloat = UnityEngine.Random.value;
            if (randomFloat < 0.5f)
            {
                return lowerBound;
            }
            else
            {
                return upperBound;
            }
        }

        public TV RandomOnCurveFunc(TV value, TV lowerBound, TV upperBound)
        {
            float randomTime = UnityEngine.Random.value;
            float mappedTime = Curve.Evaluate(randomTime);

            if (typeof(TV) == typeof(int))
            {
                int minValue = Convert.ToInt32(lowerBound);
                int maxValue = Convert.ToInt32(upperBound);
                int interpolatedValue = Mathf.RoundToInt(Mathf.Lerp(minValue, maxValue, mappedTime));
                return (TV)(object)interpolatedValue;
            }

            if (typeof(TV) == typeof(float))
            {
                float minValue = Convert.ToSingle(lowerBound);
                float maxValue = Convert.ToSingle(upperBound);
                float interpolatedValue = Mathf.Lerp(minValue, maxValue, mappedTime);
                return (TV)(object)interpolatedValue;
            }

            if (typeof(List<>) == typeof(TV))
            {
                List<TV> list = (List<TV>)(object)lowerBound;
                int index = Mathf.RoundToInt(Mathf.Lerp(0, list.Count - 1, mappedTime));
                return list[index];
            }

            if (mappedTime > 0.5) return upperBound;
            return lowerBound;
        }


        public override string ToString()
        {
            return $"{type} {CurrentValue} {Lower} {Upper} {RewardFunctionType}";
        }
    }
}