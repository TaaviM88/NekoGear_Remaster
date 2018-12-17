using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int defaultHealth = 3;
    public int defaultLifes = 3;
    float countdown;
    bool iFramesCoundown;
    public float iFrames = 2;
    int playerCurrentHealth;
    int playerCurrentLife;
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = defaultHealth;
        playerCurrentLife = defaultLifes;

        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iFramesCoundown)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                iFramesCoundown = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                ChangeCollider(false);
            }
        }
    }

    public void  TakeDamage(int dmg)
    {
        if(iFramesCoundown == false)
        {
            playerCurrentHealth -= dmg;
            if (playerCurrentHealth <= 0)
            {
                GameManager.Instance.ResetScene();
            }
            iFramesCoundown = true;
            countdown = iFrames;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            ChangeCollider(true);
        }

        if (playerCurrentHealth <= 0)
        {
            GameManager.Instance.ResetScene();
        }
  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {

            if(collision.gameObject.tag == "Enemy")
            {
                AIScript enemy = collision.gameObject.GetComponent<AIScript>();
                TakeDamage(enemy.MakeDamage());
                if(!enemy.IsThisABoss())
                {
                    enemy.removeMe();
                }
            }
        }
        if (collision.gameObject.layer == 12)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                TakeDamage(bullet.GiveDamage());
                bullet.Disable();
            }
        }
    }

    public void ChangeCollider(bool trigger)
    {
        col.isTrigger = trigger;
    }
}
