using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace Class.GameSystem.Reward
{
    [DeclareHorizontalGroup("type")]
    [DeclareHorizontalGroup("vars")]
    [DeclareHorizontalGroup("condition")]
    [Serializable]
    public class RewardUnlockAbleList<T> : IRewardUnlockAbleList<T>
    {
        public List<T> unlockAbles;
        [Group("type")] public RewardType funcType;
        public Func<T, T> rewardFunction;
        public T oldValue;
        public AnimationCurve animationCurve;
        public int claimCount;
        public int maxClaimCount = 1;

        public RewardUnlockAbleList(List<T> unlockAbles)
        {
            this.unlockAbles = unlockAbles;
        }

        public RewardUnlockAbleList(List<T> unlockAbles, AnimationCurve animationCurve)
        {
            this.unlockAbles = unlockAbles;
            this.animationCurve = animationCurve;
        }

        public RewardUnlockAbleList(List<T> unlockAbles, AnimationCurve animationCurve, int maxClaimCount)
        {
            this.unlockAbles = unlockAbles;
            this.animationCurve = animationCurve;
            this.maxClaimCount = maxClaimCount;
        }


        public T GetOldReward()
        {
            return this.oldValue;
        }
        
        private T GenerateNewReward()
        {
            SetRewardType(funcType);
            oldValue = rewardFunction(oldValue);
            return oldValue;
        }

        private void SetRewardType(RewardType rewardType)
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

        private T RandomFunc(T value)
        {
            return unlockAbles[UnityEngine.Random.Range(0, unlockAbles.Count)];
        }
        
        private T RandomOnCurveFunc(T value)
        {
            return unlockAbles[Mathf.FloorToInt(animationCurve.Evaluate(UnityEngine.Random.value) * unlockAbles.Count)];
        }
        
        private T NoneFunc(T value)
        {
            return value;
        }

        public T GenerateValueAndIncrementClaim(bool increment = true)
        {
            if(increment) IncrementClaimCount();
            return GenerateNewReward();
        }
        

        public void SetReward(T value)
        {
            this.oldValue = value;
        }

        public int GetClaimCount()
        {
            return this.claimCount;
        }

        public void SetClaimCount(int count)
        {
            this.claimCount = count;
        }

        public int GetMaxClaimCount()
        {
            return this.maxClaimCount;
        }

        public void SetMaxClaimCount(int count)
        {
            this.maxClaimCount = count;
        }

        public AnimationCurve GetAnimationCurve()
        {
            return this.animationCurve;
        }

        public void SetAnimationCurve(AnimationCurve curve)
        {
            this.animationCurve = curve;
        }

        public void Reset()
        {
            claimCount = 0;
        }

        public void IncrementClaimCount()
        {
            if (claimCount < maxClaimCount) claimCount++;
        }

        public bool IsClaimable()
        {
            return claimCount < maxClaimCount;
        }
    }
}