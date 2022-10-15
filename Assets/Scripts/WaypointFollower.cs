using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentwaypoint = 0;
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentwaypoint].transform.position) < .1f)
        {
            currentwaypoint++;
            if (currentwaypoint >= waypoints.Length)
            {
                currentwaypoint = 0;
            }    
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentwaypoint].transform.position, speed * Time.deltaTime);
    }
}
