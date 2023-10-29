using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherObject = other.collider.gameObject;
        if (otherObject.gameObject.layer == 7)
        {
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
