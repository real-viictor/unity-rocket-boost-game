using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip sucessSound;
    [SerializeField] AudioClip crashSound;

    [SerializeField] ParticleSystem sucessParticles;
    [SerializeField] ParticleSystem crashParticles;

    private AudioSource audioSource;

    private bool isControllable = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        if (isControllable) 
        {
            isControllable = false;
            DisableRocketMovement();
            audioSource.PlayOneShot(crashSound);
            crashParticles.Play();
            Invoke("ReloadLevel", 2f);
        }
    }

    private void WinLevel()
    {
        if (isControllable)
        {
            isControllable = false;
            DisableRocketMovement();
            audioSource.PlayOneShot(sucessSound);
            sucessParticles.Play();
            Invoke("LoadNextLevel", 2f);
        }
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
