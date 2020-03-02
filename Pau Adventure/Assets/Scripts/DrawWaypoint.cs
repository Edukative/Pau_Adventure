﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWaypoint : MonoBehaviour
{
    public Transform target; //next waypoint that the enemy goes
    int waypointIndex;
    Transform wayPointsParent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        waypointIndex = transform.GetSiblingIndex();
        wayPointsParent = transform.parent;
        if (waypointIndex >= wayPointsParent.transform.childCount - 1)
        {
            target = wayPointsParent.GetChild(0);
        }        else
        {
            target = wayPointsParent.GetChild(waypointIndex + 1);

        }


      

            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, target.position);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);

        
    }


    
        


}
