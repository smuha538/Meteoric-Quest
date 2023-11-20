using UnityEngine;

public class LayerTransition : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 targetPosition; // The position where the camera should shift

    public float smoothSpeed = 2.0f; // The speed at which the camera follows the player

    private bool shouldShiftCamera = false;

    void Update()
    {
        // Check if the player has reached the specified position
        if (player.position.y <= -11 && !shouldShiftCamera)
        {
            Vector3 desiredPosition = new Vector3(0, -22, -10);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else if (player.position.y >= -11 && !shouldShiftCamera)
        {
            Vector3 desiredPosition = new Vector3(0, 0, -10);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
