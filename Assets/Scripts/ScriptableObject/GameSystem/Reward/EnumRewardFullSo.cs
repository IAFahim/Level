using Class.GameSystem.Reward;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumRewardsRanged", menuName = "SO/EnumReward/EnumRewardsRanged", order = 0)]
    public class EnumRewardFullSo : UnityEngine.ScriptableObject
    {
        [FormerlySerializedAs("rewardsEnumRanged")] public RewardFullEnumRanged<GameStats, float> rewardFullEnumRanged;

        [Button]
        public void Log()
        {
            if (rewardFullEnumRanged)
            {
                int length = rewardFullEnumRanged;
                rewardFullEnumRanged.GenerateValueAndIncrementClaim();
                for (int i = 0; i < length; i++)
                {
                    Debug.Log(rewardFullEnumRanged.Get(i));
                }
            }
        }
    }
}