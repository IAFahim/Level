using Class.GameSystem.GameStats;
using Class.GameSystem.Reward;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumReward", menuName = "GameSystem/Reward/EnumReward", order = 0)]
    public class EnumRewardSo : UnityEngine.ScriptableObject
    { 
        public RewardEnumRanged<GameStats, int> rewardList;

        private void OnValidate()
        {
            if (rewardList.MaxClaimCount == 0)
            {
                rewardList.MaxClaimCount = 1;
            }
        }
    }
}