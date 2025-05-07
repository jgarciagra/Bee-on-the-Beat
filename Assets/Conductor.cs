using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public static Conductor Instance;
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    //public float songPositionInBeats;
    //public float dspSongTime;

    //public float beatsShownInAdvance;

    public float songStart;
    public event Action OnBeat;

    private int beatCount = 0;

    public AudioSource musicSource;

    int currentBeat;

    public float audioOffset = 0.1f;

    //public class Note
    //{
    //    public float beat;
    //    public float position;
    //}

    //public Note[] notes;

    //int nextIndex;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        songStart = Time.time;
        musicSource.Play();


    }

    // Update is called once per frame
    void Update()
    {
        songPosition = Time.time - songStart - audioOffset;
        //songPositionInBeats = songPosition / secPerBeat;

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
}
