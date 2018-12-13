using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoScroll : MonoBehaviour
{
    public float speed;
    private Vector3 cameraMovement;


 
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }

   
}
