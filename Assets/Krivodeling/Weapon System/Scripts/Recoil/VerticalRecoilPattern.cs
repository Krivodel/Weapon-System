using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    [Serializable]
    public sealed class VerticalRecoilPattern : IVerticalRecoilPatternReadOnly
    {
        [field: SerializeField] public float Recoil { get; set; } = 60f;
        [field: SerializeField, PropertyRange(0f, 1f)] public float StartMultiplier { get; set; } = 0.5f;
        [field: SerializeField] public float MultiplierIncreasing { get; set; } = 0.8f;
        [field: SerializeField] public float MultiplierDecreasing { get; set; } = 1.3f;

        public VerticalRecoilPattern DeepCopy()
        {
            VerticalRecoilPattern pattern = new()
            {
                Recoil = Recoil,
                StartMultiplier = StartMultiplier,
                MultiplierIncreasing = MultiplierIncreasing,
                MultiplierDecreasing = MultiplierDecreasing
            };

            return pattern;
        }
    }
}
