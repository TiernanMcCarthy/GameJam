using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKillScript : MonoBehaviour {


    public Camera cam;

    public EnemySpawnController spawnController;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                    spawnController.enemyKillCounter++;
                }
            }
        }



    }
}
