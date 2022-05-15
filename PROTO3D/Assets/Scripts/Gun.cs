using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public Projectile bullet;
    public float muzzleVelocity;
    public float timeBetweenShots;
    private float timeToNextShot = 0f;
    Projectile firedBullet;


    void Update()
    {
        if (Input.GetMouseButton(0))
            {
            Shoot();
            }
    }

    private void Shoot()
    {
        if (Time.time > timeToNextShot)
        {
            timeToNextShot = (timeBetweenShots + Time.time);
            firedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Projectile;
            firedBullet.speed = muzzleVelocity;
        }
    }
}
