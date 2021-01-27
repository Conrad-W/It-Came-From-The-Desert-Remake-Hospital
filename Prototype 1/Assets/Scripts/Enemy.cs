using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform enemyPos;
    public Transform player;
    public Transform[] points;
    private bool playerInRadius;
    private int destPoint;
    // Start is called before the first frame update
    void Start()
    {
        enemy.autoBraking = false;
        destPoint = Random.Range(0, 24);
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy.pathPending && enemy.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        
        if (playerInRadius)
        {
            enemy.SetDestination(player.position);
        }
    }

    private void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        enemy.destination = points[destPoint].position;

        destPoint = Random.Range(0, 24);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11 || other.gameObject.layer == 13)
        {
            playerInRadius = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 13)
        {
            playerInRadius = true;
        }
        else if (other.gameObject.layer == 11)
        {
            playerInRadius = false;
        }
    }
}
