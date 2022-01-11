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
    [SerializeField] private float _yRotateLimit;

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
        _playerInput.TouchMovement.Touch.canceled += ctx => TouchEnded(ctx);
    }

    private void Update()
    {
        MovePlayer();
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
        //float _rotation;
        if (_isTouching)
        {
            float _strafeDelta = _playerInput.TouchMovement.Delta.ReadValue<Vector2>().x;
            _characterController.Move(transform.right * _strafeDelta * _strafeSpeed * Time.deltaTime);
            
            /*if(_strafeDelta == 0)
            {
                _rotation = transform.rotation.eulerAngles.y;
                if(_rotation != 0)
                {
                    var _fixAmount = _yRotateLimit * Time.deltaTime;
                    if (_rotation < 180) _fixAmount *= -1;
                    transform.Rotate(0, _fixAmount, 0);
                }
            }
            else
            {
                transform.Rotate(0, _strafeDelta * _yRotateLimit * Time.deltaTime, 0);
                _rotation = transform.rotation.eulerAngles.y;
                if (_rotation > 180) _rotation -= 360;
                transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Clamp(_rotation, -_yRotateLimit, _yRotateLimit), transform.rotation.eulerAngles.z);
            }*/
        }
        /*else
        {
            _rotation = transform.rotation.eulerAngles.y;
            if(_rotation != 0)
            {
                var _fixAmount = _yRotateLimit * Time.deltaTime;
                if (_rotation < 180) _fixAmount *= -1;
                transform.Rotate(0, _fixAmount, 0);
            }
        }*/

        //_characterController.Move(transform.forward * _zAxisSpeed * Time.deltaTime);
        var position = transform.position;
        position.x = Mathf.Clamp(position.x, _leftXClamp, _rightXClamp);
        transform.position = position;
    }
}