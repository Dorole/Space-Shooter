using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] float _shakeDuration = 1f;
        [SerializeField] float _shakeMagnitude = 0.5f;
        
        Vector3 _initialPosition;
        Health _player;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        }

        private void Start()
        {
            _initialPosition = transform.position;
            _player.onObjectHit += PlayShakeCoroutine;
        }

        public void PlayShakeCoroutine()
        {
            StartCoroutine(CO_ShakeCamera());
        }

        IEnumerator CO_ShakeCamera()
        {
            float elapsedTime = 0;

            while (elapsedTime < _shakeDuration)
            {
                transform.position = _initialPosition + (Vector3)Random.insideUnitCircle * _shakeMagnitude;
                elapsedTime += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            transform.position = _initialPosition;
        }

        private void OnDisable()
        {
            _player.onObjectHit -= PlayShakeCoroutine;
        }
    }
}
