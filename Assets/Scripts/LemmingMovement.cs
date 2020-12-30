using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LemmingMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private GameObject matchingColorGoalPoint = null;
    [SerializeField] private GoalPoint[] goalPointsArray;
    [SerializeField] private GoalPoint goalPoint;
    [SerializeField] private int lemmingID = 0;

    private bool hitPoint = false;
    private int thisGoalPointID;


    private void Update()
    {
        // probably don't wanna put findgoal in update()
        FindGoal();
        MoveToPoint();
    }


    public int GetLemmingID()
    {
        return lemmingID;
    }

    private void FindGoal()
    {
        if (!FindObjectOfType<GoalPoint>()) { return; }

        goalPointsArray = FindObjectsOfType<GoalPoint>();

        foreach (GoalPoint thisGoalPoint in goalPointsArray)
        {
            thisGoalPointID = thisGoalPoint.getId();

            if (thisGoalPointID == lemmingID)
            {
                goalPoint = thisGoalPoint;
            }
        }
        

    }

    private void MoveToPoint()
    {
        if (goalPoint == null) { return; }

        if (goalPoint.isPlaced == false) { return; }

        if (Vector3.Distance(transform.position, goalPoint.transform.position) < .2f)
        {
            hitPoint = true;
        }

        // not sure if I need
        //if (hitPoint == true) { return; }

        transform.position = Vector3.MoveTowards(transform.position, goalPoint.transform.position, moveSpeed * Time.deltaTime);

        Vector3 rotateOnlyYAxis = new Vector3(goalPoint.transform.position.x, transform.position.y, goalPoint.transform.position.z);

        transform.LookAt(rotateOnlyYAxis);

    }
}
