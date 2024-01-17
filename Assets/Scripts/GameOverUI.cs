using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private Button RestartButton;
    [SerializeField] private Button MainMenuButton;

    private void Awake()
    {
        RestartButton.onClick.AddListener(() =>
        {
            int currentscene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentscene);
        });
        MainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);
        });
    }

    void Start()
    {
        ColliderHandler.Instance.OnGameOver += Colliderhandler_OnGameOver;
        Hide();
    }

    private void Colliderhandler_OnGameOver(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        RestartButton.Select();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
