using UnityEngine;

namespace SpaceShooter
{
    public class VisualEffects : MonoBehaviour
    {
        [SerializeField] ParticleSystem _explosionPrefab;
        Health _gameObject;

        void Start()
        {
            _gameObject = GetComponent<Health>();
            _gameObject.onObjectHit += PlayParticleEffect;
        }

        void PlayParticleEffect()
        {
            if (_explosionPrefab != null)
            {
                ParticleSystem effect = Instantiate(_explosionPrefab, transform.position, Quaternion.identity, _gameObject.transform);
                Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
            }
        }

        void OnDisable()
        {
            _gameObject.onObjectHit -= PlayParticleEffect;
        }
    }
}
