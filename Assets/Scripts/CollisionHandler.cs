using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
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
                Debug.Log("You finished");
                break;
            default:
                Debug.Log("You hit the wall");
                break;
        }
    }
}
