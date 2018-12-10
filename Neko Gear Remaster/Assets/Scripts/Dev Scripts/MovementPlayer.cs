using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float forwardSpeed = 1f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * forwardSpeed;
        verticalMove = Input.GetAxis("Vertical") * forwardSpeed;

        transform.position += new Vector3(horizontalMove, verticalMove, 0);
    }
}
