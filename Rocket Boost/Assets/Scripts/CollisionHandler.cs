using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip sucessSound;
    [SerializeField] AudioClip crashSound;

    private AudioSource audioSource;

    private bool hasCrashed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Est� no in�cio");
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
        if (!hasCrashed) {
            hasCrashed = true;
            DisableRocketMovement();
            audioSource.PlayOneShot(crashSound);
            Invoke("ReloadLevel", 2f);
        }
    }

    private void WinLevel()
    {
        DisableRocketMovement();
        audioSource.PlayOneShot(sucessSound);
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
