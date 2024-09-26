using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2[] waypoints;
    private int currentWaypointIndex = 0;

    void Start()
    {
        waypoints = new Vector2[]
        {
            new Vector2(1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1),
            new Vector2(-1, 1)
        };
    }

    void Update()
    {
        MovePacStudent();
    }

    void MovePacStudent()
    {
        Vector2 currentWaypoint = waypoints[currentWaypointIndex];
        Vector2 currentPosition = transform.position;
        float step = moveSpeed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(currentPosition, currentWaypoint, step);

        if ((Vector2)transform.position == currentWaypoint)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}