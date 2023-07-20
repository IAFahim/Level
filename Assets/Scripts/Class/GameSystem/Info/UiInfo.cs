using System;
using UnityEngine;

namespace Class.GameSystem.Info
{
    [Serializable]
    public class UiInfo : IUiInfo
    {
        [SerializeField] protected string name;
        [SerializeField] [Multiline(3)] protected string description;
        [SerializeField] protected Sprite icon;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public Sprite Icon
        {
            get => icon;
            set => icon = value;
        }
    }
}