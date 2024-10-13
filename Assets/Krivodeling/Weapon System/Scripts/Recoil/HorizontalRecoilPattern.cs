using Krivodeling.Extensions;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    [Serializable]
    public sealed class HorizontalRecoilPattern : IHorizontalRecoilPatternReadOnly
    {
        [field: SerializeField, SuffixLabel("@" + nameof(GetRecoilCurveSuffixLabel) + "()")] public AnimationCurve RecoilCurve { get; set; } = AnimationCurvePresets.EaseInOut(0f, 0f, 60f, 60f, preWrapMode: WrapMode.PingPong);
        [ShowInInspector, HideInEditorMode] public float RecoilMultiplier { get; set; } = 1f;
        public float MinRecoil => GetMinRecoil();
        public float MaxRecoil => GetMaxRecoil();
        [field: SerializeField, PropertyRange(0f, 1f)] public float StartMultiplierTime { get; set; } = 0.5f;
        [field: SerializeField, SuffixLabel("0 | 1")] public AnimationCurve MultiplierCurve { get; set; } = AnimationCurvePresets.EaseInOut();
        [field: SerializeField] public float MultiplierIncreasing { get; set; } = 0.8f;
        [field: SerializeField] public float MultiplierDecreasing { get; set; } = 1.3f;

        public HorizontalRecoilPattern DeepCopy()
        {
            HorizontalRecoilPattern pattern = new()
            {
                RecoilCurve = new(RecoilCurve.keys) { preWrapMode = RecoilCurve.preWrapMode },
                RecoilMultiplier = RecoilMultiplier,
                StartMultiplierTime = StartMultiplierTime,
                MultiplierCurve = new(MultiplierCurve.keys),
                MultiplierIncreasing = MultiplierIncreasing,
                MultiplierDecreasing = MultiplierDecreasing
            };

            return pattern;
        }

        private float GetMinRecoil()
        {
            float min = TimeAnimationCurveExtensions.GetMinTime(RecoilCurve); // OdinInspector's feature.

            if (min == 0f)
                min = -GetMaxRecoil();

            return min;
        }

        private float GetMaxRecoil()
        {
            return TimeAnimationCurveExtensions.GetMaxTime(RecoilCurve); // OdinInspector's feature.
        }

        #region Editor
        private string GetRecoilCurveSuffixLabel()
        {
            return $"{GetMinRecoil()} | {GetMaxRecoil()}";
        }
        #endregion
    }
}
