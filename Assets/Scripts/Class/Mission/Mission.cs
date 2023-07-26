using Class.Objective;
using UnityEngine;

namespace Class.Mission
{
    public class Mission
    {
        public Objective<GameObject> MainObjective;
        public Objective<GameObject> OptionalObjective;
        public bool IsComplete => MainObjective.condition.CheckIf() && OptionalObjective.condition.CheckIf();
        
    }
}