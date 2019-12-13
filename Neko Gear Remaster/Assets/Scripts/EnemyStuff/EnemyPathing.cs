using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    public GameObject pathGameObject;
    List<Transform> waypoints = new List<Transform>();
    int waypointIndex = 0;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in pathGameObject.GetComponentInChildren<Transform>())
        {
            waypoints.Add(child);
        }
        transform.position = waypoints[waypointIndex].gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canMove)
        {
            return; 
        }
        Move();
    }

    public void SetWaveConfig(WaveConfig waveC)
    {
        this.waveConfig = waveC;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count -1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
