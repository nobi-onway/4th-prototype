using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private const float ROTATE_SPEED = 20.0f;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.down * horizontalInput * ROTATE_SPEED * Time.deltaTime);
    }
}
