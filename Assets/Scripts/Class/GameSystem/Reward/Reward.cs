using System;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("type")]
    [DeclareHorizontalGroup("vars")]
    [Serializable]
    public class Reward<T, V> where V : struct
    {
        [Group("type")] public T stats;

        [FormerlySerializedAs("type")] [Group("type")]
        public RewardType rewardType;

        [Group("type")] public bool reclaimable;

        [Group("vars")] public V value;
        [Group("vars")] public V min;
        [Group("vars")] public V max;

        public Func<V, V, V> rewardFunction;
        [FormerlySerializedAs("curve")] public AnimationCurve animationCurve;

        public Reward(T stats, V value, bool reclaimable)
        {
            this.stats = stats;
            this.reclaimable = reclaimable;
            this.value = value;
            rewardType = RewardType.Min;
        }

        public Reward(T stats, V min, V max, bool reclaimable, RewardType rewardType)
        {
            this.stats = stats;
            this.rewardType = rewardType;
            this.reclaimable = reclaimable;
            this.min = min;
            this.max = max;
        }


        public Reward(T stats, V min, V max, bool reclaimable, AnimationCurve animationCurve)
        {
            this.stats = stats;
            this.reclaimable = reclaimable;
            this.min = min;
            this.max = max;
            this.animationCurve = animationCurve;
            rewardType = RewardType.RandomOnCurve;
        }

        public Reward(T stats, V min, V max, bool reclaimable, Func<V, V, V> rewardFunction,
            AnimationCurve animationCurve)
        {
            this.stats = stats;
            this.reclaimable = reclaimable;
            this.min = min;
            this.max = max;
            rewardType = RewardType.Custom;
            this.rewardFunction = rewardFunction;
            this.animationCurve = animationCurve;
        }

        public void SetRewardType(RewardType rewardType)
        {
            this.rewardType = rewardType;
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
            else if (rewardType == RewardType.Custom)
            {
                rewardFunction = rewardFunction;
            }
        }


        public V GetReward()
        {
            SetRewardType(rewardType);
            value =rewardFunction(min, max);
            return value;
        }

        public void SetCustomRewardFunction(Func<V, V, V> rewardFunction)
        {
            rewardType = RewardType.Custom;
            this.rewardFunction = rewardFunction;
        }


        public override string ToString()
        {
            return $"{{\"Type\":\"{rewardType}\", \"Value\":\"{value}\"}}";
        }

        public static V NoneFunc(V min, V max)
        {
            return min;
        }

        public V RandomFunc(V min, V max)
        {
            //Check if min max same with torlerance
            if (min is int)
            {
                return (V)(object)UnityEngine.Random.Range((int)(object)min, (int)(object)max);
            }

            if (min is float)
            {
                return (V)(object)UnityEngine.Random.Range((float)(object)min, (float)(object)max);
            }

            return min;
        }

        public V RandomOnCurveFunc(V min, V max)
        {
            float randomTime = UnityEngine.Random.value;
            float mappedTime = animationCurve.Evaluate(randomTime);

            if (min is int)
            {
                int minValue = (int)(object)min;
                int maxValue = (int)(object)max;
                int interpolatedValue = Mathf.RoundToInt(Mathf.Lerp(minValue, maxValue, mappedTime));
                return (V)(object)interpolatedValue;
            }

            if (min is float)
            {
                float minValue = (float)(object)min;
                float maxValue = (float)(object)max;
                float interpolatedValue = Mathf.Lerp(minValue, maxValue, mappedTime);
                return (V)(object)interpolatedValue;
            }

            return min;
        }
    }
}