using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taco : MonoBehaviour {


    public float Health;
    PlayerController Player;

    Rigidbody rig;

    bool active=true;


    public Vector3 OriginalSize;

    public float localTime;

    Collider m_Collider;

    public float RespawnTime;

	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerController>();
        m_Collider = GetComponent<Collider>();
        rig = GetComponent<Rigidbody>();
        OriginalSize = transform.localScale;
    }
	


    void FixedUpdate()
    {
        if(localTime != 0 && Time.time - localTime > RespawnTime && active == false)
        {
            Debug.Log("HELLO?");
            m_Collider.enabled = true;
            transform.localScale = OriginalSize;
            active = true;
            localTime = 0;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            if (Player.health < 100)
            {
                Player.AddHealth(Health);
                transform.localScale = new Vector3(0, 0, 0);
                localTime = Time.time;
                m_Collider.enabled = !m_Collider.enabled;
                active = false;
            }

        }
    }



}
