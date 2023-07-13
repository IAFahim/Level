using System.Collections.Generic;
using Class.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "EnumRewardsRanged", menuName = "SO/EnumReward/EnumRewardsRanged", order = 0)]
    public class EnumRewardsSo : UnityEngine.ScriptableObject
    {
        public RewardsEnumRanged<GameStats, float> _rewardsEnumRanged;

        [Button]
        public void Log()
        {
            if (_rewardsEnumRanged)
            {
                int length = _rewardsEnumRanged;
                _rewardsEnumRanged.GenerateValueAndIncrementClaim();
                for (int i = 0; i < length; i++)
                {
                    
                    Debug.Log(_rewardsEnumRanged.Get(i));
                }
            }
        }
    }
}