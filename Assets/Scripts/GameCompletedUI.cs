using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCompletedUI : MonoBehaviour
{
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button ExitButton;
    private void Awake()
    {
        MainMenuButton.onClick.AddListener(()=>{
            Loader.Load(Loader.Scene.MainMenu);
        });
        ExitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    void Start()
    {
        ColliderHandler.Instance.OnGameCompleted += Colliderhandler_OnGameCompleted;
        Hide();
    }

    private void Colliderhandler_OnGameCompleted(object sender, System.EventArgs e)
    {
        Show();
        MainMenuButton.Select();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
