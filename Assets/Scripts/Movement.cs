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
            RotationRocket(rotateForse);
            if (!rightBooster.isPlaying)
            {                
                rightBooster.Play();
            }                        
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationRocket(-rotateForse);
            if (!leftBooster.isPlaying)
            {                
                leftBooster.Play();
            }                       
        }
        else
        {
            rightBooster.Stop();
            leftBooster.Stop();
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
            if (!myAudioSource.isPlaying && !mainBooster.isPlaying)
            {
                myAudioSource.PlayOneShot(mainEngine);
                mainBooster.Play();
            }
            
            
        }
        else
        {
            myAudioSource.Stop();
            mainBooster.Stop();
        }
        
        
    }
}
