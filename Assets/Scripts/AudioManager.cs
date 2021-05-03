using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField]private AudioSource backgroundMusic, tokenSound, scoreSound, deathSound;

    [HideInInspector]
    private bool soundIsOn = true;

    public void StopBackgroundMusic()
    {
        backgroundMusic.Stop();
    }

    public void PlayBackgroundMusic()
    {
        if (soundIsOn)
        {
            backgroundMusic.Play();
        }
    }

    public void TokenSound()
    {
        if(soundIsOn)
        {
            tokenSound.Play();
        }
    }

    public void ScoreSound()
    {
        if (soundIsOn)
        {
            scoreSound.Play();
        }
    }

    public void DeathSound()
    {
        if (soundIsOn)
        {
            deathSound.Play();
        }
    }

    public void setSoundOn(bool value)
    {
        this.soundIsOn = value;
    }
}