using Class.Satisfiable;
using TextInfo = Class.Info.TextInfo;

namespace Class.Interaction
{
    public interface ICollectAble<T>
    {
        public T Target { get; set; }
        TextInfo TextInfo { get; set; }
        VariableCondition<T> ItemCount { get; set; }
        void Collect();
    }
}