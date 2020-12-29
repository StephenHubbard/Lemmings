using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GoalPoint[] goalPointsArray;


    public void HandleGoalPointsArray(int goalPointPrefabId)
    {

        foreach (GoalPoint goalPoint in goalPointsArray)
        {
            int thisGoalPointID = goalPoint.getId();

            if (thisGoalPointID == goalPointPrefabId)
            {
                Destroy(goalPoint.gameObject);
                break;
            }
        }

        goalPointsArray = FindObjectsOfType<GoalPoint>();
    }

    


}
