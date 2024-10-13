using Krivodeling.WeaponSystem.Modifiers;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Krivodeling.WeaponSystem.Modifiers
{
    [CreateAssetMenu(menuName = Paths.Weapons + "Module")]
    public sealed class WeaponModuleData : SerializedScriptableObject
    {
        [field: SerializeField] public WeaponModifier[] Modifiers { get; private set; } = new WeaponModifier[0];
    }
}
