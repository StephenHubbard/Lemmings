using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using cakeslice;

public class SpawnPad : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Transform spawnPoint = null;
    [SerializeField] GameObject[] lemmingPrefabs = null;
    [SerializeField] AudioSource lemmingSpawnSFX = null;

    [SerializeField] private int red_amountToSpawn = 0;
    [SerializeField] private int yellow_amountToSpawn = 0;
    [SerializeField] private int blue_amountToSpawn = 0;

    [SerializeField] private TMP_Text red_lemmingToSpawnText = null;
    [SerializeField] private TMP_Text yellow_lemmingToSpawnText = null;
    [SerializeField] private TMP_Text blue_lemmingToSpawnText = null;

    public int lemmingsSaved = 0;

    private GoalPoint goalPoint;

    private void Start()
    {
        UpdateLemmingsToSpawnText();
        addPhysicsRaycaster();
        disableOutlineShaderComponent();
    }

    private void disableOutlineShaderComponent()
    {
        GetComponent<Outline>().enabled = true;
        GetComponent<Outline>().enabled = false;
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
        if (red_amountToSpawn <= 0 && yellow_amountToSpawn <= 0 && blue_amountToSpawn <= 0) { return; }

        int randomLemming = Random.Range(0, 3);

        if (randomLemming == 0 && red_amountToSpawn <= 0)
        {
            SpawnLemming();
            return;
        }
        if (randomLemming == 1 && yellow_amountToSpawn <= 0)
        {
            SpawnLemming();
            return;
        }
        if (randomLemming == 2 && blue_amountToSpawn <= 0)
        {
            SpawnLemming();
            return;
        }

        Vector3 randomSpawnPoint = new Vector3(spawnPoint.position.x + SpawnOffsetNumber(), spawnPoint.position.y, spawnPoint.position.z + SpawnOffsetNumber());

        Instantiate(lemmingPrefabs[randomLemming], randomSpawnPoint, Quaternion.identity);

        lemmingSpawnSFX.Play();

        reduceLemmingsToSpawn(randomLemming);

        UpdateLemmingsToSpawnText();
    }

    private void reduceLemmingsToSpawn(int randomLemming)
    {
        if (randomLemming == 0)
        {
            red_amountToSpawn--;
        }
        else if (randomLemming == 1)
        {
            yellow_amountToSpawn--;
        }
        else if (randomLemming == 2)
        {
            blue_amountToSpawn--;
        }
    }

    private float SpawnOffsetNumber()
    {
        float randomNumber = Random.Range(-.4f, .4f);
        return randomNumber;
    }

    private void UpdateLemmingsToSpawnText()
    {
        red_lemmingToSpawnText.text = $"{red_amountToSpawn.ToString()}";
        yellow_lemmingToSpawnText.text = $"{yellow_amountToSpawn.ToString()}";
        blue_lemmingToSpawnText.text = $"{blue_amountToSpawn.ToString()}";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) { return; }

        SpawnLemming();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Outline>().enabled = !GetComponent<Outline>().enabled;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Outline>().enabled = !GetComponent<Outline>().enabled;
    }
}
