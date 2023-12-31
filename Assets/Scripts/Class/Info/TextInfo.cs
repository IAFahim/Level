﻿using System;
using UnityEngine;

namespace Class.Info
{
    [Serializable]
    public class TextInfo : ITextInfo
    {
        [SerializeField] protected string name;
        [SerializeField] [Multiline(3)] protected string description;
        
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