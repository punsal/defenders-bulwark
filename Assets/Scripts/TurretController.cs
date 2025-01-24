using System;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    
    private float _targetAngle = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _targetAngle = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _targetAngle = 90f;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _targetAngle = 180f;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _targetAngle = 270f;
        }
        
        float currentAngle = Mathf.LerpAngle(transform.eulerAngles.z, _targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        
    }
}
