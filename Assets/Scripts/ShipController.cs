using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    public Image boostBar;
    public float maxBoost = 200f;
    private float currentBoost;
    private Rigidbody2D rb;
    private bool cooldown = false;
    private Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        currentBoost = maxBoost;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && currentBoost > 0 && cooldown == false)
        {
            rb.velocity = movementDirection * movementSpeed * 3;
            ConsumeBoost(1);
        }
        
        else
        {
            rb.velocity = movementDirection * movementSpeed;
            if(currentBoost != maxBoost)
            {
                RechargeBoost(1);
            }
            
        }
            
    }

    public void ConsumeBoost(int boostUsed)
    {
        currentBoost -= boostUsed;
        boostBar.fillAmount = currentBoost / maxBoost;
 
        if (cooldown == false && currentBoost <= 0)
        {
            Invoke("BoostCooldown", 4.0f);
            cooldown = true;
        }
    }

    public void RechargeBoost(int boostRecharged)
    {
        currentBoost += boostRecharged;
        boostBar.fillAmount = currentBoost / maxBoost;
    }

    void BoostCooldown()
    {
        cooldown = false;
    }
}
