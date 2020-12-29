using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private int goalPointID = 0;

    public bool isPlaced = false;


    public int getId()
    {
        return goalPointID;
    }


    public void HandleIsPlaced()
    {
        isPlaced = true;
    }
}
