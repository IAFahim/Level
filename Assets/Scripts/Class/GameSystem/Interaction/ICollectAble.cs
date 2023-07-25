using Class.GameSystem.Info;
using Class.GameSystem.Satisfiable;
using TextInfo = Class.GameSystem.Info.TextInfo;

namespace Class.GameSystem.Interaction
{
    public interface ICollectAble<T>
    {
        public T Target { get; set; }
        TextInfo TextInfo { get; set; }
        VariableCondition<T> ItemCount { get; set; }
        void Collect();
    }
}