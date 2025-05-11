using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BeatIndicator : MonoBehaviour
{
    private UnityEngine.UI.Image image;

    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        Conductor.Instance.OnBeat += Flash;
    }

    void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    System.Collections.IEnumerator FlashCoroutine()
    {
        image.color = Color.yellow;
        yield return new WaitForSeconds(0.1f);
        image.color = Color.white;
    }
}
