using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {
    public Text texy;
    public Text ReloadWarning;
    public Text Health;

    public Gun TheFellasGun;

    public PlayerController Player;

    // Use this for initialization
    void Start () {

        //ReloadWarning.fontSize = 0;
        ReloadWarning.text = new string((" ").ToCharArray());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        texy.text = new string(  ("Ammo: " + TheFellasGun.CurrentAmmo.ToString() + "/" + TheFellasGun.TotalAmmo.ToString()).ToCharArray()); //Gun Count

        if(TheFellasGun.CurrentAmmo<5)
        {
            ReloadWarning.text=new string(("Reload!").ToCharArray());
            //  ReloadWarning.fontSize = 50;

        }
        else
        {
            ReloadWarning.text = new string((" ").ToCharArray());
        }

        Health.text = new string(("Health: "+ Player.health.ToString()).ToCharArray());
        //Health.text = Player.health.ToString().ToString();
    }

}
