using Class.Currency;
using Class.GameSystem.Item;
using Class.Selection;
using UnityEngine;

namespace ObjectScriptable.Selection
{
    [CreateAssetMenu(fileName = "UniqueSelection", menuName = "GameSystem/Item/UniqueSelection", order = 0)]
    public class UniqueSelectionSo : UnityEngine.ScriptableObject
    {
        public UniqueSelection<Item<GameCurrencyEnum, GameObject>> data;
    }
}