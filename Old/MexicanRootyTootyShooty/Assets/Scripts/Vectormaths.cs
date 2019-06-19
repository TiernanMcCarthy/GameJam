using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vectormaths {

    public static Vector3 EulerToDirection(float x, float y, float z)//Geting a direction from an Euler Vector
    {
        Vector3 temp;
        temp.x = Mathf.Cos(x) * Mathf.Sin(y);
        temp.y = Mathf.Sin(x);
        temp.z = Mathf.Cos(y) * Mathf.Cos(x);
        return temp;
    }
    public static Vector3 VectorCrossProduct(Vector3 A, Vector3 B)
    {
        Vector3 C = new Vector3();
        C.x = A.y * B.z - A.z * B.y;
        C.y = A.z * B.x - A.x * B.z;
        C.z = A.x * B.y - A.y * B.x;
        return C;
    }
    public static Vector3 ForwardDirection(Vector3 euler)  //Supply a Forward Direction Vector
    {
        Vector3 EulerRotation;
        EulerRotation.x = euler.x;
        EulerRotation.y = euler.y;
        EulerRotation.z = euler.z;
        return EulerToDirection(EulerRotation.x, EulerRotation.y, EulerRotation.z);
    }
}
