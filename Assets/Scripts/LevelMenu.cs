using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void GoToLevelMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void GoToLevelOne()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void GoToLevelTwo()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void GoToLevelThree()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void GoToSettingsMenu()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
