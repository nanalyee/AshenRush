using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_KimchiRun : MonoBehaviour
{

    public enum GameState 
    {
        Intro,
        Playing,
        Dead
    }

    //public static GameManager Instance;
    public GameState State = GameState.Intro;
    public float PlayStartTime = 0f;
    public int Lives = 3;

    [Header("References")]
    public GameObject IntroUI;
    public GameObject DeadUI;
    public GameObject EnemySpawner;
    public GameObject FoodSpawner;
    public GameObject GoldenSpawner;
    public Player PlayerScript;
    public TMP_Text scoreText;
    
    /*
    void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }
    */
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

    public float CalculateGameSpeed() 
    {
        if (State != GameState.Playing)
        {
            return 3f;
        }
        float speed = 3f + (0.5f * Mathf.Floor(CalculateScore()/10f));
        return Mathf.Min(speed, 20f);
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
            EnemySpawner.SetActive(true);
            FoodSpawner.SetActive(true);
            GoldenSpawner.SetActive(true);
            PlayStartTime = Time.time;
        }
        if (State == GameState.Playing && Lives <= 0) 
        {
            PlayerScript.KillPlayer();
            EnemySpawner.SetActive(false);
            FoodSpawner.SetActive(false);
            GoldenSpawner.SetActive(false);
            DeadUI.SetActive(true);
            State = GameState.Dead;
            SaveHighScore();
        }
        if (State == GameState.Dead && Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
