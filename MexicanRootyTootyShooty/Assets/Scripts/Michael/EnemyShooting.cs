using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyShooting : MonoBehaviour
{

    public Transform playerTransform;
    
    public NavMeshAgent agent;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EnemyClass enemyClass_ = new EnemyClass();

        float distanceToPlayer = Vector3.Distance(playerTransform.transform.position, transform.position);

        if (distanceToPlayer < enemyClass_.maxShootingDistance)
        {
            agent.speed = 0;

            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            //if the raycast hits then it will start shooting
            while (Physics.Raycast(ray, out hit, enemyClass_.maxShootingDistance))
            {
                if (hit.transform.tag == "Player")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);
                    Debug.Log("SHOOOOOOOT!");
                }
            }


        }
        else
        {
            agent.speed = enemyClass_.moveSpeed;
        }
    }
}
