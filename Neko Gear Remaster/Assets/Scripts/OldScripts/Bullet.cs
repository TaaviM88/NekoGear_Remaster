﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 1;
    public float disableTimer = 5f;
    public float Firerate = 0.5f;
    public float bulletRotationX = 0;
    public float bulletRotationY = 0;
    public float bulletRotationZ = 90;

    public bool isEnemy = false;
    public GameObject explosionParticle;
    
    private Vector3 bulletMovement;
    private Vector3 bulletRotation;

    Vector3 _direction;
    Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if(isEnemy)
        {
            _rb.AddForce(Vector3.right * (Mathf.Sin (speed) * Time.deltaTime), ForceMode.Impulse);
            transform.Rotate(Vector3.right* Time.deltaTime * speed * 50);
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //_rb.AddForce(_direction * (speed * Time.deltaTime), ForceMode.Impulse);
        if(!isEnemy)
        _rb.AddForce(Vector3.right * (speed * Time.deltaTime), ForceMode.Impulse);
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(bulletRotationX, bulletRotationY, bulletRotationZ);

        Invoke("Disable", disableTimer);
    }

   public void Disable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rb.velocity = Vector3.zero;

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void UpdateDirection()
    {

    }

    public int GiveDamage()
    {
        return damage;
    }

    public void CreateExplosion()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 13)
        {
            Disable();
        }
    }
}
