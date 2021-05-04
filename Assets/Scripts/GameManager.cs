using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject startPanel, endPanel, muteImage;
    [SerializeField]private TextMeshProUGUI scoreText, highScoreText, endScoreText, endHighScoreText;

    private GameObject actPlayer;

	private void Start () {
        startPanelActivation();
        highScoreCheck();
        audioCheck();
	}

    private void Initialize()
    {
        actPlayer = GameObject.FindGameObjectWithTag("Player");
        actPlayer.GetComponent<Rigidbody>().isKinematic = true;
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<PlayerParticleController>().enabled = false;
        FindObjectOfType<Spawner>().enabled = false;
        FindObjectOfType<PipeMove>().enabled = false;
        scoreText.enabled = false;
    }

    public void startPanelActivation()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
    }

    public void endPanelActivation()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(true);
        scoreText.enabled = false;
        endScoreText.text = "Current score: " + scoreText.text;
        highScoreCheck();
    }

    public void highScoreCheck()
    {
        if (FindObjectOfType<ScoreManager>().getScore() > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", FindObjectOfType<ScoreManager>().getScore());
        }
        highScoreText.text = "Best score so far: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        endHighScoreText.text = "Best score so far: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void audioCheck()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
        {
            muteImage.SetActive(false);
            FindObjectOfType<AudioManager>().setSoundOn(true);
            FindObjectOfType<AudioManager>().playBackgroundMusic();
        }
        else
        {
            muteImage.SetActive(true);
            FindObjectOfType<AudioManager>().setSoundOn(false);
            FindObjectOfType<AudioManager>().stopBackgroundMusic();
        }
    }

    public void startButton()
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

    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void audioButton()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
            PlayerPrefs.SetInt("Audio", 1);
        else
            PlayerPrefs.SetInt("Audio", 0);
        audioCheck();
    }
}
