using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ScoreManager;

public class ScoreUI : MonoBehaviour
{

    public static ScoreUI Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI feedbackText;

    public float feedbackDuration = 0.5f;
    private float feedbackTimer = 0f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        
        if (feedbackText.text != "")
        {
            feedbackTimer -= Time.deltaTime;
            if (feedbackTimer <= 0)
            {
                feedbackText.text = "";
            }
        }
    }

    public void UpdateScore(int score, int multiplier)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (multiplierText != null)
            multiplierText.text = "x" + multiplier;
    }

    public void ShowFeedback(HitAccuracy accuracy)
    {
        switch (accuracy)
        {
            case HitAccuracy.Perfect:
                feedbackText.text = "Perfect!";
                feedbackText.color = Color.yellow;
                break;
            case HitAccuracy.Good:
                feedbackText.text = "Good";
                feedbackText.color = Color.green;
                break;
            case HitAccuracy.Miss:
                feedbackText.text = "Miss";
                feedbackText.color = Color.red;
                break;
        }

        feedbackTimer = feedbackDuration;
    }
}
