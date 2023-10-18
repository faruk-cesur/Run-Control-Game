using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GravityControl : MonoBehaviour
{
    public Rigidbody Rb;
    public float MinGravityMultiplier = 0.95f;
    private float _gravityMultiplier;

    private void OnEnable()
    {
        _gravityMultiplier = Random.Range(MinGravityMultiplier, 1f);
    }

    private void FixedUpdate()
    {
        if (Rb.velocity.y <= 0)
        {
            Vector3 gravity = _gravityMultiplier * Physics.gravity;
            Rb.AddForce(-gravity, ForceMode.Acceleration);
        }
    }
}