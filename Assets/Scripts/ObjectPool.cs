using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject _obstacle025;
    private GameObject _obstacle025Container;
    public List<GameObject> _obstacle025Pool;
    [SerializeField] private int _obstacle025Count;

    [SerializeField] private GameObject _obstacle05;
    private GameObject _obstacle05Container;
    public List<GameObject> _obstacle05Pool;
    [SerializeField] private int _obstacle05Count;

    [SerializeField] private GameObject _collectible;
    private GameObject _collectibleContainer;
    public List<GameObject> _collectiblePool;
    [SerializeField] private int _collectibleCount;

    private List<bool> _poolingCheckers = new List<bool>();
    private List<bool> _doneCheckers = new List<bool>();

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

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChange += OnStart;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChange -= OnStart;
    }

    private void OnStart(GameState newState)
    {
        if(newState == GameState.Pooling)
        {
            _obstacle025Pool = GenerateObstacle025(_obstacle025Count);
            _obstacle05Pool = GenerateObstacle05(_obstacle05Count);
            _collectiblePool = GenerateCollectible(_collectibleCount);
        } 
    }

    private List<GameObject> GenerateObstacle025(int numOfObstacle)
    {
        _obstacle025Container = GameObject.FindGameObjectWithTag("Obstacle025 Container");

        for(int i = 0; i < numOfObstacle; i++)
        {
            GameObject obstacle025 = Instantiate(_obstacle025);
            obstacle025.transform.parent = _obstacle025Container.transform;
            obstacle025.SetActive(false);
            _obstacle025Pool.Add(obstacle025);
        }

        bool obstacle025GenerationDone = true;
        _poolingCheckers.Add(obstacle025GenerationDone);

        return _obstacle025Pool;
    }
    private List<GameObject> GenerateObstacle05(int numOfObstacle)
    {
        _obstacle05Container = GameObject.FindGameObjectWithTag("Obstacle05 Container");

        for (int i = 0; i < numOfObstacle; i++)
        {
            GameObject obstacle05 = Instantiate(_obstacle05);
            obstacle05.transform.parent = _obstacle05Container.transform;
            obstacle05.SetActive(false);
            _obstacle05Pool.Add(obstacle05);
        }

        bool obstacle05GenerationDone = true;
        _poolingCheckers.Add(obstacle05GenerationDone);

        return _obstacle05Pool;
    }
    private List<GameObject> GenerateCollectible(int numOfCollectible)
    {
        _collectibleContainer = GameObject.FindGameObjectWithTag("Collectible Container");

        for (int i = 0; i < numOfCollectible; i++)
        {
            GameObject collectible = Instantiate(_collectible);
            collectible.transform.parent = _collectibleContainer.transform;
            collectible.SetActive(false);
            _collectiblePool.Add(collectible);
        }

        bool collectibleGenerationDone = true;
        _poolingCheckers.Add(collectibleGenerationDone);

        CheckPoolingsDone();

        return _collectiblePool;
    }

    public GameObject RequestObstacle025()
    {
        foreach(var obstacle in _obstacle025Pool)
        {
            if(obstacle.activeInHierarchy == false)
            {
                obstacle.SetActive(true);
                return obstacle;
            }
        }

        GameObject newObstacle = Instantiate(_obstacle025);
        newObstacle.transform.parent = _obstacle025Container.transform;
        _obstacle025Pool.Add(newObstacle);

        return newObstacle;
    }

    public GameObject RequestObstacle05()
    {
        foreach (var obstacle in _obstacle05Pool)
        {
            if (obstacle.activeInHierarchy == false)
            {
                obstacle.SetActive(true);
                return obstacle;
            }
        }

        GameObject newObstacle = Instantiate(_obstacle05);
        newObstacle.transform.parent = _obstacle05Container.transform;
        _obstacle05Pool.Add(newObstacle);

        return newObstacle;
    }

    public GameObject RequestCollectible()
    {
        foreach (var collectible in _collectiblePool)
        {
            if (collectible.activeInHierarchy == false)
            {
                collectible.SetActive(true);
                return collectible;
            }
        }

        GameObject newCollectible = Instantiate(_collectible);
        newCollectible.transform.parent = _collectibleContainer.transform;
        _collectiblePool.Add(newCollectible);

        return newCollectible;
    }

    private void CheckPoolingsDone()
    {
        foreach(bool checker in _poolingCheckers)
        {
            _doneCheckers.Add(checker);
        }

        if(_doneCheckers.Count == _poolingCheckers.Count)
        {
            GameManager.Instance.UpdateGameState(GameState.GenerateLevel);
        }
    }


}
