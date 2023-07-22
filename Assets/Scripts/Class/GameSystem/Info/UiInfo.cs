using System;
using UnityEngine;

namespace Class.GameSystem.Info
{
    [Serializable]
    public class UiInfo : TextInfo
    {
        [SerializeField] protected Sprite icon;

        public Sprite Icon
        {
            get => icon;
            set => icon = value;
        }
    }
}