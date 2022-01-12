using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Action<GameState> OnGameStateChange;

    public delegate void LevelChange();
    public event LevelChange OnNextLevel;
    public event LevelChange OnRestartLevel;

    public float _score = 0;
    public float _currentScore = 0;

    public GameState state;
    public int _currentlevel;

    private GameObject _player;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _player = FindObjectOfType<PlayerController>().gameObject;
        if(PlayerPrefs.HasKey("current level"))
        {
            _currentlevel = PlayerPrefs.GetInt("current level");
        }
        if (PlayerPrefs.HasKey("score"))
        {
            _score = PlayerPrefs.GetFloat("score");
        }
    }

    private void OnEnable()
    {
        OnGameStateChange += CalculateScore;
    }

    private void OnDisable()
    {
        OnGameStateChange -= CalculateScore;
    }

    private void Start()
    {
        UpdateGameState(GameState.Start);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Start:
                break;
            case GameState.Pooling:
                break;
            case GameState.GenerateLevel:
                break;
            case GameState.Ready:
                break;
            case GameState.Run:
                break;
            case GameState.Calculations:
                break;
            case GameState.CalculationsDone:
                break;
            case GameState.Finish:
                break;
            case GameState.Fail:
                break;
            case GameState.FailDone:
                break;
        }

        OnGameStateChange?.Invoke(newState);
        Debug.Log(state);
    }

    private void CalculateScore(GameState newState)
    {
        if(newState == GameState.Calculations)
        {
            _currentScore = (_player.transform.localScale.y * 10);
            _score += _currentScore;
            PlayerPrefs.SetFloat("score", _score);
            PlayerPrefs.SetFloat("currentScore", _currentScore);
            PlayerPrefs.Save();
            UpdateGameState(GameState.CalculationsDone);
        }
    }

    public void NextLevel()
    {
        _currentlevel++;
        PlayerPrefs.SetInt("current level", _currentlevel);
        PlayerPrefs.Save();
        UpdateGameState(GameState.GenerateLevel);
        
    }

    public void RestartLevel()
    {
        if(state == GameState.Fail)
        {
            UpdateGameState(GameState.GenerateLevel);
        }
    }
}

public enum GameState
{
    Start,
    Pooling,
    GenerateLevel,
    Ready,
    Run,
    Calculations,
    CalculationsDone,
    Finish,
    Fail,
    FailDone
}
