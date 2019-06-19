using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerastuff : MonoBehaviour
{
    // Use this for initialization
    public PlayerController Player;

    public float Max, Min;

   
    public float offset;

    public float ActualDistanceZ; //Store the modified distance value for the camera
    public float ActualDistanceY;
    float originalDistanceZ;
    public float  temp;
    float originalDistanceY;
    void Start()
    {
        originalDistanceZ = Player.CameraDistance.z;
        originalDistanceY = Player.CameraDistance.y;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.parent.position + Player.CameraDistance;

        //transform.parent.tr = transform.parent.position + Player.CameraDistance;
       

        transform.localPosition = new Vector3(Player.CameraDistance.x,ActualDistanceY, -ActualDistanceZ);


        //  transform.localPosition =new Vector3 (0, 1, 1);

        //transform.parent.SetPositionAndRotation(Player.CameraDistance, transform.parent.rotation);
        //transform.position = new Vector3(0, 0, 3);

//transform.position=transform.parent.position
       // transform.position = transform.parent.position+Player.CameraDistance;

       // transform.parent.position = Player.CameraDistance;

        //transform.parent.

        //transform.position = Player.transform.localPosition + Player.CameraDistance;

       // transform.position = transform.parent.localPosition + Player.CameraDistance;

        //Rotation=0 Distance =Distance

        //If Rotation<0 Get closer e.g. Distance= distance *0.3

        //Else Rotation > 0 // Get Further Away


        if(transform.localRotation.eulerAngles.x < 360 && transform.localRotation.eulerAngles.x>270) //-90?
           {



                //float normalised= (transform.position.z-Mathf.Min())
                //transform.position = new Vector3(-9000, 0, 0);

               


                //float temp =(transform.localRotation.eulerAngles.x - 90) * -1;
               
                temp = transform.localRotation.eulerAngles.x / 90;
               // Debug.Log(temp);

                ActualDistanceZ = originalDistanceZ + temp;
                ActualDistanceY = originalDistanceY + temp-4;
            //transform.position = new Vector3(Player.CameraDistance.x, Player.CameraDistance.y, Player.CameraDistance.z+ActualDistance);

        }
            else if (transform.localRotation.eulerAngles.x < 90 && transform.localRotation.eulerAngles.x > 0) //90
            {



                 temp = transform.localRotation.eulerAngles.x / 90;
                //Debug.Log(temp);

                ActualDistanceZ = -originalDistanceZ + temp-1;
                ActualDistanceY = originalDistanceY + temp;

            }

        }


        //Debug.Log(transform.localRotation.eulerAngles.x);

    

}
