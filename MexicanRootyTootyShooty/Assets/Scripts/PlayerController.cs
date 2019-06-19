using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Public Values
    public float speed;
    public float health = 100;
    public float ammo= 60; //Temporary, assuming different ammo types
    public float sensitivity;
    public float jumpForce;

    public Gun MyGun;


    public GameObject Camera;

    public Vector3 CameraDistance;



    bool Grounded=true;
    public Rigidbody rig;
    float rotationamount = 0;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();

    }

    Vector3 RadtoDeg(Vector3 a)
    {
        return (new Vector3(a.x * 57.2958f, a.y * 57.2958f, a.z * 57.2958f));
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
        Vector3 Forward = Vectormaths.ForwardDirection(transform.rotation.eulerAngles);
        if (Input.GetAxisRaw("Vertical")!=0)
        {
            //rig.velocity = transform.forward* speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
            transform.position += transform.forward * speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
           // rig.velocity= Vectormaths
        }
        else
        {
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, 0);
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
           
            Vector3 Temp = Vectormaths.VectorCrossProduct(transform.forward * Input.GetAxisRaw("Horizontal") * speed, transform.up*-1);
            transform.position+=Temp*Time.deltaTime;
        }
        else
        {
            rig.velocity = new Vector3(0, rig.velocity.y, rig.velocity.z);
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
            rig.AddForce(new Vector3(0, jumpForce*Time.deltaTime, 0));
        }



    }

    // Update is called once per frame
    void Update () {
        InputScript();
	}
}
