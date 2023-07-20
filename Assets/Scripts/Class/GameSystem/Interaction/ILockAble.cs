using UnityEngine;

namespace Class.GameSystem.Interaction
{
    public interface ILockAble<T>
    {
        bool IsLocked { get; set; }
        bool IsEquipped { get; set; }
        T Price { get; set; }
        
    }
}