using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{        
    // Update is called once per frame
    void Update()
    {
        NextLevel();
        DisableCollisions();
    }

    private void DisableCollisions()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<CollisionHandler>().enabled = false;
        }       
    }

    private void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentSceneIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(nextLevelIndex);
        }        
    }
}
