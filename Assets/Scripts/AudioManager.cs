using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]private AudioSource backgroundMusic, tokenSound, scoreSound, deathSound;

    private bool soundIsOn = true;

    public void stopBackgroundMusic() { backgroundMusic.Stop(); }

    public void playBackgroundMusic()
    {
        if (soundIsOn)
        {
            backgroundMusic.Play();
        }
    }

    public void playTokenSound()
    {
        if(soundIsOn)
        {
            tokenSound.Play();
        }
    }

    public void playScoreSound()
    {
        if (soundIsOn)
        {
            scoreSound.Play();
        }
    }

    public void playDeathSound()
    {
        if (soundIsOn)
        {
            deathSound.Play();
        }
    }

    public void setSoundOn(bool value) { this.soundIsOn = value; }
}