using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed;
    private Vector3 movementVector = Vector3.zero;

    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movementVector = (player.position - transform.position).normalized * speed;
        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementVector * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.collider.gameObject;
        if (otherObject.gameObject.layer == 3 || otherObject.gameObject.layer == 7)
        {

            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
