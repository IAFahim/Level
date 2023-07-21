using Class.GameSystem.GameCurrency;
using Class.GameSystem.Reward;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumRewardFull", menuName = "GameSystem/Reward/EnumRewardFull", order = 0)]
    public class EnumRewardFullSo : UnityEngine.ScriptableObject
    {
        public RewardFullEnumRanged<GameCurrency, float> rewardFullEnumRanged;

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