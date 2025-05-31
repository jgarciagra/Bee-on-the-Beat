using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]

public class Conductor : MonoBehaviour
{
    public static Conductor Instance;
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    

    public float songStart;
    public event Action OnBeat;

    private int beatCount = 0;

    public AudioSource musicSource;

    int currentBeat;

    public float audioOffset = 0.1f;    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    
    void Start()
    {

        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        songStart = Time.time;
        musicSource.Play();

    }

    
    void Update()
    {
        songPosition = Time.time - songStart - audioOffset;        

        currentBeat = Mathf.FloorToInt(songPosition / secPerBeat);
        if (currentBeat > beatCount)
        {
            beatCount = currentBeat;            

            if (OnBeat != null)
            {
                OnBeat.Invoke();
            }
        }
    }

    public float GetSecondsPerBeat()
    {
        return secPerBeat;
    }

    public float GetTimeSinceLastBeat()
    {
        songPosition = Time.time - songStart;
        return songPosition % secPerBeat;
    }

    public float GetBeatProgress()
    {
        return ((Time.time - songStart - audioOffset) % secPerBeat) / secPerBeat;
    }
}
