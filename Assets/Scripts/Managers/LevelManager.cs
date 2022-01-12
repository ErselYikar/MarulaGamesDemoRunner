using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private GameObject _player;
    private Level _currentLevel;
    private List<GameObject> _obstacles = new List<GameObject>();
    private List<GameObject> _collectibles = new List<GameObject>();

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
            _currentLevel = _levels[(GameManager.Instance._currentlevel - 1) % _levels.Count];
            ClearLevel();
            GenerateObstacles();
            GenerateCollectibles();
            ReturnPlayerToInitial();
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
    }

    private void GenerateCollectibles()
    {
        for (int i = 0; i < _currentLevel.collectibleStartingCoordinates.Count; i++)
        {
            GameObject collectible = ObjectPool.Instance.RequestCollectible();
            collectible.transform.position = _currentLevel.collectibleStartingCoordinates[i];
        }
    }

    private void ClearObstacles()
    {
        _obstacles = GameObject.FindGameObjectsWithTag("Obstacle").ToList();
        foreach(GameObject obstacle in _obstacles)
        {
            obstacle.SetActive(false);
        }
    }

    private void ClearCollectibles()
    {
        _collectibles = GameObject.FindGameObjectsWithTag("Collectible").ToList();
        foreach(GameObject collectible in _collectibles)
        {
            collectible.SetActive(false);
        }
    }

    private void ReturnPlayerToInitial()
    {
        _player.transform.position = Vector3.zero;
        _player.transform.localScale = new Vector3(1, 1, 1);
    }

    public void ClearLevel()
    {
        ClearCollectibles();
        ClearObstacles();
        ReturnPlayerToInitial();
    }

    private void CheckGenerationsAreDone()
    {
        GameManager.Instance.UpdateGameState(GameState.Ready);
    }
}
