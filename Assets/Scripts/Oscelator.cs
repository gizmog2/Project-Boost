using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscelator : MonoBehaviour
{
    Vector3 startingPoint;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPoint + offset;
    }
}
