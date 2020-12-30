using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;



public class SpawnPad : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Transform spawnPoint = null;
    [SerializeField] GameObject[] lemmingPrefabs = null;
    [SerializeField] private int amountToSpawn = 3;
    [SerializeField] private TMP_Text lemmingsToSpawnText = null;
    [SerializeField] private TMP_Text lemmingSavedText = null;

    public int lemmingsSaved = 0;


    private GoalPoint goalPoint;


    private void Start()
    {
        UpdateLemmingsToSpawnText();
        addPhysicsRaycaster();
    }

    private void Update()
    {

    }

    void addPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }

    private void SpawnLemming()
    {
        if (amountToSpawn <= 0) { return; }

        amountToSpawn--;
        UpdateLemmingsToSpawnText();

        int randomLemming = Random.Range(0, 3);

        Vector3 randomSpawnPoint = new Vector3(spawnPoint.position.x + getRandomNumber(), spawnPoint.position.y, spawnPoint.position.z + getRandomNumber());

        Instantiate(lemmingPrefabs[randomLemming], randomSpawnPoint, Quaternion.identity);

    }

    private float getRandomNumber()
    {
        float randomNumber = Random.Range(-.4f, .4f);
        return randomNumber;
    }

    private void UpdateLemmingsToSpawnText()
    {
        lemmingsToSpawnText.text = $"Lemmings To Spawn: {amountToSpawn.ToString()}";
    }

    public void UpdateLemmingsSavedText()
    {
        lemmingSavedText.text = $"Lemmings Saved: {lemmingsSaved.ToString()}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) { return; }

        SpawnLemming();
    }


}
