using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Transform _player;
    public Transform bulletStartingPoint;

    public float coolDown = 3;
    public float firerate = 0.07f;
    public float nextfire = 0.0f;

    [Header("If boss")]
    public bool isBoss = false;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }*/
        if (Input.GetButton("Fire1") && !isBoss)
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (!isBoss)
        {
            GameObject bullet = PoolManager.current.GetPlayerBullet();
            if (bullet == null) return;
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;

                bullet.transform.position = bulletStartingPoint.position;
                bullet.transform.rotation = transform.rotation;

                bullet.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Haetaan luotia niin perkeleesti");
            GameObject ebullet = PoolManager.current.GetEnemyBullet();
            if (ebullet == null)
            {
                Debug.Log("Ei täällä mitään luoteja ole!");
                return;
            }
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;

                ebullet.transform.position = bulletStartingPoint.position;
                ebullet.transform.rotation = transform.rotation;

                ebullet.SetActive(true);
            }
        }
     
    }


}
