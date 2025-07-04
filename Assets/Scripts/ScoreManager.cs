using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public enum HitAccuracy
    {
        Perfect,
        Good,
        Miss
    }

    private int score = 0;
    private int multiplier = 1;
    private int streak = 0;
    private int maxMultiplier = 5;
    private float levelStartTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (LevelStats.Instance != null)
        {
            LevelStats.Instance.ResetStats();
        }

        score = 0;
        multiplier = 1;
        streak = 0;

        levelStartTime = Time.time;
        Time.timeScale = 1f;
    }

    public void RegisterHit(HitAccuracy accuracy)
    {
        switch (accuracy)
        {
            case HitAccuracy.Perfect:
                streak++;
                if (streak >= multiplier * 2 && multiplier < maxMultiplier)
                    multiplier++;
                AddPoints(100 * multiplier);
                break;

            case HitAccuracy.Good:
                streak = 0;
                multiplier = 1;
                AddPoints(50);
                break;

            case HitAccuracy.Miss:
                streak = 0;
                multiplier = 1;
                SubtractPoints(75);
                break;
        }

        ScoreUI.Instance.ShowFeedback(accuracy);
        ScoreUI.Instance.UpdateScore(score, multiplier);
    }

    public void RegisterLevelCompletion()
    {
        float levelTime = Time.time - levelStartTime;
        int bonus = 0;

        if (levelTime < 30f)
            bonus = score;
        else if (levelTime < 45f)
            bonus = score / 2;
        else if (levelTime < 60f)
            bonus = 0;
        else
            bonus = -Mathf.RoundToInt(score * 0.7f);

        score += bonus;
    }

    void AddPoints(int amount)
    {
        score += amount;
    }

    void SubtractPoints(int amount)
    {
        score = Mathf.Max(0, score - amount);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetMultiplier()
    {
        return multiplier;
    }

    public void FinishLevel(string scoreSceneName)
    {
        float levelTime = Time.time - levelStartTime;

        if (LevelStats.Instance != null)
        {
            LevelStats.Instance.SetStats(score, levelTime);
        }

        string currentSceneName = SceneManager.GetActiveScene().name;
        string scoreScreenName = "";

        if (currentSceneName.Contains("Level"))
        {
            string levelNumber = currentSceneName.Replace("Level", "");
            scoreScreenName = "ScoreScreen" + levelNumber;
        }
        else
        {
            scoreScreenName = "ScoreScreen";
        }

        SceneManager.LoadScene(scoreScreenName);
    }
}
