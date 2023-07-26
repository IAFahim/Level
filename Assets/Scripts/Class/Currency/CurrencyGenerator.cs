using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace Class.Currency
{
    [Serializable]
    public class CurrencyGenerator<T, TComparable> : CurrencyRange<T, TComparable>, ICurrencyGenerator<T, TComparable>
        where T : System.Enum where TComparable : struct, IComparable<TComparable>
    {
        [SerializeField] private RewardFunctionType rewardFunctionType;

        private Func<ICurrencyGenerator<T, TComparable>, TComparable> _rewardFunction;

        [SerializeField] private AnimationCurve curve;

        public CurrencyGenerator(T target, TComparable value) : base(target, value)
        {
        }

        public CurrencyGenerator(T type, TComparable lower, TComparable upper,
            Func<ICurrencyGenerator<T, TComparable>, TComparable> rewardFunction,
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


        public Func<ICurrencyGenerator<T, TComparable>, TComparable> CustomRewardFunction
        {
            get => _rewardFunction;
            set => _rewardFunction = value;
        }

        public void SetToCustomRewardFunction()
        {
            RewardFunctionType = RewardFunctionType.Custom;
        }

        public void SetToCustomRewardFunction(Func<ICurrencyGenerator<T, TComparable>, TComparable> function)
        {
            RewardFunctionType = RewardFunctionType.Custom;
            CustomRewardFunction = function;
        }

        [Button]
        public TComparable Generate()
        {
            return value = RewardFunctionType switch
            {
                RewardFunctionType.Min => MinFunc(value, lower, upper),
                RewardFunctionType.Random => RandomFunc(value, lower, upper),
                RewardFunctionType.RandomOnCurve => RandomOnCurveFunc(value, lower, upper),
                RewardFunctionType.Custom => CustomRewardFunction(this),
                _ => default
            };
        }

        public static implicit operator float(CurrencyGenerator<T, TComparable> currencyGenerator)
        {
            return Convert.ToSingle(currencyGenerator.value);
        }

        public static implicit operator int(CurrencyGenerator<T, TComparable> currencyGenerator)
        {
            return Convert.ToInt32(currencyGenerator.value);
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
            return $"{Target} {value} {Lower} {Upper} {RewardFunctionType}";
        }
    }
}