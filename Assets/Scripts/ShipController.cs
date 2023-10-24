using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Boundaries boundry;

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 velocity = rb.velocity;
        Vector3 tempPosition = transform.localPosition + velocity * Time.deltaTime;
        if (boundry.AmIOutOfBounds(tempPosition))
        {
            Vector2 newPosition = boundry.CalculateWrappedPosition(tempPosition);
            transform.position = newPosition;
        }
        else
        {
            transform.position = tempPosition;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = movementDirection * movementSpeed * 2;
        }
        else
        {
            rb.velocity = movementDirection * movementSpeed;
        }
            
    }

}
