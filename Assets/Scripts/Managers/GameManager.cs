using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Action<GameState> OnGameStateChange;
    public GameState state;

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
        UpdateGameState(GameState.Ready);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
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
    }
}

public enum GameState
{
    Ready,
    Run,
    Finish,
    Fail
}
