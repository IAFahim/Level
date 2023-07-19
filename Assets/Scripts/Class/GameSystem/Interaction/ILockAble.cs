using UnityEngine;

namespace Class.GameSystem.Interaction
{
    public interface ILockAble<T>
    {
        bool IsLocked { get; set; }
        Sprite Icon { get; set; }
        bool IsCurrent { get; set; }
        T Price { get; set; }
        
    }
}