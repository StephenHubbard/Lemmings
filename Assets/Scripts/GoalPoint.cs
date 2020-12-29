using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalPoint : MonoBehaviour
{

    private SpawnPad spawnPad;

    private void Awake()
    {
        spawnPad = FindObjectOfType<SpawnPad>();
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
}
