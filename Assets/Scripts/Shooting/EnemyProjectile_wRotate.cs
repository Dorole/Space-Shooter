using UnityEngine;

namespace SpaceShooter
{
    public class EnemyProjectile_wRotate : MonoBehaviour, IProjectile
    {
        [SerializeField] float _projectileSpeed = 10f;
        PlayerMovement _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerMovement>();

            if (_player == null)
                return;
        }

        private void Start()
        {
            if (_player != null)
                Rotate();
        }

        public void Move()
        {
            transform.Translate(new Vector3(0, _projectileSpeed, 0) * Time.deltaTime * -1);
        }

        private void Rotate()
        {
            Vector3 playerPos = _player.transform.position;
            Vector2 diff = transform.position - playerPos;
            Vector3 rotationDegree = new Vector3(0, 0, 360 - Mathf.Rad2Deg * Mathf.Atan(diff.x / diff.y));
            transform.Rotate(rotationDegree);
        }
    }
}