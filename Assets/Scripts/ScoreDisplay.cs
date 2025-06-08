using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;

    void Start()
    {
        if (LevelStats.Instance != null)
        {
            scoreText.text = "Score: " + LevelStats.Instance.Score;
            timeText.text = "Time: " + LevelStats.Instance.LevelTime.ToString("F2") + "s";

        }
        else
        {
            scoreText.text = "Score: N/A";
            timeText.text = "Time: N/A";
        }
    }
}
