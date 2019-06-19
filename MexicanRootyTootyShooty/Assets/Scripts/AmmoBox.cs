using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {

    PlayerController Player;
    public int Ammo;


    private int OriginalAmmo;





    Rigidbody rig;
    bool Active = true;

    int Remainder;

    float localTime = 0;

    public float respawnTime;

    Collider m_Collider;
	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerController>();
        rig = GetComponent<Rigidbody>();
        rig.isKinematic = true;
        m_Collider = GetComponent<Collider>();
        OriginalAmmo = Ammo;
    }
	
	// Update is called once per frame
	void Update () {
	


	}

    void FixedUpdate()
    {
        if(localTime!=0&&Time.time-localTime>respawnTime && Active==false)
        {
            m_Collider.enabled = true;
            transform.localScale = new Vector3(1, 1, 1);
            localTime = 0;
            Active = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HELLO");
        if (collision.collider.gameObject.tag=="Player")
        {
            Remainder=Player.AddAmmo(Ammo);
            Debug.Log(Remainder);
            if (Ammo-Remainder <= 0)
            {
                Debug.Log("Come on you prick");
                Active = false;
                transform.localScale = new Vector3(0, 0, 0);
                localTime = Time.time;
                m_Collider.enabled = !m_Collider.enabled;
            }
            else
                Ammo -= Remainder;
        }
    }
}
