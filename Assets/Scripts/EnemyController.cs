using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public event Action onDeath;
    private void Update()
    {
        DestroyOnFallingDown();
    }
    private void DestroyOnFallingDown()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
            onDeath?.Invoke();
        }
    }
}
