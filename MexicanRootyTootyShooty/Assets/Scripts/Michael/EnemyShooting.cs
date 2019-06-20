using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyShooting : MonoBehaviour
{

   /* public Transform playerTransform;
    
    public NavMeshAgent agent;

    public GameObject enemyProjectilePrefab;

    public Transform enemyProjectileStartingPosition;


    void Start()
    {
        enemyProjectileStartingPosition = GetComponentInChildren<Transform>();

        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyClass enemyClass_ = new EnemyClass();

        float distanceToPlayer = Vector3.Distance(playerTransform.transform.position, transform.position);


        if (distanceToPlayer > enemyClass_.maxShootingDistance)
        {
            if (agent.isStopped) { agent.isStopped = false; }

            agent.SetDestination(playerTransform.position);
        }
        else if (distanceToPlayer <= enemyClass_.maxShootingDistance)
        {
            agent.isStopped = true;

            transform.LookAt(playerTransform);
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            //if the raycast hits then it will start shooting
            if (Physics.Raycast(ray, out hit, enemyClass_.maxShootingDistance))
            {
                if (hit.transform.tag == "Player")
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);

                    InitiateEnemyShot(enemyClass_);
                }
            }


        }
    }

    private IEnumerator InitiateEnemyShot(EnemyClass enemyClass_)
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyClass_.projectileDelayAmount);

            Instantiate(enemyProjectilePrefab, enemyProjectileStartingPosition);

        }
    }*/


}
