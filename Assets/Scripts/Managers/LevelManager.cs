using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    private Level _currentLevel;
    private List<bool> _generationCheckers = new List<bool>();
    private List<bool> _doneCheckers = new List<bool>();

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChange += GenerateLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChange -= GenerateLevel;
    }

    private void GenerateLevel(GameState newState)
    {
        if(newState == GameState.GenerateLevel)
        {
            _currentLevel = _levels[(GameManager.Instance._currentlevel - 1) & _levels.Count];
            GenerateObstacles();
            GenerateCollectibles();
            CheckGenerationsAreDone();
        }
    }

    private void GenerateObstacles()
    {
        for(int i = 0; i < _currentLevel.obstacle025StartingCoordinates.Count; i++)
        {
            GameObject obstacle025 = ObjectPool.Instance.RequestObstacle025();
            obstacle025.transform.position = _currentLevel.obstacle025StartingCoordinates[i];
        }

        for (int i = 0; i < _currentLevel.obstacle05StartingCoordinates.Count; i++)
        {
            GameObject obstacle05 = ObjectPool.Instance.RequestObstacle05();
            obstacle05.transform.position = _currentLevel.obstacle05StartingCoordinates[i];
        }

        bool obstacleGenerationDone = true;
        _generationCheckers.Add(obstacleGenerationDone);
    }

    private void GenerateCollectibles()
    {
        for (int i = 0; i < _currentLevel.collectibleStartingCoordinates.Count; i++)
        {
            GameObject collectible = ObjectPool.Instance.RequestCollectible();
            collectible.transform.position = _currentLevel.collectibleStartingCoordinates[i];
        }

        bool collectibleGenerationDone = true;
        _generationCheckers.Add(collectibleGenerationDone);
    }

    private void CheckGenerationsAreDone()
    {
        
        foreach(bool checker in _generationCheckers)
        {
            if (checker == true)
            {
                _doneCheckers.Add(checker);
            }
        }

        if(_doneCheckers.Count == _generationCheckers.Count)
        {
            GameManager.Instance.UpdateGameState(GameState.Ready);
        }
    }
}
