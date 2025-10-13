using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Est� no in�cio");
                break;
            case "Fuel":
                Debug.Log("Pegou combust�vel");
                break;
            case "Finish":
                Debug.Log("Ganhou");
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }
}
