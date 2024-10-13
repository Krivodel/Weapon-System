namespace Krivodeling.WeaponSystem
{
    public interface IVerticalRecoilPatternReadOnly
    {
        float Recoil { get; }
        float StartMultiplier { get; }
        float MultiplierIncreasing { get; }
        float MultiplierDecreasing { get; }
    }
}
