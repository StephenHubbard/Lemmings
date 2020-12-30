using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GoalPoint[] goalPointsArray;
    [SerializeField] public int totalLemmingsToSave = 5;
    [SerializeField] public int lemmingsLeftToSave;
    [SerializeField] private GameObject gameCompletionPrefab = null;

    public LemmingBar lemmingBar;

    private void Start()
    {
        lemmingsLeftToSave = totalLemmingsToSave;
        lemmingBar.SetMaxValue(totalLemmingsToSave);
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        checkWinCondition();
    }

    private void checkWinCondition()
    {
        if (lemmingsLeftToSave <= 0)
        {
            gameCompletionPrefab.SetActive(true);
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

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    


}
