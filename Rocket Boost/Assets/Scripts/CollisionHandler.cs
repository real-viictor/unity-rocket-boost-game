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
                Debug.Log("Está no início");
                break;
            case "Finish":
                WinLevel();
                break;
            default:
                CrashRocket();
                break;
        }
    }

    private void CrashRocket()
    {
        DisableRocketMovement();
        Invoke("ReloadLevel", 2f);
    }

    private void WinLevel()
    {
        DisableRocketMovement();
        Invoke("LoadNextLevel", 2f);

    }

    private void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentIndex + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DisableRocketMovement()
    {
        Movement movement = GetComponent<Movement>();
        if (movement)
        {
            movement.enabled = false;
        }
        
    }
}
