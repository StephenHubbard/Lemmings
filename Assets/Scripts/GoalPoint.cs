using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private TMP_Text lemmingSavedText = null;

    private int lemmingsSaved = 0;

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
        lemmingsSaved++;

        lemmingSavedText.text = $"Lemmings Saved: {lemmingsSaved.ToString()}";
    }
}
