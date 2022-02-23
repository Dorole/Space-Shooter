using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    public class PlayerShoot : MonoBehaviour
    {
        Shooter _shooter;

        void Awake()
        {
            _shooter = GetComponent<Shooter>();
        }

        void OnFire(InputValue value)
        {
            if (_shooter != null)
                _shooter.isFiring = value.isPressed;
        }
    }
}