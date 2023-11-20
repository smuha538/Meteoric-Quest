using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAsteroidPattern : MonoBehaviour
{
    public GameObject ringScript;
    public GameObject sniperScript;
    public GameObject lockonScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ringScript.activeSelf == true || sniperScript.activeSelf == true || lockonScript.activeSelf == true)
            {
                ringScript.SetActive(false);
                sniperScript.SetActive(false);
                lockonScript.SetActive(false);
            }
        }
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (ringScript.activeSelf == false || sniperScript.activeSelf == false || lockonScript.activeSelf == false)
            {
                ringScript.SetActive(true);
                sniperScript.SetActive(true);
                lockonScript.SetActive(true);
            }
        }
    }
}
