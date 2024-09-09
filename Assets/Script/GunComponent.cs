using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 1f; // Adjust this for desired charging speed
    public float maxChargeTime = 3f; // Maximum charge time in seconds

    private float chargeTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0f;
        }

        if (Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);
        }

        if (Input.GetButtonUp("Fire1"))
        {

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            if (bulletComp != null)
            {
                bulletComp.bulletSpeed *= chargeTime;
            }
            chargeTime = 0f;
        }
    }
}