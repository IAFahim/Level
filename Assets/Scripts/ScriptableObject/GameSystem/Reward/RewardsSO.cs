using Class.GameSystem.Reward;
using Enum.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "MultipleRewards", menuName = "GameSystem/Rewards/Multiple", order = 1)]
    public class RewardsSO : UnityEngine.ScriptableObject
    {
        public Rewards<StatsType, int> rewards;

        [Button]
        public void Log(StatsType statsType)
        {
            Debug.Log(rewards.Get(statsType).GetReward());
        }
    }
}