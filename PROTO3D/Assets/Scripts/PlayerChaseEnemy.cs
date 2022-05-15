using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerChaseEnemy : MonoBehaviour
{
    private GameObject target;
    public NavMeshAgent navMeshAgent;
    public string targetTag;
    public int health;
    public int startingHealth = 1;
    private Vector3 targetPos;
    void Start()
    {
        health = startingHealth;
        target = GameObject.FindGameObjectWithTag(targetTag);
        if (target.tag == "Player") StartCoroutine(UpdatePath());
        if (target.tag == "Base")
        {
            targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            navMeshAgent.SetDestination(targetPos);
        }
    }

    private void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;
        while (target != null)
        {
            targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            navMeshAgent.SetDestination(targetPos);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
