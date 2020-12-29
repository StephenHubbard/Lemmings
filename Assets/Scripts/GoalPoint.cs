using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private int goalPointID = 0;

    public bool isPlaced = false;

    private SpawnPad spawnPad;

    private void Awake()
    {
        spawnPad = FindObjectOfType<SpawnPad>();
    }

    public int getId()
    {
        return goalPointID;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lemming"))
        {
            Destroy(other.gameObject);
            LemmingSaved();
        }
    }

    private void LemmingSaved()
    {
        spawnPad.lemmingsSaved++;
        spawnPad.UpdateLemmingsSavedText();
    }

    public void HandleIsPlaced()
    {
        isPlaced = true;
    }
}
