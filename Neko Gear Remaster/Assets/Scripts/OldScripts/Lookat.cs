using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Vector3 relativePos = GameManager.Instance.player.transform.position - transform.position;

         // the second argument, upwards, defaults to Vector3.up
         Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
         transform.rotation = rotation;*/

        transform.LookAt(GameManager.Instance.player.transform.position);    
       
    }
}
