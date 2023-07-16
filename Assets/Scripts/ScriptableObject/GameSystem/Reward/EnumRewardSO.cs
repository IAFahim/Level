using Class.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumReward", menuName = "GameSystem/Reward/EnumReward", order = 0)]
    public class EnumRewardSo : UnityEngine.ScriptableObject
    { 
        public RewardEnumRanged<GameStats, int> rewardList;

        [Button]
        private void Log()
        {
            Debug.Log(rewardList.ToString());
        }

        private void OnValidate()
        {
            if (rewardList.MaxClaimCount == 0)
            {
                rewardList.MaxClaimCount = 1;
            }
        }

        [Button]
        public void Save()
        {
            rewardList.Save();
        }
        
        [Button]
        public void Load()
        {
            rewardList.Load();
        }
    }
}