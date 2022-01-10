using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _zAxisSpeed;

    private void LateUpdate()
    {
        MovePlayerOnZAxis();
    }

    private void MovePlayerOnZAxis()
    {
        transform.Translate(new Vector3(0, 0, 1 * _zAxisSpeed * Time.deltaTime));
    }
}
