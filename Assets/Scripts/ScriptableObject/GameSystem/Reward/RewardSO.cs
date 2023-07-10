﻿using Class.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "SingleReward", menuName = "GameSystem/Rewards/Single", order = 1)]
    public class RewardSO : UnityEngine.ScriptableObject
    {
        public Reward<RewardType, int> reward;

        [Button]
        public void Log()
        {
            Debug.Log(reward.GetReward());
        }

        [Button]
        public void Calcuate()
        {
            reward.SetCustomRewardFunction(((min, max) => min));
            Log();
        }
    }
}