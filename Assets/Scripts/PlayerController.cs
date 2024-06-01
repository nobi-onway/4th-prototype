using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private float FORCE = 10.0f;
    [SerializeField]
    private GameObject _focalPoint;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ForceToMove();
    }

    private void ForceToMove()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _rb.AddForce(_focalPoint.transform.forward * FORCE * verticalInput);
    }
}
