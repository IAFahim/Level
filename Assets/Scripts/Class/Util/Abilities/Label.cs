using System;
using Class.Attach;
using TMPro;
using TriInspector;
using UnityEngine;

namespace Class.Util.Abilities
{
    [Serializable]
    public class Label: IAttachable
    {
        public Component root;
        public TextMeshProUGUI textMeshProUGUI;
        
        [Button]
        public void TryToAttachFromRoot()
        {
            textMeshProUGUI = root.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}