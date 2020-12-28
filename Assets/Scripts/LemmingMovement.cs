using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LemmingMovement : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private float moveSpeed = 1f;

    private bool hitPoint = false;

    private void Awake()
    {
        goal = FindObjectOfType<GoalPoint>().transform;
    }

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (Vector3.Distance(transform.position, goal.position) < .2f)
        {
            hitPoint = true;
        }

        if (hitPoint == true) { return; }

        transform.position = Vector3.MoveTowards(transform.position, goal.position, moveSpeed);

        Vector3 rotateOnlyYAxis = new Vector3(goal.position.x, transform.position.y, goal.position.z);

        transform.LookAt(rotateOnlyYAxis);

    }
}
