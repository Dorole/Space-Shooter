using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class SpriteScroller : MonoBehaviour
    {
        [SerializeField] Vector2 _scrollSpeed;

        Material _material;
        Vector2 _offset;

        private void Awake()
        {
            _material = GetComponent<SpriteRenderer>().material;
        }

        private void Update()
        {
            Scroll();
        }

        void Scroll()
        {
            _offset = _scrollSpeed * Time.deltaTime;
            _material.mainTextureOffset += _offset;
        }
    }
}
