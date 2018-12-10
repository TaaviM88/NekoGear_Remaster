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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }

    public void Fire()
    {
        GameObject bullet = PoolManager.current.GetBullet();
        if (bullet == null) return;
        if(Time.time > nextfire)
        {
            nextfire = Time.time + firerate;

            bullet.transform.position = bulletStartingPoint.position;
            bullet.transform.rotation = transform.rotation;

            bullet.SetActive(true);
        }
    }
}
