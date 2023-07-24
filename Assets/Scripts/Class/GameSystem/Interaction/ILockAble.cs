using UnityEngine;

namespace Class.GameSystem.Interaction
{
    public interface ILockAble<T>
    {
        T Price { get; set; }
        bool IsLocked { get; set; }
        
    }
}