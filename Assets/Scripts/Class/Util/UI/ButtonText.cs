using System;
using Class.Attach;
using TMPro;
using TriInspector;
using UnityEngine.UI;

namespace Class.Util.UI
{
    [Serializable]
    public class ButtonText : IAttachable
    {
        public Button button;
        public TextMeshProUGUI textMeshProUGUI;

        [Button]
        public void TryToAttachFromRoot()
        {
            if (button != null)
                textMeshProUGUI = button.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}