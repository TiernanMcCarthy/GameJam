using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyClass{

    public float health;

    public float shotDelay;

    public float maxShootingDistance;

    public float moveSpeed;
    public EnemyClass ()
    {
        health = 3;

        shotDelay = 1.0f;

        maxShootingDistance = 10;

        moveSpeed = 12;
    }





    void Update()
    {
    }

}
