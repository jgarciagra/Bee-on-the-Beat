using UnityEngine;
using UnityEngine.UI;

public class BeatIndicator : MonoBehaviour
{
    public Image beatFillImage;

    void Update()
    {
        if (Conductor.Instance == null || beatFillImage == null)
            return;

        float progress = Conductor.Instance.GetBeatProgress();
        beatFillImage.fillAmount = progress;
    }
}
