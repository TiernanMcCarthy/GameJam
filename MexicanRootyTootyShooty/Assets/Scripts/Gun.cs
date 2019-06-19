using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject FirstSource; //Camera preferably, then check if gun actually works in that context
    public GameObject SecondSource; //The Gun itself

    private EnemyShooting ThatFellaIShot;

    int hits;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Fire1")!=0) //And Animation not playing
        {
            // BANG;
           
            RaycastHit Hit; //Hit Event
            Ray R = new Ray(FirstSource.transform.position,  FirstSource.transform.forward); //The Ray itself

            if(Physics.Raycast(R, out Hit))  //Result of Ray
            {
                if (Hit.collider != null)
                {
                    //Hit.collider.enabled = true;
                    //Debug.Log("YEOOOA");    
                    // Destroy(Hit.collider.gameObject);
                    if (Hit.transform.tag == "enemy")
                    {
                        hits = 1; //Set to 1 if hit first time
                       // Debug.Log("YEEOOOOOOOOO");
                        //Hit.transform.GetComponent<EnemyShooting>().
                    }
                }



                if (hits == 1)
                {
                    Debug.Log("Lmao");
                    RaycastHit PreviousHit = Hit;
                    Hit = new RaycastHit(); //Hit Event
                    R = new Ray(SecondSource.transform.position, PreviousHit.point-SecondSource.transform.position); //Point a ray at this previous location;
                    if (Physics.Raycast(R, out Hit))
                    {
                        if (Hit.transform.tag == "enemy")
                        {
                            Debug.Log("GREAT SUCCESS");
                            Destroy(Hit.transform.gameObject);
                            hits = 2; //Signal that the hits have taken place and do the adequate response with this
                        }
                    }
                    
                    


                }
            }
          //  if (collider.GetType() == typeof(MeshCollider))

                //Firing= TRUE toggle animation

                //Debug.Log("BANG");
        }
	}
}
