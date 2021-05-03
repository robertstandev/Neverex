using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject startPanel, endPanel, muteImage;
    public TextMeshProUGUI scoreText, highScoreText, endScoreText, endHighScoreText;

    private GameObject actPlayer;

	void Start () {
        StartPanelActivation();
        HighScoreCheck();
        AudioCheck();
	}

    public void Initialize()
    {
        actPlayer = GameObject.FindGameObjectWithTag("Player");
        actPlayer.GetComponent<Rigidbody>().isKinematic = true;
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<PlayerParticleController>().enabled = false;
        FindObjectOfType<Spawner>().enabled = false;
        FindObjectOfType<PipeMove>().enabled = false;
        scoreText.enabled = false;
    }

    public void StartPanelActivation()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
    }

    public void EndPanelActivation()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        scoreText.enabled = false;
        endScoreText.text = "Current score: " + scoreText.text;
        HighScoreCheck();
    }

    public void SkinsPanelActivation()
    {
        startPanel.SetActive(false);
    }

    public void HighScoreCheck()
    {
        if (FindObjectOfType<ScoreManager>().score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", FindObjectOfType<ScoreManager>().score);
        }
        highScoreText.text = "Best score so far: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        endHighScoreText.text = "Best score so far: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void AudioCheck()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
        {
            muteImage.SetActive(false);
            FindObjectOfType<AudioManager>().setSoundOn(true);
            FindObjectOfType<AudioManager>().PlayBackgroundMusic();
        }
        else
        {
            muteImage.SetActive(true);
            FindObjectOfType<AudioManager>().setSoundOn(false);
            FindObjectOfType<AudioManager>().StopBackgroundMusic();
        }
    }

    public void StartButton()
    {
        actPlayer = GameObject.FindGameObjectWithTag("Player");
        actPlayer.GetComponent<Rigidbody>().isKinematic = false;
        FindObjectOfType<PlayerMovement>().enabled = true;
        FindObjectOfType<Spawner>().enabled = true;
        FindObjectOfType<PlayerParticleController>().enabled = true;
        FindObjectOfType<PipeMove>().enabled = true;
        scoreText.enabled = true;
        startPanel.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SkinsBackButton()
    {
        StartPanelActivation();
    }

    public void AudioButton()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
            PlayerPrefs.SetInt("Audio", 1);
        else
            PlayerPrefs.SetInt("Audio", 0);
        AudioCheck();
    }

    public void SkinsButton()
    {
        SkinsPanelActivation();
    }
}
