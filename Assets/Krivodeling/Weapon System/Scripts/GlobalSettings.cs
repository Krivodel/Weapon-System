using Sirenix.OdinInspector;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    [CreateAssetMenu(menuName = Paths.Weapons + "Global Settings")]
    public sealed class GlobalSettings : ScriptableObject
    {
        [field: SerializeField] public Vector3 RecoilMultiplier { get; private set; } = new(0.0002f, 0.0004f, -0.02f);
        [field: SerializeField] public Vector3 RotationMultiplier { get; private set; } = new(100f, 100f, 20f);
        [field: SerializeField] public float ShootingIntensity { get; private set; } = 20f;
        [field: SerializeField, PropertyRange(0f, 100f)] public float VerticalRecoilPercentage { get; private set; } = 40f;
        [field: SerializeField] public float ReturnDurationMultiplier { get; private set; } = 1f;
        [field: SerializeField, SuffixLabel("0 | 1")] public AnimationCurve ReturnCurve { get; private set; } = AnimationCurvePresets.EaseInOut();
    }
}
