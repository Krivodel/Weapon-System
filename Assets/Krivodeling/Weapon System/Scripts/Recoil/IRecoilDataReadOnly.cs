using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public interface IRecoilDataReadOnly
    {
        float ShootingIntensity { get; }
        IVerticalRecoilPatternReadOnly VerticalPattern { get; }
        IHorizontalRecoilPatternReadOnly HorizontalPattern { get; }
        float ReturnDuration { get; }
        bool OverrideReturnCurve { get; }
        AnimationCurve ReturnCurve { get; }
    }
}
