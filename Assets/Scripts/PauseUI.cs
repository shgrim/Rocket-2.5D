using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button MainMenuButton;


    private void Awake()
    {
        ResumeButton.onClick.AddListener(() =>
        {
            Movement.Instance.TogglePause();
        });
        MainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);
        });
    }
    private void Start()
    {
        Movement.Instance.OnGamePaused += Movement_OnGamePaused;
        Movement.Instance.OnGameUnpaused += Movement_OnGameUnpaused;
        Hide();
    }

    private void Movement_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Movement_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        ResumeButton.Select();

    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
