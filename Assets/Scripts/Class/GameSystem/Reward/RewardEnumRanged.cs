using System;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("type")]
    [DeclareHorizontalGroup("limit")]
    [DeclareHorizontalGroup("condition")]
    [Serializable]
    public class RewardEnumRanged<T, TComparable> : Reward<T, TComparable>, IRewardEnumRanged<T, TComparable>
        where T : System.Enum where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField] [Group("tabs"), Tab("Range")] private RewardFunctionType rewardFunctionType;

        private Func<IRewardEnumRanged<T, TComparable>, TComparable> _rewardFunction;

        [SerializeField] [Group("tabs"), Tab("Range")]
        public TComparable lower;

        [Group("tabs"), Tab("Range")] public TComparable upper;

        [Group("tabs"), Tab("Range")] [SerializeField]
        private AnimationCurve curve;

        public RewardEnumRanged(T type, TComparable count, int maxClaimCount = 1) : base(type, count, maxClaimCount)
        {
        }

        public RewardEnumRanged(T type, TComparable lower, TComparable upper,
            Func<IRewardEnumRanged<T, TComparable>, TComparable> rewardFunction,
            AnimationCurve animationCurve) : base(type, default)
        {
            this.lower = lower;
            this.upper = upper;
            if (rewardFunction != null)
            {
                RewardFunctionType = RewardFunctionType.Custom;
            }

            this.CustomRewardFunction = rewardFunction;
            Curve = animationCurve;
        }


        public TComparable Lower
        {
            get => lower;
            set => lower = value;
        }

        public TComparable Upper
        {
            get => upper;
            set => upper = value;
        }

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

        public Func<IRewardEnumRanged<T, TComparable>, TComparable> CustomRewardFunction
        {
            get => _rewardFunction;
            set => _rewardFunction = value;
        }

        public void SetToCustomRewardFunction()
        {
            RewardFunctionType = RewardFunctionType.Custom;
        }

        public void SetToCustomRewardFunction(Func<IRewardEnumRanged<T, TComparable>, TComparable> function)
        {
            RewardFunctionType = RewardFunctionType.Custom;
            CustomRewardFunction = function;
        }


        public TComparable GenerateNewReward()
        {
            if (RewardFunctionType == RewardFunctionType.Min)
            {
                return MinFunc(objectCount, lower, upper);
            }

            if (RewardFunctionType == RewardFunctionType.Random)
            {
                return RandomFunc(objectCount, lower, upper);
            }

            if (RewardFunctionType == RewardFunctionType.RandomOnCurve)
            {
                return RandomOnCurveFunc(objectCount, lower, upper);
            }

            if (RewardFunctionType == RewardFunctionType.Custom)
            {
                return CustomRewardFunction(this);
            }

            return default;
        }

        public TComparable GetGeneratedValueAndIncrementClaim(bool increment = true)
        {
            if (increment) IncrementClaimCount();
            return GenerateNewReward();
        }

        public void SetRange(TComparable lowerBound, TComparable upperBound)
        {
            Lower = lowerBound;
            Upper = upperBound;
        }

        public static implicit operator float(RewardEnumRanged<T, TComparable> rewardEnumRanged)
        {
            return Convert.ToSingle(rewardEnumRanged.objectCount);
        }

        public static implicit operator int(RewardEnumRanged<T, TComparable> rewardEnumRanged)
        {
            return Convert.ToInt32(rewardEnumRanged.objectCount);
        }

        public static implicit operator bool(RewardEnumRanged<T, TComparable> rewardEnumRanged)
        {
            return rewardEnumRanged.IsClaimable();
        }

        private TComparable MinFunc(TComparable value, TComparable lowerBound, TComparable upperBound)
        {
            return lowerBound;
        }

        private TComparable RandomFunc(TComparable value, TComparable lowerBound, TComparable upperBound)
        {
            if (typeof(TComparable) == typeof(int))
            {
                int minValue = Convert.ToInt32(lowerBound);
                int maxValue = Convert.ToInt32(upperBound);
                int randomValue = UnityEngine.Random.Range(minValue, maxValue + 1);
                return (TComparable)(object)randomValue;
            }

            if (typeof(TComparable) == typeof(float))
            {
                float minValue = Convert.ToSingle(lowerBound);
                float maxValue = Convert.ToSingle(upperBound);
                float randomValue = UnityEngine.Random.Range(minValue, maxValue);
                return (TComparable)(object)randomValue;
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

        private TComparable RandomOnCurveFunc(TComparable value, TComparable lowerBound, TComparable upperBound)
        {
            float randomTime = UnityEngine.Random.value;
            float mappedTime = Curve.Evaluate(randomTime);

            if (typeof(TComparable) == typeof(int))
            {
                int minValue = Convert.ToInt32(lowerBound);
                int maxValue = Convert.ToInt32(upperBound);
                int interpolatedValue = Mathf.RoundToInt(Mathf.Lerp(minValue, maxValue, mappedTime));
                return (TComparable)(object)interpolatedValue;
            }

            if (typeof(TComparable) == typeof(float))
            {
                float minValue = Convert.ToSingle(lowerBound);
                float maxValue = Convert.ToSingle(upperBound);
                float interpolatedValue = Mathf.Lerp(minValue, maxValue, mappedTime);
                return (TComparable)(object)interpolatedValue;
            }

            if (typeof(List<>) == typeof(TComparable))
            {
                List<TComparable> list = (List<TComparable>)(object)lowerBound;
                int index = Mathf.RoundToInt(Mathf.Lerp(0, list.Count - 1, mappedTime));
                return list[index];
            }

            if (mappedTime > 0.5) return upperBound;
            return lowerBound;
        }

        public override string ToString()
        {
            return $"{type} {ObjectCount} {Lower} {Upper} {RewardFunctionType}";
        }
    }
}