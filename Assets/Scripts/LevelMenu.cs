using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public static int previousLevelIndex = -1;

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
        previousLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(5);
    }
    public void ReturnToPreviousLevel()
    {
        if (previousLevelIndex >= 0)
        {
            SceneManager.LoadSceneAsync(previousLevelIndex);
        }
        else
        {
            Debug.LogWarning("No previous level stored.");
        }
    }
}
