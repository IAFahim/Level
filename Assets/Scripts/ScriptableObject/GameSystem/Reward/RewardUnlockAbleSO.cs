using Class.GameSystem.Reward;
using Enum.GameSystem.Reward;
using TriInspector;
using UnityEngine;

namespace ScriptableObject.GameSystem.Reward
{
    [CreateAssetMenu(fileName = "RewardUnlockAble", menuName = "GameSystem/Rewards/Single/RewardUnlockAble", order = 1)]
    public class RewardUnlockAble : UnityEngine.ScriptableObject
    {
        public Reward<UnityEngine.ScriptableObject, UnityEngine.ScriptableObject> reward;

        [Button]
        public void Log()
        {
            if (reward.IsClaimable())
            {
                Debug.Log(reward.GenerateValueAndIncrementClaim());
            }
        }

        [Button]
        public void Calcuate()
        {
            reward.SetCustomRewardFunction(((min, max) => min));
            Log();
        }

        public void OnValidate()
        {
            if (reward.maxClaimCount < 1)
                reward.maxClaimCount = 1;
        }
    }
}