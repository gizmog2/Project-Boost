using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float flyForse = 1f;
    [SerializeField] float rotateForse = 100f;
    Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotationRocket(rotateForse);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationRocket(-rotateForse);
        }
    }

    private void RotationRocket(float rotationSide)
    {
        transform.Rotate(Vector3.forward * rotationSide * Time.deltaTime);
    }

    private void ProcessTrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * flyForse * Time.deltaTime);
        }
        
        
    }
}
