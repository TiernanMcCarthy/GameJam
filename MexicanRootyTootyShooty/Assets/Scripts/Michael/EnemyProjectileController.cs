using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour {
    


	void Start () {
		
	}
	
	void Update () {
        EnemyClass enemyClass_;

        transform.position += transform.forward * enemyClass_.projectileMoveSpeed;
	}
}
