using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BeatIndicator : MonoBehaviour
{
    public UnityEngine.UI.Image beatFillImage;

    void Update()
    {
        if (Conductor.Instance == null || beatFillImage == null)
            return;

        float progress = Conductor.Instance.GetBeatProgress();
        beatFillImage.fillAmount = progress;
    }
}
