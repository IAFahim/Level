using System;
using TriInspector;
using UnityEngine;

namespace Class.GameSystem.Info
{
    [Serializable]
    public class TextInfo : ITextInfo
    {
        [SerializeField][DisableInEditMode]  protected string key;
        [SerializeField]  protected string name;
        [SerializeField] [Multiline(3)] protected string description;


        public string Key => key;

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
    }
}