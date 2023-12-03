using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportShip : MonoBehaviour
{
    public Transform teleportTo;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y)
            {
                collision.transform.position = teleportTo.position;
            }
        }
    }
}
