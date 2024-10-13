using Krivodeling.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Krivodeling.WeaponSystem.Modifiers
{
    public sealed class VerticalRecoilModifier : WeaponModifier
    {
        [field: SerializeField] public ModifierMode Mode { get; private set; } = ModifierMode.Percentage;
        [field: SerializeField, MinValue(nameof(GetMinValue)), MaxValue(nameof(GetMaxValue))] public float Value { get; private set; } = -1f;

        protected override void OnApply(in IWeaponDataReadOnly original, WeaponData modifiable)
        {
            float change;

            if (Mode == ModifierMode.Percentage)
                change = original.Recoil.VerticalPattern.Recoil.TakePercent(Value);
            else
                change = Value;

            change *= Mathf.Sign(Value);

            modifiable.Recoil.VerticalPattern.Recoil += change;
        }

        private double GetMinValue()
        {
            if (Mode == ModifierMode.Percentage)
                return -100d;
            else
                return double.MinValue;
        }

        private double GetMaxValue()
        {
            if (Mode == ModifierMode.Percentage)
                return 100d;
            else
                return double.MaxValue;
        }
    }
}
