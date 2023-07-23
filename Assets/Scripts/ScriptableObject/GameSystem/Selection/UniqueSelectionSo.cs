using Class.GameSystem.Currency;
using Class.GameSystem.Item;
using Class.GameSystem.Selection;
using UnityEngine;

namespace ScriptableObject.GameSystem.Selection
{
    [CreateAssetMenu(fileName = "UniqueSelection", menuName = "GameSystem/Item/UniqueSelection", order = 0)]
    public class UniqueSelectionSo : UnityEngine.ScriptableObject
    {
        public UniqueSelection<Item<GameCurrencyEnum, GameObject>> data;
    }
}