using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private int lemmingsLeftToWin = 3;

    private void Start()
    {
    }

    private void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (lemmingsLeftToWin <= 0)
        {
            // you win
        }
    }

    public void lemmingSaved()
    {
        lemmingsLeftToWin--;
    }

}
