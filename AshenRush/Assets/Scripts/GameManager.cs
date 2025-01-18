using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public enum GameState 
    {
        Intro,
        Playing,
        Dead
    }

    public static GameManager Instance;
    public GameState State = GameState.Intro;
    public float PlayStartTime = 0f;
    public int Lives = 3;
    public float GameSpeed = 1f;

    [Header("References")]
    public GameObject IntroUI;
    public GameObject DeadUI;
    public GameObject PlatformSpawner;
    public Player PlayerScript;
    public TMP_Text scoreText;

    void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }

    void Start()
    {
        IntroUI.SetActive(true);
    }
    
    float CalculateScore()
    {
        return Time.time - PlayStartTime;
    }

    void SaveHighScore() 
    {
        int score = Mathf.FloorToInt(CalculateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");

        // save high score
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public float GetGameSpeed() 
    {
        return GameSpeed;
    }

    void Update()
    {
        if (State == GameState.Playing) 
        {
            scoreText.text = "Score : " + Mathf.FloorToInt(CalculateScore());
        }
        else if (State == GameState.Dead)
        {
            scoreText.text = "HighScore: " + GetHighScore();
        }
        if (State == GameState.Intro && Input.GetKeyDown(KeyCode.Space))
        {
            State = GameState.Playing;
            IntroUI.SetActive(false);
            PlatformSpawner.SetActive(true);
            PlayStartTime = Time.time;
        }
        if (State == GameState.Playing && Lives <= 0) 
        {
            PlayerScript.KillPlayer();
            PlatformSpawner.SetActive(false);
            DeadUI.SetActive(true);
            State = GameState.Dead;
            SaveHighScore();
        }
        if (State == GameState.Dead && Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
