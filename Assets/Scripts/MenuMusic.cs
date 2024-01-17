using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MenuMusic : MonoBehaviour
{
    [SerializeField] private Button SoundButton;
    AudioSource audioData;

    private bool currentState = false;

    [SerializeField] private Image soundPauseUnpause;
    [SerializeField] private Sprite soundPlay;
    [SerializeField] private Sprite soundPause;

    private void Awake()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        currentState = true;
    }
    void Start()
    {
        SoundButton.onClick.AddListener(() =>
        {
            ChangeSoundState();
        });
    }

    private void ChangeSoundState()
    {
        if (currentState)
        {
            audioData.Pause();
            currentState = false;
            soundPauseUnpause.sprite = soundPause;
        }
        else
        {
            audioData.UnPause();
            currentState = true;
            soundPauseUnpause.sprite = soundPlay;
        }
    }

}
