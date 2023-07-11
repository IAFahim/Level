﻿using Class.GameSystem.Reward;
using Enum.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumReward", menuName = "GameSystem/Rewards/Single/EnumReward", order = 1)]
    public class RewardSO : UnityEngine.ScriptableObject
    {
        public Reward<StatsType, int> reward;

        [Button]
        public void Log()
        {
            Debug.Log(reward.GenerateValueAndIncrementClaim());
        }

        [Button]
        public void Calcuate()
        {
            reward.SetCustomRewardFunction(((min, max) => min));
            Log();
        }

        public void OnValidate()
        {
            if (reward.maxClaimCount < 1)
                reward.maxClaimCount = 1;
        }
    }
}