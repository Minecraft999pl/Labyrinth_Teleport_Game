using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{/*
    AudioSource source;
    double pauseClipTime = 0;
    public AudioClip[] clips;
    int actualClip = 0;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clips[0];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(source.time >= clips[actualClip].length)
        {
            actualClip++;
            if(actualClip > clips.Length - 1)
            {
                actualClip = 0;
            }

            source.clip = clips[actualClip];
            source.Play();
        }
    }

    public void OnPauseGame()
    {
        pauseClipTime = source.time;
        source.Pause();
    }

    public void OnResumeGame()
    {
        source.PlayScheduled(pauseClipTime);
        pauseClipTime = 0;
    }

    public void PitchThis(float pitch)
    {
        source.pitch = pitch;
    }*/
}
