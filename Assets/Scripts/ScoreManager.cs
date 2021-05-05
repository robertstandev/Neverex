using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI scoreText, tokenText;
    [SerializeField]private int score = 0;

    private Collision collisionComponent;
    private AudioManager audioManagerComponent;

    private void Awake()
    {
        collisionComponent = FindObjectOfType<Collision>();
        audioManagerComponent = FindObjectOfType<AudioManager>();
    }

    private void Start() { tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString(); }

    public void incrementScore()
    {
        if (collisionComponent.isGameOver() == false)
        {
            scoreText.text = (++score).ToString();
        }
    }

    public void incrementToken()
    {
        if (collisionComponent.isGameOver() == false)
        {
            PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + 1);
            tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();
        }
    }

    private void incrementToken(int countOfToken)
    {
        PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) + countOfToken);
        tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();
        audioManagerComponent.playTokenSound();
    }

    private void decrementToken(int decreaseValue)
    {
        PlayerPrefs.SetInt("Token", PlayerPrefs.GetInt("Token", 0) - decreaseValue);
        tokenText.text = PlayerPrefs.GetInt("Token", 0).ToString();
    }

    public int getScore() { return this.score; }
}