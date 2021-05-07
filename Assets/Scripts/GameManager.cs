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
    private AudioManager audioManagerComponent;
    private PlayerMovement playerMovementComponent;
    private PlayerParticleController playerParticleControllerComponent;
    private Spawner spawnerComponent;
    private PipeMove pipeMoveComponent;
    private ScoreManager scoreManagerComponent;

    private GameObject actPlayer;

    private void Awake()
    {
        audioManagerComponent = FindObjectOfType<AudioManager>();
        playerMovementComponent = FindObjectOfType<PlayerMovement>();
        playerParticleControllerComponent = FindObjectOfType<PlayerParticleController>();
        spawnerComponent = FindObjectOfType<Spawner>();
        pipeMoveComponent = FindObjectOfType<PipeMove>();
        scoreManagerComponent = FindObjectOfType<ScoreManager>();
    }

	private void Start ()
    {
        startPanelActivation();
        highScoreCheck();
        audioCheck();
	}

    private void Initialize()
    {
        actPlayer = GameObject.FindGameObjectWithTag("Player");
        actPlayer.GetComponent<Rigidbody>().isKinematic = true;
        playerMovementComponent.enabled = false;
        playerParticleControllerComponent.enabled = false;
        spawnerComponent.enabled = false;
        pipeMoveComponent.enabled = false;
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
        if (scoreManagerComponent.getScore() > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", scoreManagerComponent.getScore());
        }
        highScoreText.text = "Best score so far: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        endHighScoreText.text = "Best score so far: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void audioCheck()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
        {
            muteImage.SetActive(false);
            audioManagerComponent.setSoundOn(true);
            audioManagerComponent.playBackgroundMusic();
        }
        else
        {
            muteImage.SetActive(true);
            audioManagerComponent.setSoundOn(false);
            audioManagerComponent.stopBackgroundMusic();
        }
    }

    public void startButton()
    {
        actPlayer = GameObject.FindGameObjectWithTag("Player");
        actPlayer.GetComponent<Rigidbody>().isKinematic = false;
        playerMovementComponent.enabled = true;
        spawnerComponent.enabled = true;
        playerParticleControllerComponent.enabled = true;
        pipeMoveComponent.enabled = true;
        scoreText.enabled = true;
        startPanel.SetActive(false);
    }

    public void restartButton() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

    public void exitButton() { Application.Quit(); }

    public void audioButton()
    {
        if (PlayerPrefs.GetInt("Audio", 0) == 0)
            PlayerPrefs.SetInt("Audio", 1);
        else
            PlayerPrefs.SetInt("Audio", 0);
        audioCheck();
    }
}