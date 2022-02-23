using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    public class PlayerMovement : MonoBehaviour
    {
        Vector2 _moveInput;
        [SerializeField] float _movementSpeed = 5.0f;

        Vector2 _minBounds;
        Vector2 _maxBounds;

        [SerializeField] float _paddingLeft, _paddingRight, _paddingTop, _paddingBottom;

        private void Start()
        {
            InitializeBounds();
        }

        void Update()
        {
            MovePlayer();
        }

        void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        void MovePlayer()
        {
            Vector2 delta = _moveInput * _movementSpeed * Time.deltaTime;

            //prevent player from leaving cam bounds
            Vector2 newPos = new Vector2();
            newPos.x = Mathf.Clamp(transform.position.x + delta.x, 
                _minBounds.x + _paddingLeft, 
                _maxBounds.x - _paddingRight);
            newPos.y = Mathf.Clamp(transform.position.y + delta.y, 
                _minBounds.y + _paddingBottom, 
                _maxBounds.y - _paddingTop);

            transform.position = newPos;
        }

        void InitializeBounds()
        {
            Camera mainCamera = Camera.main;
            _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        }
    }
}
