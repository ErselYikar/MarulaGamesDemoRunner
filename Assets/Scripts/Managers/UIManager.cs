using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _swipeGroup;
    [SerializeField] private GameObject _retryButton;
    [SerializeField] private GameObject _nextButton;

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChange += EnableDisableUIElements;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChange -= EnableDisableUIElements;
    }

    private void EnableDisableUIElements(GameState newState)
    {
        newState = GameManager.Instance.state;
        _swipeGroup.SetActive(newState == GameState.Ready);
        _retryButton.SetActive(newState == GameState.Fail);
        _nextButton.SetActive(newState == GameState.Finish);
    }
}
