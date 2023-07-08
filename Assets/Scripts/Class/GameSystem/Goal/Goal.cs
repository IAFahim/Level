using System;

namespace Class.GameSystem.Goal
{
    [Serializable]
    public class Goal<T, V> where T : class where V : struct
    {
        public T entity;
        public V have;
        public V required;

        public Goal(T entity, V required)
        {
            this.entity = entity;
            this.required = required;
        }

        public void SetHave(V value)
        {
            have = value;
        }
        
        public void SetNeed(V value)
        {
            required = value;
        }
        
        public override string ToString()
        {
            return $"{{\"Entity\":\"{entity}\", \"Have\":\"{have}\", \"Required\":\"{required}\"}}";
        }
        
    }
}