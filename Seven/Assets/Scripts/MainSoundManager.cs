using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainSoundManager : MonoBehaviour
{
    private static MainSoundManager instance;
    float volume=0.5f;

    public Sound[] sounds;
    public WalkSound[] walkSounds;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        foreach(WalkSound w in walkSounds)
        {
            w.sound.source= gameObject.AddComponent<AudioSource>();

            w.sound.source.volume = w.sound.volume;
            w.sound.source.pitch = w.sound.pitch;
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
        {
            if (s.source.isPlaying)
                return;
            s.source.Play();
        }
            
    }
    public void PlayWalk(string name)
    {
        WalkSound w = Array.Find(walkSounds, walkSounds => walkSounds.sound.name == name);
        if(w != null)
        {
            if (w.sound.source.isPlaying)
                return;
            w.sound.source.clip = w.audios[w.counter];
            w.sound.source.Play();
            w.counter++;
            if (w.counter == w.audios.Length)
                w.counter = 0;
        }
    }
    public void changeVolume(float volume)
    {
        foreach (Sound item in sounds)
        {
            item.source.volume =volume!=0?item.volume /(1/volume):0;

        }
        foreach (WalkSound item in walkSounds)
        {
            item.sound.source.volume =volume!=0? item.sound.volume / (1 / volume) : 0;

        }
    }
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        Play("Theme");
    }
}
