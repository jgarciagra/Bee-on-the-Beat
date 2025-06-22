using System;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class Conductor : MonoBehaviour
{
    public static Conductor Instance;

    
    public AudioSource musicSource;
    public float songBpm;
    public float audioOffset = 0.1f;

    
    public float secPerBeat;
    public float songStart;
    public float songPosition;

    
    public event Action OnBeat;
    private int beatCount = 0;
    private int currentBeat;

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
            OnBeat?.Invoke();
        }
    }

    public float GetSecondsPerBeat()
    {
        return secPerBeat;
    }

    public float GetTimeSinceLastBeat()
    {
        songPosition = Time.time - songStart - audioOffset;
        return songPosition % secPerBeat;
    }

    public float GetBeatProgress()
    {
        return ((Time.time - songStart - audioOffset) % secPerBeat) / secPerBeat;
    }
}
