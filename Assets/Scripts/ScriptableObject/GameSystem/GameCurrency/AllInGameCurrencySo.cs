using Class.GameSystem.Currency;
using TriInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObject.GameSystem.GameCurrency
{
    [CreateAssetMenu(fileName = "AllInGameCurrency", menuName = "GameSystem/Currency/AllInGameCurrency", order = 0)]
    public class AllInGameCurrencySo:UnityEngine.ScriptableObject
    {
        public Currency<GameCurrencyEnum, float> currency;
        public CurrencyGenerator<GameCurrencyEnum, float> currencyGenerator;
        
        [Button]
        public void Log()
        {
            Debug.Log(currencyGenerator.Generate());
        }
        
        private void OnValidate()
        {
            currency.SetTargetAsKey();
        }
    }
}