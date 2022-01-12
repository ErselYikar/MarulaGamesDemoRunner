using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _zAxisSpeed;
    [SerializeField] private float _leftXClamp;
    [SerializeField] private float _rightXClamp;

    [Header("Strafe Settings")]
    [SerializeField] private float _strafeSpeed;

    private PlayerInput _playerInput;
    private bool _isTouching;
    private CharacterController _characterController;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _playerInput.TouchMovement.Touch.started += ctx => TouchStarted(ctx);
        _playerInput.TouchMovement.Touch.started += ctx => FirstTouch(ctx);
        _playerInput.TouchMovement.Touch.canceled += ctx => TouchEnded(ctx);
    }

    private void Update()
    {
        MovePlayer();
    }

    private void FirstTouch(InputAction.CallbackContext context)
    {
        if(GameManager.Instance.state == GameState.Ready)
        {
            GameManager.Instance.UpdateGameState(GameState.Run);
            _playerInput.TouchMovement.Touch.started -= ctx => FirstTouch(ctx);
        }
    }

    private void TouchStarted(InputAction.CallbackContext context)
    {
        _isTouching = true;
    }

    private void TouchEnded(InputAction.CallbackContext context)
    {
        _isTouching = false;
    }

    private void MovePlayer()
    {
        if (GameManager.Instance.state == GameState.Run)
        {
            if (_isTouching)
            {
                float _strafeDelta = _playerInput.TouchMovement.Delta.ReadValue<Vector2>().x;
                _characterController.Move(transform.right * _strafeDelta * _strafeSpeed * Time.deltaTime);
            }
            
            _characterController.Move(transform.forward * _zAxisSpeed * Time.deltaTime);
            var position = transform.position;
            position.x = Mathf.Clamp(position.x, _leftXClamp, _rightXClamp);
            transform.position = position;
        }
    }
}
