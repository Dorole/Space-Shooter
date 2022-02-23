using UnityEngine;

// check composition vs inheritance on youtube and udemy!
namespace SpaceShooter
{
    public class PlayerProjectile : MonoBehaviour, IProjectile
    {
        [SerializeField] float _projectileSpeed = 10f;
        Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Move();
        }

        public void Move()
        {
            _rb.velocity = transform.up * _projectileSpeed;
        }
    }
}
