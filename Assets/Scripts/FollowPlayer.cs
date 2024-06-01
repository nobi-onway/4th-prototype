using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject _player;
    private const float CHASING_FORCE = 2.5f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        ChasingPlayer();
    }

    private void ChasingPlayer()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;

        _rb.AddForce(direction * CHASING_FORCE);
    }
}
