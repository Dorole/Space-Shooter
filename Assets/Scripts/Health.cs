using System;
using UnityEngine;

namespace SpaceShooter
{
    public class Health : MonoBehaviour
    {
        public event Action onObjectHit;
        public static event Action onEnemyKilled;
        public static event Action onPlayerDestroyed;

        [SerializeField] int _health = 50;
        public int PlayerHealth => _health;

        void OnTriggerEnter2D(Collider2D collision)
        {
            DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

            if (damageDealer == null)
                return;

            TakeDamage(damageDealer.Damage);
            onObjectHit?.Invoke();
            damageDealer.Hit();
        }

        void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
                Die();
        }

        void Die()
        {
            if (gameObject.CompareTag("Enemy"))
                onEnemyKilled?.Invoke();
            else
                onPlayerDestroyed?.Invoke();

            Destroy(gameObject);
        }
    }
}
