using Class.Util;
using Class.Util.Abilities;
using Class.Util.UI;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;

namespace BehaviourMono
{
    public class FishingRodUIModel : MonoBehaviour
    {
        public GameItemEnum gameItemEnum;
        public FishingRodUIModelBase data;
        public Ability[] ability;
        [OnValueChanged(nameof(SetAskKey))] public GameObject prefab;
        public string text;
        public Button equipButton;
        public Button buyButton;

        void SetAskKey()
        {
            data.key = gameItemEnum + "#" + prefab.name;
        }
    }
}