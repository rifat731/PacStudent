using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2[] waypoints;
    private int currentWaypointIndex = 0;
    private AudioSource pelletEatSource;

    void Start()
    {
        waypoints = new Vector2[]
        {
            new Vector2(1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1),
            new Vector2(-1, 1)
        };

        pelletEatSource = GetComponent<AudioSource>();
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

        Vector2 direction = (currentWaypoint - currentPosition).normalized;
        RotatePacStudent(direction);

        if ((Vector2)transform.position == currentWaypoint)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void RotatePacStudent(Vector2 direction)
    {
        if (direction.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("PacStudent collided with something");

        if (collision.gameObject.CompareTag("Pellet"))
        {
            Debug.Log("PacStudent collided with a pellet");

            if (pelletEatSource != null)
            {
                pelletEatSource.Play();
            }

            //remove
            Destroy(collision.gameObject);
        }
    }
}