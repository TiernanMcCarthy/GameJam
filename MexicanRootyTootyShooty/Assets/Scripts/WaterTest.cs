using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTest : MonoBehaviour {

    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();

        //Use normal map shader
        rend.material.shader = Shader.Find("Specular");
	}
	
	// Update is called once per frame
	void Update () {
        float Shininess = Mathf.PingPong(Time.time, 1.0f);
        rend.material.SetFloat(Shader.PropertyToID("_NORMALMAP"), Shininess);
      //  Debug.Log("ejhhhaha");
	}
}
