using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float timeDelay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip finishSound;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        DisableMovement();
        Invoke("EnableMovement", 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is start position");
                break;
            case "Fuel":
                Debug.Log("You get fuel");
                break;
            case "Finish":
                StartNextLevel();                
                break;
            default:
                StartCrashSequence();                
                break;
        }
    }

    
    void DisableMovement()
    {
        GetComponent<Movement>().enabled = false;
    }

    void EnableMovement()
    {
        GetComponent<Movement>().enabled = true;
    }

    void StartCrashSequence()
    {
        DisableMovement();
        myAudioSource.PlayOneShot(crashSound);
        Invoke("ReloadLevel", timeDelay);        
    }

    void StartNextLevel()
    {
        DisableMovement();
        myAudioSource.PlayOneShot(finishSound);
        Invoke("NextLevel", timeDelay);
    }

    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
        /*if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }*/

    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
