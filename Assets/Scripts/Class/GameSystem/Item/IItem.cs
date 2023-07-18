using Class.GameSystem.Equip;
using Class.GameSystem.SaveAble;
using UnityEngine;

namespace Class.GameSystem.Item
{
    public interface IItem<TObject> : ISaveAble
    {
        string Name { get; set; }
        TObject ItemObject { get; set; }
        EquipLimitation EquipLimitation { get; set; }
        void SetItemObjectNameAsKey();
        bool IsUnlocked { get; set; }
        bool IsEquipped { get; set; }
        float Price { get; set; }
        Sprite ItemSprite { get; set; }
    }
}