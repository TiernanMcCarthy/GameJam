using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {
    public Text texy;
    public Text ReloadWarning;
    public Text Health;
    public Text ShrineHealth;

    float Shrinenene;
    public Gun TheFellasGun;

    public PlayerController Player;

    // Use this for initialization
    void Start () {

        //ReloadWarning.fontSize = 0;
        ReloadWarning.text = new string((" ").ToCharArray());
        Shrinenene = 6000;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        texy.text = new string(  ("Ammo: " + TheFellasGun.CurrentAmmo.ToString() + "/" + TheFellasGun.TotalAmmo.ToString()).ToCharArray()); //Gun Count

        ShrineHealth.text = new string(("Shrine:" + Shrinenene).ToCharArray());


        if (TheFellasGun.CurrentAmmo < 5 && TheFellasGun.Reloading != true)
        {
            ReloadWarning.text = new string(("Reload!").ToCharArray());
        }
        else if (TheFellasGun.Reloading == true)
            ReloadWarning.text = new string(("Reloading").ToCharArray());
        else
        {
            ReloadWarning.text = new string((" ").ToCharArray());
            }

        Health.text = new string(("Health: "+ Player.health.ToString()).ToCharArray());
    }

}
