using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public interface IHorizontalRecoilPatternReadOnly
    {
        AnimationCurve RecoilCurve { get; }
        float RecoilMultiplier { get; }
        float MinRecoil { get; }
        float MaxRecoil { get; }
        float StartMultiplierTime { get; }
        AnimationCurve MultiplierCurve { get; }
        float MultiplierIncreasing { get; }
        float MultiplierDecreasing { get; }
    }
}
