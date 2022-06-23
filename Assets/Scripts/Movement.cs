using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float flyForse = 1f;
    [SerializeField] float rotateForse = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
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
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            rightBooster.Stop();
            leftBooster.Stop();
        }
    }
    private void ProcessTrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartTrusting();

        }
        else
        {
            StopTrusting();
        }


    }

    private void RotateRight()
    {
        RotationRocket(-rotateForse);
        if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
        }
    }

    private void RotateLeft()
    {
        RotationRocket(rotateForse);
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }
    }

    private void RotationRocket(float rotationSide)
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationSide * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }

    private void StartTrusting()
    {
        myRigidbody.AddRelativeForce(Vector3.up * flyForse * Time.deltaTime);
        if (!myAudioSource.isPlaying && !mainBooster.isPlaying)
        {
            myAudioSource.PlayOneShot(mainEngine);
            mainBooster.Play();
        }
    }

    private void StopTrusting()
    {
        myAudioSource.Stop();
        mainBooster.Stop();
    }    
}
