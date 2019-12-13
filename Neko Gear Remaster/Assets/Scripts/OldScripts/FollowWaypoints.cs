using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    private int waypointsNumber = 0;
    public bool loop = true;
    public bool stop = false;
    public float forwardSpeed = 1f;
    private int direction = 1;
    bool lastWaypoint = false;
    Spawner _spawn;
    // Start is called before the first frame update
    void Start()
    {
        _spawn = GetComponentInChildren<Spawner>();
        if(_spawn == null)
        {
            Debug.Log("Didn't find a " + _spawn.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (!lastWaypoint)
            {
                float step = forwardSpeed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsNumber].transform.position, step);

                if ((this.transform.position - waypoints[waypointsNumber].transform.position).sqrMagnitude < 0.05f)
                {
                    GetNextIndex();
                }
            }
        }
    }

    void GetNextIndex()
    {
        if(_spawn.isActiveAndEnabled)
        {
            _spawn.ChangeEnemyLevel();
        }
        
        if (waypointsNumber == waypoints.Count - 1)
        {
            if(loop == true && stop == false)
            {
                waypointsNumber = 1;
            }
            else if (loop == true && stop == false)
            {
                direction = -1;
            }

            else if (loop == false && stop == true)
            {
                direction = 0;
                lastWaypoint = true;
            }

        }

        if (waypointsNumber == 0)
        {
            direction = 1;
        }

        int i = waypoints.Count;

        if (waypointsNumber < i)
        {
            waypointsNumber += direction;
        }
        else
            waypointsNumber = 0;

    }

}

