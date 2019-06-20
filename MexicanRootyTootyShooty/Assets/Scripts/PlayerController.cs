using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //Public Values
    public float speed;
    public float health = 100;
    public float ammo= 60; //Temporary, assuming different ammo types
    public float sensitivity;
    float jumpForce;

    float timey;
    public Animator RunnyBoi;

    public Gun MyGun;
    bool running = false;

    public GameObject Camera;

    public Vector3 CameraDistance;

    public float RunSpeed;

    public float respawnTime;

    bool dying = false;
    char runningforwardsorbackwards; //F Forward  B Backward, I idle


    bool Grounded=true;
    public Rigidbody rig;
    float rotationamount = 0;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
        Debug.Log("WHAT");

    }

    Vector3 RadtoDeg(Vector3 a)
    {
        return (new Vector3(a.x * 57.2958f, a.y * 57.2958f, a.z * 57.2958f));
    }


    //The value of health taken away from the player
    public void Shot(float Amount)
    {
        if (health - Amount <= 0)
        {
            Debug.Log("Dead");
            health = 0;
            dying = true;
            timey = Time.time;
        }
        else
            health -= Amount;


    }


    public int AddAmmo(int AmmoAmount) //Input how much ammo is available
    {
        if((AmmoAmount+MyGun.TotalAmmo)>=MyGun.AmmoLimit) //
        {
            int Previous = MyGun.AmmoLimit - MyGun.TotalAmmo;
            MyGun.TotalAmmo = MyGun.AmmoLimit;
            return Previous; //Return the amount used;
        }
        else if(AmmoAmount+MyGun.TotalAmmo<MyGun.AmmoLimit) //All of it is used
        {
            MyGun.TotalAmmo += AmmoAmount;
            return AmmoAmount;
        }
        return 0; //None was needed
       // MyGun.TotalAmmo+=
    }

    public void AddHealth(float add)
    {
        health += add;
        if(health>100)
        {
            health = 100;
        }
    }





    void InputScript()
    {
        // Vector3 Forward = RadtoDeg(Vectormaths.ForwardDirection(rig.rotation.eulerAngles));
        runningforwardsorbackwards = 'i';
        Vector3 Forward = Vectormaths.ForwardDirection(transform.rotation.eulerAngles);
        if (Input.GetAxisRaw("Vertical")!=0)
        {
           // RunnyBoi.SetBool("Running", true);
            //rig.velocity = transform.forward* speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
            transform.position += transform.forward * speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
            //running = true;
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                // RunnyBoi.speed = -RunSpeed;
                RunnyBoi.SetBool("RunningBackWards", true);
                runningforwardsorbackwards = 'b';
            }
            else
            {
               // RunnyBoi.speed = RunSpeed;
                RunnyBoi.SetBool("Running", true);
                runningforwardsorbackwards = 'f';
            }
            // rig.velocity= Vectormaths
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, 0);
           // RunnyBoi.SetBool("Running", true);
          //  running = true;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
           
            Vector3 Temp = Vectormaths.VectorCrossProduct(transform.forward * Input.GetAxisRaw("Horizontal") * speed, transform.up*-1);
            RunnyBoi.SetBool("Running", true);
            transform.position+=Temp*Time.deltaTime;
            runningforwardsorbackwards = 'f';
        }
        else
        {
            rig.velocity = new Vector3(0, rig.velocity.y, rig.velocity.z);
          //  RunnyBoi.SetBool("Running", true);
        }

        if (runningforwardsorbackwards == 'i')
        {
            RunnyBoi.SetBool("Running", false);
            RunnyBoi.SetBool("RunningBackWards", false);
        }

        /*if(Input.GetAxisRaw("Vertical")!=0)
         {
             rig.velocity=new Vector3(rig.velocity.x,rig.velocity.y,(transform.forward * speed * Input.GetAxisRaw("Vertical") * Time.deltaTime).z);
             if (rig.velocity.z > speed || rig.velocity.z*-1 > speed)
             {
                 rig.velocity = new Vector3(0, rig.velocity.y, 5);
             }
         }
         else
         {
             rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, 0);
         }*/
        if (Input.GetAxisRaw("Mouse X") != 0)
        {
            Vector3 Euler = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(Euler.x, Euler.y + Input.GetAxisRaw("Mouse X")*sensitivity, Euler.z);
           // Camera.transform.rotation = Quaternion.Euler(Camera.transform.rotation.x,transform.rotation.eulerAngles.y, Camera.transform.rotation.z);

        }
        if (Input.GetAxisRaw("Mouse Y") != 0)
        {
            Vector3 Euler = Camera.transform.rotation.eulerAngles;
            if (rotationamount + sensitivity * Input.GetAxisRaw("Mouse Y") > 90)
            {
                rotationamount = 90;
            }
            else if (rotationamount + sensitivity * Input.GetAxisRaw("Mouse Y") < -90)
            {
                rotationamount = -90;
            }
            else
            {
                rotationamount += sensitivity * Input.GetAxisRaw("Mouse Y");
            }
           Camera.transform.rotation = Quaternion.Euler(-rotationamount, Euler.y, Euler.z);
        }





        if (Input.GetAxis("Jump")!=0 && Grounded==true)
        {
            //Grounded = false;
          //  rig.AddForce(new Vector3(0, jumpForce*Time.deltaTime, 0));
        }



    }

    // Update is called once per frame
    void Update () {
        InputScript();
	}

    void FixedUpdate()
    {
        if(health<=0&&dying!=true)
        {
            dying = true;
        }

        if (Time.time - timey < respawnTime && dying == true)
        {
            SceneManager.LoadScene(0);
        }
    }
}
