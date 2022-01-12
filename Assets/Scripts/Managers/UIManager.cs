using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _swipeGroup;
    [SerializeField] private GameObject _retryButton;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _nextButton;
    [SerializeField] private GameObject _levelGroup;
    [SerializeField] private GameObject _coinGroup;

    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _yScale;
    [SerializeField] private GameObject _multiplication;
    [SerializeField] private GameObject _sum;
    [SerializeField] private GameObject _newScore;
    private List<GameObject> _calculationElements = new List<GameObject>();

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _coinGroup.GetComponentInChildren<TMP_Text>().SetText((GameManager.Instance._score).ToString());
    }
    private void Update()
    {
       
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChange += EnableDisableUIElements;
        GameManager.Instance.OnGameStateChange += EnumatorStarter;
        GameManager.Instance.OnGameStateChange += CalculateLevel;
        GameManager.Instance.OnGameStateChange += OpenMainMenu;
        GameManager.Instance.OnGameStateChange += CloseCalculations;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChange -= EnableDisableUIElements;
        GameManager.Instance.OnGameStateChange -= EnumatorStarter;
        GameManager.Instance.OnGameStateChange -= CalculateLevel;
        GameManager.Instance.OnGameStateChange -= OpenMainMenu;
        GameManager.Instance.OnGameStateChange -= CloseCalculations;
    }

    private void EnableDisableUIElements(GameState newState)
    {
        newState = GameManager.Instance.state;
        _swipeGroup.SetActive(newState == GameState.Ready);
        _retryButton.SetActive(newState == GameState.Fail);
        _nextButton.SetActive(newState == GameState.Finish);
    }

    private void SetTexts()
    {
        _score.GetComponentInChildren<TMP_Text>().SetText("Score: " + GameManager.Instance._currentScore);
        _yScale.GetComponentInChildren<TMP_Text>().SetText("Height: " + _player.transform.localScale.y);
        _multiplication.GetComponentInChildren<TMP_Text>().SetText("Height x 10: " + _player.transform.localScale.y * 10);
        _newScore.GetComponentInChildren<TMP_Text>().SetText("New Score: " + GameManager.Instance._score);

        _calculationElements.Add(_score);
        _calculationElements.Add(_yScale);
        _calculationElements.Add(_multiplication);
        _calculationElements.Add(_sum);
        _calculationElements.Add(_newScore);
    }

    private void EnumatorStarter(GameState newState)
    {
        if(newState == GameState.CalculationsDone)
        {
            StartCoroutine(CalculationsEnumerator());
        }
    }

    private IEnumerator CalculationsEnumerator()
    {
        SetTexts();
        foreach(GameObject element in _calculationElements)
        {
            element.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        _coinGroup.GetComponentInChildren<TMP_Text>().SetText((GameManager.Instance._score).ToString());
        GameManager.Instance.UpdateGameState(GameState.Finish);
    }

    private void CloseCalculations(GameState newState)
    {
        if(newState == GameState.GenerateLevel)
        {
            foreach (GameObject element in _calculationElements)
            {
                element.SetActive(false);
            }
        }
    }

    private void CalculateLevel(GameState newState)
    {
        if(newState == GameState.Start || newState == GameState.GenerateLevel)
        {
            _levelGroup.GetComponentInChildren<TMP_Text>().SetText("LEVEL: " + GameManager.Instance._currentlevel);
        }
    }

    private void OpenMainMenu(GameState newState)
    {
        if(newState == GameState.Start)
        {
            _mainMenu.SetActive(true);
        }
    }

    public void StartButton()
    {
        _mainMenu.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.Pooling);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
