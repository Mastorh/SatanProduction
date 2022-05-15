using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask collisionMask;
    private float moveDistance;
    public int damage = 1;


    void Update()
    {
        moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
        
        if (transform.position.x > 50 || transform.position.z > 50 || transform.position.z < -50 || transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }

   void CheckCollisions (float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        //Impact sur ennemi
        if (hit.collider.tag == "Enemy")
        {
            hit.collider.GetComponent<PlayerChaseEnemy>().health -= damage;
            Destroy(gameObject);
        }
        
        //"Bounce mechanic"
        Vector3 reflectVec = Vector3.Reflect(transform.forward, hit.normal);
        Quaternion rotation = Quaternion.LookRotation(reflectVec, Vector3.up);
        transform.rotation = rotation;
    }
}
