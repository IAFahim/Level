using Class.GameSystem.Currency;
using Class.GameSystem.Item;
using ScriptableObject.GameSystem.Selection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviour
{
    public class RodView : UnityEngine.MonoBehaviour
    {
        public UniqueSelectionSo levelSelection;
        public Image rodIcon;
        public TextMeshProUGUI textMeshPro;

        private void Start()
        {
            OnItemChanged(levelSelection.data.Current);
        }

        private void OnEnable()
        {
            levelSelection.data.onCurrentChanged.AddListener(OnItemChanged);
        }

        private void OnDisable()
        {
            levelSelection.data.onCurrentChanged.RemoveListener(OnItemChanged);
        }

        private void OnItemChanged(Item<GameCurrencyEnum, GameObject> item)
        {
            textMeshPro.text = item.uiInfo.Name;
            rodIcon.sprite = item.uiInfo.Icon;
        }
        
        
    }
}