using Krivodeling.WeaponSystem.Modifiers;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public sealed class WeaponShooting : MonoBehaviour, IWeaponShooting
    {
        [field: SerializeField] public GlobalSettings GlobalSettings { get; private set; } // Note: It is better to use DI here.

        public IWeaponDataReadOnly OriginalWeapon => _sourceWeapon;
        [ShowInInspector, InlineEditor, HideInEditorMode] public IWeaponDataReadOnly ModifiableWeapon { get => ModifiersController?.ModifiableWeapon; private set { } }
        public WeaponModifiersController ModifiersController { get; private set; }
        public bool IsShooting { get; private set; }

        public event Action ShootStarted;
        public event Action ShootFinished;
        public event Action Shoted;

        [SerializeField, InlineEditor, HideInPlayMode] private WeaponData _sourceWeapon;

        private float _lastShootTime;

        private void Awake()
        {
            ModifiersController = new(_sourceWeapon);
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
                TryShoot();
            else if (Input.GetMouseButtonUp(0))
                FinishShoot();
        }

        private void TryShoot()
        {
            if (CanShoot())
            {
                if (!IsShooting)
                {
                    IsShooting = true;

                    ShootStarted?.Invoke();
                }

                DoShot();

                _lastShootTime = Time.time;
            }
        }

        private void FinishShoot()
        {
            if (IsShooting)
            {
                IsShooting = false;

                ShootFinished?.Invoke();
            }
        }

        private bool CanShoot()
        {
            float shootRate = 1f / (ModifiableWeapon.ShotsPerMinute / 60f);

            return Time.time - _lastShootTime >= shootRate;
        }

        private void DoShot()
        {
            Shoted?.Invoke();
        }
    }
}
