using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] int _damage = 10;

        public int Damage => _damage;

        public void Hit()
        {
            gameObject.SetActive(false);
        }
    }
}
