namespace Krivodeling.WeaponSystem
{
    public interface IWeaponDataReadOnly
    {
        int ShotsPerMinute { get; }
        IRecoilDataReadOnly Recoil { get; }
        IAudioDataReadOnly Audio { get; }
    }
}
