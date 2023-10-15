using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    [SerializeField] private Transform weaponBarrel;
    [SerializeField] GameObject bullet;
    private Vector2 direction;
    private float angle;
    public bool canFire;
    public float timer;
    public float timeBetweenFiring;
    public float bulletVelocity = 10f;


    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            FireBullet();
        }

    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, weaponBarrel.position, weaponBarrel.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = weaponBarrel.up * bulletVelocity;
    }
}
