using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Turret : MonoBehaviour
{

    //public NavMeshSurface navMeshPlane;
    //public GameObject ground;
    public Transform firePoint;
    public Projectile bullet;
    public float muzzleVelocity;
    public float timeBetweenShots;
    private float timeToNextShot = 0f;
    Projectile firedBullet;
    public float targettingRange = 4f;
    private GameObject target;
    public GameObject rotatingTurret;

    //private void Start()
    //{
    //    ground = GameObject.FindGameObjectWithTag("Ground");
    //    navMeshPlane = ground.GetComponent<NavMeshSurface>();
    //    navMeshPlane.BuildNavMesh();
    //}
    void Update()
    {
        if (target == null) GetNewTarget();
        if (target != null)
        {
            if ((target.transform.position - transform.position).sqrMagnitude > Mathf.Pow(targettingRange, 2)) GetNewTarget();
        }
        if (target != null)
        {
            RotateTurret();
            Shoot();
        }
    }

    void RotateTurret()
    {

        rotatingTurret.transform.LookAt(target.transform.position);
    }
    void Shoot()
    {
        if (Time.time > timeToNextShot)
        {
            timeToNextShot = (timeBetweenShots + Time.time);
            firedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Projectile;
            firedBullet.speed = muzzleVelocity;
        }
    }

    void GetNewTarget()
    {
        target = null;
        GameObject[] potentialTargets = GameObject.FindGameObjectsWithTag("Enemy");
        if (potentialTargets.Length != 0)
        {
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in potentialTargets)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            if (distance <= Mathf.Pow(targettingRange, 2))
            {
                target = closest;
            }
            
        }

    }

}
