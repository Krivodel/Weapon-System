using System.Collections.Generic;

namespace Krivodeling.WeaponSystem.Modifiers
{
    public sealed class WeaponModifiersController
    {
        public IWeaponDataReadOnly SourceWeapon { get; }
        public WeaponData ModifiableWeapon { get; private set; }
        public IReadOnlyList<WeaponModifier> Modifiers => _modifiers;

        private readonly WeaponData _sourceWeapon;
        private readonly List<WeaponModifier> _modifiers = new();

        public WeaponModifiersController(WeaponData sourceWeapon)
        {
            _sourceWeapon = sourceWeapon;
            SourceWeapon = _sourceWeapon;
            ModifiableWeapon = sourceWeapon.DeepCopy();
        }

        public void AddModifier(WeaponModifier modifier)
        {
            _modifiers.Add(modifier);

            Refresh();
        }

        public void AddModifiers(params WeaponModifier[] modifiers)
        {
            _modifiers.AddRange(modifiers);

            Refresh();
        }

        public void RemoveModifier(WeaponModifier modifier)
        {
            _modifiers.Remove(modifier);

            Refresh();
        }

        public void RemoveModifiers(params WeaponModifier[] modifiers)
        {
            for (int i = 0; i < modifiers.Length; i++)
                _modifiers.Remove(modifiers[i]);

            Refresh();
        }

        public void RemoveAllModifiers()
        {
            _modifiers.Clear();

            Refresh();
        }

        public void Refresh()
        {
            ModifiableWeapon = _sourceWeapon.DeepCopy();

            for (int i = 0; i < _modifiers.Count; i++)
                _modifiers[i].Apply(SourceWeapon, ModifiableWeapon);
        }
    }
}
