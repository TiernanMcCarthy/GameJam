using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerastuff : MonoBehaviour {
    // Use this for initialization
	void Start () {

        Vector3 Baseposition = new Vector3();
        Quaternion q = new Quaternion
        {
            w = Mathf.Sqrt(Mathf.Max(0, 1 + Baseposition.x+ Baseposition.y+Baseposition.z)/2),




        };
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    /*public static Quat QuaternionFromMatrix(Matrix4by4 m)
    {
        // Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm

        Quat q = new Quat
        {
            //sets w,x,y and z respectively to the square root of the largest of the values inputted.
            w = Mathf.Sqrt(Mathf.Max(0, 1 + m.values[0, 0] + m.values[1, 1] + m.values[2, 2])) / 2,
            x = Mathf.Sqrt(Mathf.Max(0, 1 + m.values[0, 0] - m.values[1, 1] - m.values[2, 2])) / 2,
            y = Mathf.Sqrt(Mathf.Max(0, 1 - m.values[0, 0] + m.values[1, 1] - m.values[2, 2])) / 2,
            z = Mathf.Sqrt(Mathf.Max(0, 1 - m.values[0, 0] - m.values[1, 1] + m.values[2, 2])) / 2
        };
        //Here it sets the x,y and z respectively to be the sine of the position multiplied by value in th matrix.
        q.x *= Mathf.Sign(q.x * (m.values[2, 1] - m.values[1, 2]));
        q.y *= Mathf.Sign(q.y * (m.values[0, 2] - m.values[2, 0]));
        q.z *= Mathf.Sign(q.z * (m.values[1, 0] - m.values[0, 1]));
        return q;
    }

    Quaternion actualRotation = new Quaternion(
    VectorMaths.QuaternionFromMatrix(playerTransform.R).x,
    VectorMaths.QuaternionFromMatrix(playerTransform.R).y,
    VectorMaths.QuaternionFromMatrix(playerTransform.R).z,
    VectorMaths.QuaternionFromMatrix(playerTransform.R).w);


    transform.rotation = actualRotation;

        transform.position = (playerTransform.TRS* cameraTransform.TRS) * cameraTransform.position;*/
}
