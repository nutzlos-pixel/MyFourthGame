using UnityEngine;
using System.Collections;

public class PickUpPowerUp : MonoBehaviour
{
    private bool hasPowerUp = false;
    private bool powerUpActivated = false;
    private float powerUpStrength = 10.0f;
    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            Debug.Log("Power Up Collected!");
        }
    }
    private void Update()
    {
        if (hasPowerUp && Input.GetKeyDown(KeyCode.Space))
        {
            powerUpActivated = true;
            playerController.PowerUpAktiv();
            Debug.Log("Power Up Activated!");
            StartCoroutine(PowerUpCountdown());
        }
    }
    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(4);
        hasPowerUp = false;
        powerUpActivated = false;
        playerController.powerUpIndicator.SetActive(false);
        Debug.Log("Power Up Expired!");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerUp && collision.gameObject.CompareTag("Enemy") && powerUpActivated)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer.normalized * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Enemy Knocked Back!");
        }
    }
}
