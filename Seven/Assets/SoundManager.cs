using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource attackSound, deathSound, takeHitSound, Skill1Sound, Skill2Sound, Skill3Sound;
    float volume;
    private void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        if (attackSound != null)
        {
            attackSound.volume = volume;
        }
        if (Skill1Sound != null)
        {
            Skill1Sound.volume = volume;
        }
        if (Skill2Sound != null)
        {
            Skill2Sound.volume = volume;
        }
        if (Skill3Sound != null)
        {
            Skill3Sound.volume = volume;
        }
    }
    public void attack()
    {
        if (attackSound != null)
        {
            attackSound.Play();
        }
    }
    public void skill1Play()
    {
        if (Skill1Sound != null)
        {
            Skill1Sound.Play();
        }
    }
    public void skill2Play()
    {
        if (Skill2Sound != null)
        {
            Skill2Sound.Play();
        }
    }
    public void skill3Play()
    {
        if (Skill3Sound != null)
        {
            Skill3Sound.Play();
        }
    }
}
