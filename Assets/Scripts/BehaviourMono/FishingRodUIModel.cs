using Class.Attach;
using Class.Util;
using Class.Util.Abilities;
using Class.Util.UI;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;

namespace BehaviourMono
{
    [DeclareTabGroup("Tab")]
    public class FishingRodUIModel : MonoBehaviour, IAttachable
    {
        [GroupNext("Tab"), Tab("UI")]
        public GameObject root;
        public GameItemEnum gameItemEnum;
        public Image background;
        [OnValueChanged(nameof(SetAskKey))] public GameObject prefab;
        public Component prefabSpawnObject;
        public AbilityUI[] ability;
        public Label label;
        public ButtonText equipButton;
        public ButtonText buyButton;
        [Group("Tab"), Tab("Data")] public FishingRodData data;

        public FishingRodData Data
        {
            get => data;
            set
            {
                // label.textMeshProUGUI.text = value.
            }
        }


        [Button]
        public void TryToAttachFromRoot()
        {
            label.TryToAttachFromRoot();
            equipButton.TryToAttachFromRoot();
            buyButton.TryToAttachFromRoot();
        }

        void SetAskKey()
        {
            Data.key = gameItemEnum + "#" + prefab.name;
        }
    }
}