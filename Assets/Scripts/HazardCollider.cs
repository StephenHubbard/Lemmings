using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollider : MonoBehaviour
{
    [SerializeField] GameObject explosionParticlePrefab = null;
    [SerializeField] AudioSource lemmingDeathSFX = null;


    private Collider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lemming"))
        {
            Destroy(other.gameObject);
            Instantiate(explosionParticlePrefab, other.transform.position, Quaternion.LookRotation(-transform.up));
            playDeathSFX();
        }

    }

    private void playDeathSFX()
    {
        lemmingDeathSFX.Play();
    }
}
