using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GoalPoint[] goalPointsArray;
    [SerializeField] public int totalLemmingsToSave = 5;
    [SerializeField] public int lemmingsLeftToSave;

    public LemmingBar lemmingBar;

    private void Start()
    {
        lemmingsLeftToSave = totalLemmingsToSave;
        lemmingBar.SetMaxValue(totalLemmingsToSave);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void saveLemming()
    {
        lemmingsLeftToSave--;
        lemmingBar.SetFillValue(lemmingsLeftToSave);
    }

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
