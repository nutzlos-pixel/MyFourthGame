using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    private float speedMovement = 4.0f;
    private float verticalInput;
    private float horizontalInput;
    void Start()
    {
        powerUpIndicator.SetActive(false);
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }
    void Update()
    {
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(focalPoint.transform.forward * speedMovement * verticalInput);
        playerRb.AddForce(Vector3.right * speedMovement * horizontalInput);

    }
    public void PowerUpAktiv()
    {
        powerUpIndicator.SetActive(true);
    }
}
