using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float speedRotation = 10f;
    private float horizontalInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * speedRotation);
    }
}
