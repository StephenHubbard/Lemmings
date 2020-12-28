using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = .5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }
}
