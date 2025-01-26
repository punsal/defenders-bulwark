using System;
using Abstract;
using UnityEngine;

namespace Shooting
{
    public class TurretController : AGameBehaviour
    {
        [SerializeField] private RotateSpeed data;
        [SerializeField] private float initialSpeed;
        private bool _inputReceived;

        private void Start()
        {
            data.Initialize(initialSpeed);
        }

        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                _inputReceived = true;
            }
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _inputReceived = true;
            }
            
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                _inputReceived = false;
            }

            if (!_inputReceived)
            {
                return;
            }
            
            var rotDirection = Input.GetAxis("Horizontal");
        
            transform.Rotate(new Vector3(0f, 0f, -1f * rotDirection * data.RotationSpeed * Time.deltaTime));
        }
    }
}
