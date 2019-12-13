using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private GameObject objSpawn;
    private int SpawnerID;
    [Header("Stats")]
    public float speed = 3f;
    public float height = 4;
    public float health = 1;
    public float disableTimer = 5f;
    public int damage = 1;
    [Header("Pattern")]
    public bool isBoss;
    public bool sinMovement;
    public bool tanMovement;
    [Header("Rotation")]
    public float enemyRotationX = 270;
    public float enemyRotationY = 0;
    public float enemyRotationZ = 270;

    [Header("Death animation/effect")]
    public GameObject explosionParticle;
    public int score = 1;
    private Vector3 EnemyMovement;
    private Vector3 _startPosition;
    Rigidbody _rb;

    // Used to find the parent spawner object
    void Start()
    {
        objSpawn = (GameObject)GameObject.FindWithTag("Spawner");
        _rb = GetComponent<Rigidbody>();
        //transform.Rotate(new Vector3(enemyRotationX, enemyRotationY, enemyRotationZ));
        transform.eulerAngles = new Vector3(enemyRotationX, enemyRotationY, enemyRotationZ);
    }

    private void OnEnable()
    {
        if(!isBoss)
        {
            Invoke("removeMe", disableTimer);
        }
        
        _startPosition = transform.position;
    }

    

    private void Update()
    {
        if(!isBoss)
        {
            _rb.AddForce(Vector3.left * (speed * Time.deltaTime), ForceMode.Impulse);
        }


        if (sinMovement &&  !isBoss)
        {
            
            Vector3 _newPosition = transform.position;
            _newPosition.y += Mathf.Sin(Time.time) * Time.deltaTime * height;
            transform.position = _newPosition;
        }
        else if (tanMovement && !isBoss)
        {
            Vector3 _newPosition = transform.position;
            _newPosition.y += Mathf.Cos(Time.time) * Time.deltaTime * height;
            transform.position = _newPosition;
        }


        if(isBoss)
        {
            Vector3 _newPosition = transform.position;
            _newPosition.y += Mathf.Cos(Time.time) * Time.deltaTime * speed;
            transform.position = _newPosition;
        }
    }

    // Call this when you want to kill the enemy
    public void removeMe()
    {
        objSpawn.BroadcastMessage("killEnemy", SpawnerID);
        CreateExplosion();
        if(isBoss)
        {
            GameManager.Instance.BeatLevel();
           
        }

        Score.Instance.AddPoint(score);
        Destroy(gameObject);
    }
    // this gets called in the beginning when it is created by the spawner script
    public void setName(int sName)
    {
        SpawnerID = sName;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.layer == 10)
        {
            
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            //check how much damage to deal to enemy
            float tmpdamage = b.GiveDamage();
            //tell bullet to create explosion
            b.CreateExplosion();
            //disable bullet
            b.Disable();
            TakeDamage(tmpdamage);
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {

            removeMe();
            
        }
    }

    public int MakeDamage()
    {
        return damage;
    }

    public bool IsThisABoss()
    {
        return isBoss;
    }

    public void CreateExplosion()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }
}
