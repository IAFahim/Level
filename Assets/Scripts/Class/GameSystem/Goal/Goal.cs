using System;
using Class.GameSystem.Satisfiable;
using TriInspector;

namespace Class.GameSystem.Goal
{
    [DeclareHorizontalGroup("vars")]
    [DeclareHorizontalGroup("time")]
    [Serializable]
    public class Goal<TO>
    {
        public VariableCondition<TO> condition;
        public Reward.Reward<float> reward;

    }
}