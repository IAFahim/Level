using Class.GameSystem.Reward;
using Enum.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "MultipleRewards", menuName = "GameSystem/Rewards/Multiple", order = 1)]
    public class RewardsSO : UnityEngine.ScriptableObject
    {
        public Rewards<RewardType, int> rewards;

        [Button]
        public void Log(RewardType rewardType)
        {
            Debug.Log(rewards.Get(rewardType).ToString());
        }
    }
}