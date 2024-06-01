using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private const float POWER_UP_FORCE = 10.0f;
    private const float POWER_UP_REMAINING_TIME = 5.0f;
    private bool _hasPowerUp;
    [SerializeField]
    private GameObject _powerUpIndicator;

    private void Update()
    {
        if (!_hasPowerUp) return;
        _powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            EnablePowerUp(true);
            StartCoroutine(CountDownPowerUp());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasPowerUp) return;

        Rigidbody collisionRb = collision.gameObject.GetComponent<Rigidbody>();
        if (!collisionRb) return;

        Vector3 forceDirection = (collision.transform.position - transform.position).normalized;
        collisionRb.AddForce(forceDirection * POWER_UP_FORCE, ForceMode.Impulse);
    }

    private void EnablePowerUp(bool enabled)
    {
        _hasPowerUp = enabled;
        _powerUpIndicator.gameObject.SetActive(enabled);
    }

    private IEnumerator CountDownPowerUp()
    {
        yield return new WaitForSeconds(POWER_UP_REMAINING_TIME);
        EnablePowerUp(false);
    }
}
