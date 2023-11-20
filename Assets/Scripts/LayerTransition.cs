using UnityEngine;

public class LayerTransition : MonoBehaviour
{
    public Transform player;
    public Vector3 targetPosition;

    public float smoothSpeed = 2.0f;

    private bool shouldShiftCamera = false;

    void Update()
    {
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
