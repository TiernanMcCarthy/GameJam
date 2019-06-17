using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Public Values
    public float speed;
    public float health = 100;
    public float ammo= 60; //Temporary, assuming different ammo types
    public float sensitivity;

    public Rigidbody rig;
    Vector3 bob = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();

    }

    void InputScript()
    {
        Vector3 Forward = Vectormaths.ForwardDirection(rig.rotation.eulerAngles);

        if (Input.GetAxisRaw("Horizontal")!=0)
        {
            // rig.AddForce(new Vector3(Input.GetAxisRaw("Horizontal") * speed*Time.deltaTime, 0,0));
            // rig.AddForce(Input.GetAxisRaw("Horizontal") * Forward * speed * Time.deltaTime);
            Vector3 Final = Vectormaths.VectorCrossProduct(Forward, Vector3.up);
            rig.AddForce(Final*speed*Time.deltaTime);

           // rig.AddRelativeForce(Input.GetAxisRaw("Horizontal") * Forward * speed*Time.deltaTime, ForceMode.Force);
        }
       if(Input.GetAxisRaw("Vertical")!=0)
        {
            rig.AddForce(new Vector3(0, 0, Input.GetAxisRaw("Vertical") * speed*Time.deltaTime));
        }

        if (Input.GetAxisRaw("Mouse X") != 0)
        {
            Vector3 Euler = rig.rotation.eulerAngles;
            rig.rotation = Quaternion.Euler(Euler.x, Euler.y + Input.GetAxisRaw("Mouse X")*sensitivity, Euler.z);
        }


    }

    // Update is called once per frame
    void Update () {
        InputScript();
	}
}
