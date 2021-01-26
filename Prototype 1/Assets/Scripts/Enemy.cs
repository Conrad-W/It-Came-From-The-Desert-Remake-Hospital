using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform enemyPos;
    public Transform player;
    private bool playerInRadius;
    private int path;
    // Start is called before the first frame update
    void Start()
    {
        path = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRadius)
        {
            enemy.SetDestination(player.position);
        }
        else
        {
            switch (path)
            {
                case 1:
                    {
                        enemy.SetDestination(new Vector3(-2.75f,76f,22.75f));
                        enemy.SetDestination(new Vector3(-27f, 76f, 22.75f));
                        enemy.SetDestination(new Vector3(-27f, 76f, 17f));
                        enemy.SetDestination(new Vector3(-36.25f, 76f, 17f));
                        enemy.SetDestination(new Vector3(-36.25f, 76f, 19f));
                        //need to add pause here
                        enemy.SetDestination(new Vector3(-36.25f, 76f, 17f));
                        enemy.SetDestination(new Vector3(-27f, 76f, 17f));
                        enemy.SetDestination(new Vector3(-27f, 76f, 7f));
                        break;
                    }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11)
        {
            playerInRadius = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            playerInRadius = true;
        }
        else if (other.gameObject.layer == 11)
        {
            playerInRadius = false;
        }
    }
}
