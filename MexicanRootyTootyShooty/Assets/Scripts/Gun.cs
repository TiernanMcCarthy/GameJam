using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject Camera; //Camera preferably, then check if gun actually works in that context

    public GameObject Gun1;
    public GameObject Gun2;

    public PlayerController Player;

    public GameObject CurrentGun; //The Gun itself

    public float Damage;

    public float TimeBetweenShots;

    public float ReloadTime;

    float localTime=0;

    public int AmmoSpawn;
    public int AmmoLimit; //Divisible by 12 please

    public int TotalAmmo;

    public int CurrentAmmo; //Divisible by 12 please

    public int MagazineSize; //Divisible by 12 please


    bool CanShoot=true; //Control when you can shoot with this

    public short gun=0;

    public bool Reloading=false;

    string Whatspoppininggamers="PLEASE";
    private EnemyShooting ThatFellaIShot;

    int hits;
    // Use this for initialization
    void Start () {
		
    		CurrentGun=Gun1;
            TotalAmmo = AmmoSpawn;
            CurrentAmmo = MagazineSize;

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetAxis("Fire1") != 0 && CanShoot == true && Reloading == false) //And Animation not playing
        {
            // BANG;
            RaycastHit Hit; //Hit Event
            Ray R = new Ray(Camera.transform.position, Camera.transform.forward); //The Ray itself

            if (Physics.Raycast(R, out Hit))  //Result of Ray
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
                    R = new Ray(CurrentGun.transform.position, PreviousHit.point - CurrentGun.transform.position); //Point a ray at this previous location;
                    if (Physics.Raycast(R, out Hit))
                    {
                        if (Hit.transform.tag == "enemy")
                        {
                            Debug.Log("GREAT SUCCESS");
                            Hit.transform.gameObject.transform.position += new Vector3(0, 0, 3);
                            hits = 2; //Signal that the hits have taken place and do the adequate response with this
                        }
                    }





                }
                
            }

           // Debug.Log("Whatspoppininggamers");
            //gun+=1;
            CurrentAmmo -= 1;

            if (CurrentAmmo <= 0)
            {
                CanShoot = false;
                Reloading = true;
                CurrentAmmo = 0;
            }


            gun += 1;
            if (gun == 1)
            {
                CurrentGun = Gun2;
            }
            else if (gun == 2)
            {
                CurrentGun = Gun1;
                gun = 0;
            }

            CanShoot = false;
            localTime = Time.time;
            //  if (collider.GetType() == typeof(MeshCollider))

            //Firing= TRUE toggle animation

            //Debug.Log("BANG");
        }
        if(Input.GetAxis("Submit")!=0 && Reloading!=true && TotalAmmo>0) //Reload Time
        {
            if (CurrentAmmo + TotalAmmo + 1 < 60)
            {
                TotalAmmo += CurrentAmmo + 1;
            }
            else
            {
                int difference = MagazineSize - CurrentAmmo;

                TotalAmmo = TotalAmmo+13     - difference;
            }
            CanShoot = false;
            CurrentAmmo = 0;
            Reloading = true;

        }


        if (localTime != 0 && Time.time - localTime > TimeBetweenShots && Reloading == false)
        {
            CanShoot = true;
            localTime = 0;
        }
        else if (Reloading == true && Time.time - localTime > ReloadTime)
        {
            //CurrentAmmo = MagazineSize;
           // CurrentAmmo -= MagazineSize;
            if(TotalAmmo>MagazineSize)
            {
                CurrentAmmo = MagazineSize;
                TotalAmmo -= MagazineSize;
            }
            else if(TotalAmmo<MagazineSize || TotalAmmo>0)
            {
                CurrentAmmo = TotalAmmo;
                TotalAmmo = 0;
            }
            localTime = 0;
            Reloading = false;
            CanShoot = true;

        }
    

    }
}
