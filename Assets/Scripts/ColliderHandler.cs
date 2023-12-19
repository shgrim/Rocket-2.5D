using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crashed;

    [SerializeField] ParticleSystem successparticle;
    [SerializeField] ParticleSystem crashedparticle;

    AudioSource audioSource;
    bool isTransitioning;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        volumControl();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break ;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(success);
        successparticle.Play();
        Invoke("LoadNextLevel", loadDelay);
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(crashed);
        crashedparticle.Play();
        Invoke("ReloadLevel", loadDelay);
    }

    private void LoadNextLevel()
    {
        int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextsceneIndex = currentsceneIndex + 1;
        if(nextsceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextsceneIndex = 0;
        }
        SceneManager.LoadScene(nextsceneIndex);
    }
    private void ReloadLevel()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }
    void volumControl()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            audioSource.mute=true;
        }
    }
}
