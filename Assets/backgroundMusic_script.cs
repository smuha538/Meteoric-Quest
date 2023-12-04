using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic_script : MonoBehaviour
{
    public static backgroundMusic_script instance;
    // Start is called before the first frame update
 private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}