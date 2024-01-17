using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderHandler : MonoBehaviour
{
    public static ColliderHandler Instance{ get; private set; }

    public event EventHandler OnGameOver;
    public event EventHandler OnGameCompleted;

    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crashed;

    [SerializeField] ParticleSystem successparticle;
    [SerializeField] ParticleSystem crashedparticle;

    AudioSource audioSource;
    bool isTransitioning;

    private void Awake()
    {
        Instance = this;
    }
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
            case "Final":
                GameCompleted();
                break;
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
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    private void GameCompleted()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(success);
        successparticle.Play();
        OnGameCompleted?.Invoke(this, EventArgs.Empty);
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
    void volumControl()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            audioSource.mute=true;
        }
    }
}
