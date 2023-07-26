using System;
using Class.Currency;
using Class.Reward;
using Class.Satisfiable;

namespace Class.Objective
{
    [Serializable]
    public class Objective<TO>
    {
        public VariableCondition<TO> condition;
        public Reward<AllCurrency> reward;
    }
}