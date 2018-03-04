using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class Arcball : MonoBehaviour
{
    public float speed;
    
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");
        transform.Rotate(rotY * speed, -rotX * speed, 0, Space.World);
    }
}
