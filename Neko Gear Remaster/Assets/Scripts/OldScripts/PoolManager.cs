using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PoolManager : MonoBehaviour
{
    public static PoolManager current;
    public GameObject bulletPrefab;
    public GameObject enemyBulletPrefab;
    public int maxAmountPlayerBullets = 12;
    public int maxAmountEnemyBullets = 12;
    private List<GameObject> bullets = new List<GameObject>();
    private List<GameObject> enemyBullets = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
        for(int i = 0; i <= maxAmountPlayerBullets; i++)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
            bullets.Add(bullet);
            
        }

        for (int i = 0; i <= maxAmountEnemyBullets; i++)
        {
            GameObject enemyB = GameObject.Instantiate(enemyBulletPrefab);
            enemyB.transform.parent = this.transform;
            enemyB.SetActive(false);
            enemyBullets.Add(enemyB);
        }


    }

    public GameObject GetPlayerBullet()
    {
        return bullets.FirstOrDefault(x => !x.activeInHierarchy);
    }

    public GameObject GetEnemyBullet()
    {
        return enemyBullets.FirstOrDefault(x => !x.activeInHierarchy);
    }
    
}