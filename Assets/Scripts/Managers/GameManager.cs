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

    public GameState state;
    public int _currentlevel = 1;

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
    }

    private void Start()
    {
        UpdateGameState(GameState.Pooling);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.Pooling:
                break;
            case GameState.GenerateLevel:
                break;
            case GameState.Ready:
                break;
            case GameState.Run:
                break;
            case GameState.Finish:
                break;
            case GameState.Fail:
                break;
        }

        OnGameStateChange?.Invoke(newState);
        Debug.Log(state);
    }

    public void NextLevel()
    {
        _currentlevel++;
        if(OnNextLevel != null)
        {
            OnNextLevel();
        }
    }

    public void RestartLevel()
    {
        if(OnRestartLevel != null)
        {
            OnRestartLevel();
        }
    }
}

public enum GameState
{
    Pooling,
    GenerateLevel,
    Ready,
    Run,
    Finish,
    Fail
}
