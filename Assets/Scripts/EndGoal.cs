using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField] private int endGoalPointID = 0;
    [SerializeField] GameObject particlePrefab = null;
    [SerializeField] AudioSource lemmingSavedSFX = null;

    private SpawnPad spawnPad;
    private WinCondition winCondition;
    private GameHandler gameHandler;

    private void Awake()
    {
        spawnPad = FindObjectOfType<SpawnPad>();
        winCondition = FindObjectOfType<WinCondition>();
        gameHandler = FindObjectOfType<GameHandler>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lemming") && other.GetComponent<LemmingMovement>().GetLemmingID() == endGoalPointID)
        {
            Destroy(other.gameObject);
            LemmingSaved();
            SpawnSavedParticleEffect();
            LemmingSavedAudio();
        }
    }

    private void SpawnSavedParticleEffect()
    {
        Instantiate(particlePrefab, transform.position, Quaternion.LookRotation(-transform.up));
    }

    private void LemmingSavedAudio()
    {
        lemmingSavedSFX.Play();
    }

    private void LemmingSaved()
    {
        spawnPad.lemmingsSaved++;
        spawnPad.UpdateLemmingsSavedText();
        winCondition.lemmingSaved();
        gameHandler.saveLemming();
    }
}
