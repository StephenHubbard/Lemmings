using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SpawnPad : MonoBehaviour
{
    [SerializeField] Transform spawnPoint = null;
    [SerializeField] GameObject lemmingPrefab = null;
    [SerializeField] private int amountToSpawn = 3;
    [SerializeField] private TMP_Text lemmingSavedText = null;


    private void Start()
    {
        StartCoroutine(SpawnLemming());
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
        lemmingSavedText.text = $"Lemmings To Spawn: {amountToSpawn.ToString()}";
    }
}
