using Sirenix.OdinInspector;

namespace Krivodeling.WeaponSystem.Modifiers
{
    [HideReferenceObjectPicker]
    public abstract class WeaponModifier
    {
        public void Apply(in IWeaponDataReadOnly original, WeaponData modifiable)
        {
            OnApply(original, modifiable);
        }

        protected abstract void OnApply(in IWeaponDataReadOnly original, WeaponData modifiable);

        #region Editor
#if UNITY_EDITOR
        [ShowInInspector, PropertyOrder(-999), LabelText("Modifier"), GUIColor("#f7eae1")] private string EditorName
            => UnityEditor.ObjectNames.NicifyVariableName(GetType().Name.Replace("Modifier", ""));
#endif
        #endregion
    }
}
