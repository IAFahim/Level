using UnityEngine;

namespace Class.GameSystem.Info
{
    public interface IUiInfo : ITextInfo
    {
        Sprite Icon { get; set; }
    }
}