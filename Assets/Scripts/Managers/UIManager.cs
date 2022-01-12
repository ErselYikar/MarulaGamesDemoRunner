using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _swipeGroup;

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChange += EnableDisableSwipeGroup;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChange -= EnableDisableSwipeGroup;
    }

    private void EnableDisableSwipeGroup(GameState newState)
    {
        newState = GameManager.Instance.state;
        _swipeGroup.SetActive(newState == GameState.Ready);
    }
}
