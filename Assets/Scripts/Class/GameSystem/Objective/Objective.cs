using System;
using Class.GameSystem.Currency;
using Class.GameSystem.Satisfiable;

namespace Class.GameSystem.Objective
{
    [Serializable]
    public class Objective<TO>
    {
        public VariableCondition<TO> condition;
        public Reward.Reward<AllCurrency> reward;
    }
}