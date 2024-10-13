using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    [Serializable]
    public sealed class RecoilData : IRecoilDataReadOnly
    {
        [field: SerializeField] public float ShootingIntensity { get; set; } = 1f;
        [field: SerializeField] public VerticalRecoilPattern VerticalPattern { get; set; }
        [field: SerializeField] public HorizontalRecoilPattern HorizontalPattern { get; set; }
        [field: SerializeField] public float ReturnDuration { get; set; } = 0.4f;
        [field: SerializeField] public bool OverrideReturnCurve { get; set; } = false;
        [field: SerializeField, ShowIf(nameof(OverrideReturnCurve)), SuffixLabel("0 | 1")] public AnimationCurve ReturnCurve { get; set; } = AnimationCurvePresets.EaseInOut();

        IVerticalRecoilPatternReadOnly IRecoilDataReadOnly.VerticalPattern => VerticalPattern;
        IHorizontalRecoilPatternReadOnly IRecoilDataReadOnly.HorizontalPattern => HorizontalPattern;

        public RecoilData DeepCopy()
        {
            RecoilData recoilData = new()
            {
                ShootingIntensity = ShootingIntensity,
                VerticalPattern = VerticalPattern.DeepCopy(),
                HorizontalPattern = HorizontalPattern.DeepCopy(),
                ReturnDuration = ReturnDuration,
                OverrideReturnCurve = OverrideReturnCurve,
                ReturnCurve = new(ReturnCurve.keys)
            };

            return recoilData;
        }
    }
}
