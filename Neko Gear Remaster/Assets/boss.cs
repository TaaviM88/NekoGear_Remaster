using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    Shooting _shoot;
    // Start is called before the first frame update
    void Start()
    {
        _shoot = GetComponent<Shooting>();
        if(_shoot == null)
        {
            Debug.Log("Ei löydy " + _shoot.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        _shoot.Fire();
    }
}
