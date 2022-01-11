using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMover : MonoBehaviour
{
    [SerializeField] private float xScale;
    private float time;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.localPosition = new Vector3(Mathf.Sin(time) * xScale, transform.localPosition.y, transform.localPosition.z);
    }
}
