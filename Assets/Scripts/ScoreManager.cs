using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public TextMeshProUGUI scoreText, tokenText;

    [HideInInspector]
    public int score = 0;

    void Start()
    {
        tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();
    }

    public void IncrementScore()
    {
        if (FindObjectOfType<Collision>().gameIsOver == false)
        {
            scoreText.text = (++score).ToString();
        }
    }

    public void IncrementToken()
    {
        if (FindObjectOfType<Collision>().gameIsOver == false)
        {
            PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + 1);
            tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();
        }
    }

    public void IncrementToken(int countOfToken)
    {
        PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + countOfToken);
        tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();
        FindObjectOfType<AudioManager>().TokenSound();
    }

    public void DecrementToken(int decreaseValue)
    {
        PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) - decreaseValue);
        tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();
    }
}
