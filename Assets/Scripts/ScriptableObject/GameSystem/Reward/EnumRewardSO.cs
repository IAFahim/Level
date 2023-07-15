using Class.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumRewardRanged", menuName = "SO/EnumReward/EnumRewardRanged", order = 0)]
    public class EnumRewardSo : UnityEngine.ScriptableObject
    { 
        public RewardEnumRanged<GameStats, int> rewardList;

        [Button]
        private void Log()
        {
            if (rewardList)
            {
                var x = rewardList.GetGeneratedValueAndIncrementClaim();
                Debug.Log(x);
            }
        }

        private void OnValidate()
        {
            if (rewardList.MaxClaimCount == 0)
            {
                rewardList.MaxClaimCount = 1;
            }
        }
        
    }
}