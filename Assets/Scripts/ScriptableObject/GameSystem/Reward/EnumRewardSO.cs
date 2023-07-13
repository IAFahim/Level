using System;
using Class.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumRewardRanged", menuName = "SO/EnumReward/EnumRewardRanged", order = 0)]
    public class EnumRewardSo : UnityEngine.ScriptableObject
    {
        public RewardEnumRanged<GameStats, int> _rewardEnumRanged;

        [Button]
        private void Log()
        {
            if (_rewardEnumRanged)
            {
                var x = _rewardEnumRanged.GenerateValueAndIncrementClaim();
                Debug.Log(x);
            }
        }

        private void OnValidate()
        {
            if (_rewardEnumRanged.maxClaimCount == 0)
            {
                _rewardEnumRanged.maxClaimCount = 1;
            }
        }
    }
}