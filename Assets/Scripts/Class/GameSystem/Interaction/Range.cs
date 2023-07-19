using System;
using Class.GameSystem.Reward;
using UnityEngine;

namespace Class.GameSystem.Interaction
{
    [Serializable]
    class Range<T, TComparable> : IRange<T, TComparable> where TComparable : struct, IComparable<TComparable>
    {
        protected RewardFunctionType RewardRewardFunctionType;
        protected TComparable lower;
        protected TComparable upper;
        protected Func<T, TComparable> customRewardFunction;
        
        public Range(TComparable lower, TComparable upper, Func<T, TComparable> customRewardFunction, AnimationCurve curve)
        {
            this.Lower = lower;
            this.Upper = upper;
            this.CustomRewardFunction = customRewardFunction;
            this.Curve = curve;
        }
        
        public void SetRange(TComparable lowerBound, TComparable upperBound)
        {
            Lower = lowerBound;
            Upper = upperBound;
        }

        public AnimationCurve Curve { get; set; }

        public RewardFunctionType RewardFunctionType
        {
            get => RewardRewardFunctionType;
            set => RewardRewardFunctionType = value;
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

        public Func<T, TComparable> CustomRewardFunction
        {
            get => customRewardFunction;
            set => customRewardFunction = value;
        }
    }
}