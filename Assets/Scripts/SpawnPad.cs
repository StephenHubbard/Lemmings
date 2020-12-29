using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpawnPad : MonoBehaviour
{
    [SerializeField] Transform spawnPoint = null;
    [SerializeField] GameObject lemmingPrefab = null;
    [SerializeField] private int amountToSpawn = 3;
    [SerializeField] private TMP_Text lemmingsToSpawnText = null;
    [SerializeField] private TMP_Text lemmingSavedText = null;

    public int lemmingsSaved = 0;


    private GoalPoint goalPoint;


    private void Start()
    {
        StartCoroutine(SpawnLemming());
    }

    private void Update()
    {

    }

    private IEnumerator SpawnLemming()
    {
        amountToSpawn--;
        UpdateLemmingsToSpawnText();

        Instantiate(lemmingPrefab, spawnPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);

        if (amountToSpawn > 0)
        {
            StartCoroutine(SpawnLemming());
        }
    }

    private void UpdateLemmingsToSpawnText()
    {
        lemmingsToSpawnText.text = $"Lemmings To Spawn: {amountToSpawn.ToString()}";
    }

    public void UpdateLemmingsSavedText()
    {
        lemmingSavedText.text = $"Lemmings Saved: {lemmingsSaved.ToString()}";
    }
}
