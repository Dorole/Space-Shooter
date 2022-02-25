using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Shooter : MonoBehaviour
    {
        [HideInInspector] public bool isFiring;
        [Header("General")]
        [SerializeField] float _baseFiringRate = 0.5f;

        [Header("AI Options")]
        [SerializeField] bool _usesAI;
        [SerializeField] float _firingRateVariance = 0.5f;
        [SerializeField] float _minimumProjectileSpawnTime = 0.1f;

        Coroutine _firingCoroutine;

        private void Start()
        {
            if (_usesAI)
                isFiring = true;
        }

        void Update()
        {
            Fire();
        }

        void Fire()
        {
            if (isFiring && _firingCoroutine == null)
                _firingCoroutine = StartCoroutine(CO_FireContinuously());
            else if (!isFiring && _firingCoroutine != null)
            {
                StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
        }

        IEnumerator CO_FireContinuously()
        {
            while (true)
            {
                SpawnObjectIntoScene();

                if (_usesAI)
                    yield return new WaitForSeconds(RandomFiringRate());
                else
                    yield return new WaitForSeconds(_baseFiringRate);
            }
        }
        
        void SpawnObjectIntoScene()
        {
            GameObject projectile;

            if (_usesAI)
                projectile = Pool.instance.GetObjectFromPool("EnemyProjectile");
            else
                projectile = Pool.instance.GetObjectFromPool("PlayerProjectile");

            if (projectile != null)
            {
                projectile.transform.position = transform.position;
                projectile.transform.rotation = Quaternion.identity;
                projectile.SetActive(true);
            }

            AudioManager.instance.Play("Shoot");
        }

        float RandomFiringRate()
        {
            float timeToNextProjectile = Random.Range(_baseFiringRate - _firingRateVariance, _baseFiringRate + _firingRateVariance);
            return Mathf.Clamp(timeToNextProjectile, _minimumProjectileSpawnTime, float.MaxValue);
        }
    }
}
