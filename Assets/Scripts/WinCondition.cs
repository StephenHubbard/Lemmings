using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private int lemmingsLeftToWin = 3;
    [SerializeField] private TMP_Text lemmingsLeftToWinText = null;

    private void Start()
    {
        UpdateLemmingsLeftToWinText();
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

    private void UpdateLemmingsLeftToWinText()
    {
        lemmingsLeftToWinText.text = $"Lemmings Left To Win: {lemmingsLeftToWin.ToString()}";
    }

    public void lemmingSaved()
    {
        lemmingsLeftToWin--;
        UpdateLemmingsLeftToWinText();
    }

}
