using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private GameObject objSpawn;
    private int SpawnerID;
    public float speed = 3f;
    public float health = 1;
    public float disableTimer = 5f;
    private Vector3 EnemyMovement;
    Rigidbody _rb;
    // Used to find the parent spawner object
    void Start()
    {
        objSpawn = (GameObject)GameObject.FindWithTag("Spawner");
        _rb = GetComponent<Rigidbody>();
        transform.Rotate(new Vector3(270,0,270));
    }

    private void OnEnable()
    {
        Invoke("removeMe", disableTimer);
    }

    

    private void Update()
    {
        _rb.AddForce(Vector3.left * (speed * Time.deltaTime), ForceMode.Impulse);
    }

    // Call this when you want to kill the enemy
    void removeMe()
    {
        objSpawn.BroadcastMessage("killEnemy", SpawnerID);
        Destroy(gameObject);
    }
    // this gets called in the beginning when it is created by the spawner script
    public void setName(int sName)
    {
        SpawnerID = sName;
    }
}
