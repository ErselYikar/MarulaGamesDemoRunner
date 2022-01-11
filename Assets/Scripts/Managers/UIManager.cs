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
        _swipeGroup.SetActive(GameManager.Instance.state == GameState.Ready);
    }
}
