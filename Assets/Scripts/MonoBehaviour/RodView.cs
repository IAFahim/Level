using Class.GameSystem.Item;
using ScriptableObject.GameSystem.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviour
{
    public class RodView : UnityEngine.MonoBehaviour
    {
        public ItemCollectionSo itemCollectionSo;
        public Image rodIcon;
        public TextMeshProUGUI textMeshPro;

        private void Start()
        {
            OnItemChanged(itemCollectionSo.SelectedItem);
        }

        private void OnEnable()
        {
            itemCollectionSo.onItemChanged.AddListener(OnItemChanged);
        }

        private void OnDisable()
        {
            itemCollectionSo.onItemChanged.RemoveListener(OnItemChanged);
        }

        private void OnItemChanged(Item<ItemClassEnum, GameObject> item)
        {
            textMeshPro.text = item.uiInfo.Name;
            rodIcon.sprite = item.uiInfo.Icon;
        }
    }
}