using Krivodeling.WeaponSystem.Modifiers;
using System;

namespace Krivodeling.WeaponSystem
{
    public interface IWeaponShooting
    {
        GlobalSettings GlobalSettings { get; } // Note: It is better to use DI here.
        IWeaponDataReadOnly OriginalWeapon { get; }
        IWeaponDataReadOnly ModifiableWeapon { get; }
        WeaponModifiersController ModifiersController { get; }
        bool IsShooting { get; }

        event Action ShootStarted;
        event Action ShootFinished;
        event Action Shoted;
    }
}
