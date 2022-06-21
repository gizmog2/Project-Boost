using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float flyForse = 1f;
    [SerializeField] float rotateForse = 100f;
    [SerializeField] AudioClip mainEngine;
    //[SerializeField] Rigidbody freezConstrain;

    Rigidbody myRigidbody;
    AudioSource myAudioSource;

    bool isAlive = true;

    
    // Start is called before the first frame update
    void Start()
    {
        //FreezRotation(true);
        myRigidbody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
        
    }

    /*bool FreezRotation(bool result)
    {
        return freezConstrain.freezeRotation = result;
    }*/

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
        myRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSide * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }

    private void ProcessTrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * flyForse * Time.deltaTime);
            if (!myAudioSource.isPlaying)
            {
                myAudioSource.PlayOneShot(mainEngine);
            }
            
            
        }
        else
        {
            myAudioSource.Stop();
        }
        
        
    }
}
