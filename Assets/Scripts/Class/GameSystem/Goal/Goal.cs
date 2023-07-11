using System;
using Class.GameSystem.Reward;
using UnityEngine.Serialization;

namespace Class.GameSystem.Goal
{
    [Serializable]
    public class Goal<T, V> where T : class where V : struct
    {
        public T type;
        public V have;
        public V requiredMin;
        public V requiredMax;

        public Goal(T type, V requiredMin)
        {
            this.type = type;
            this.requiredMin = requiredMin;
        }
        
        public Goal(T type, V requiredMin, V requiredMax)
        {
            this.type = type;
            this.requiredMin = requiredMin;
            this.requiredMax = requiredMax;
        }

        public void SetHave(V value)
        {
            have = value;
        }
        
        public void SetNeed(V value)
        {
            requiredMax = value;
        }

        public void CheckIfComplete()
        {
            if (have.Equals(requiredMax))
            {
                
            }
        }

        public override string ToString()
        {
            return $"{type} have {have} with required {requiredMin} to {requiredMax}";
        }
        
    }
}