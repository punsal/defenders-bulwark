using System;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    
    private void Update()
    {
        var rotDirection = Input.GetAxis(("Horizontal"));
        
        transform.Rotate(new Vector3(0f, 0f, -1f * rotDirection * rotationSpeed * Time.deltaTime));
        
    }
}
