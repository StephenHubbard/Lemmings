using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField] private int endGoalPointID = 0;


    private SpawnPad spawnPad;
    private WinCondition winCondition;

    private void Awake()
    {
        spawnPad = FindObjectOfType<SpawnPad>();
        winCondition = FindObjectOfType<WinCondition>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lemming") && other.GetComponent<LemmingMovement>().GetLemmingID() == endGoalPointID)
        {
            Destroy(other.gameObject);
            LemmingSaved();
        }
    }

    private void LemmingSaved()
    {
        spawnPad.lemmingsSaved++;
        spawnPad.UpdateLemmingsSavedText();
        winCondition.lemmingSaved();
    }
}
