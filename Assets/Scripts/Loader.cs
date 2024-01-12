using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        MainMenu,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Loader
    }
    private static Scene targetscene;

    public static void Load(Scene targetscene)
    {
        Loader.targetscene = targetscene;
        SceneManager.LoadScene(Scene.Loader.ToString());

    }

    public static void LoadCallback()
    {
        SceneManager.LoadScene(targetscene.ToString());
    }
}
