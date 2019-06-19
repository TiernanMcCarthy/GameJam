using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyClass{

    public float health;

    public float projectileDelayAmount;
    public float projectileMoveSpeed;

    public float maxShootingDistance;

    public float moveSpeed;
    public EnemyClass ()
    {
        health = 3;

        projectileDelayAmount = 1.0f;

        maxShootingDistance = 10;

        moveSpeed = 12;


    }





    void Update()
    {
    }

}
