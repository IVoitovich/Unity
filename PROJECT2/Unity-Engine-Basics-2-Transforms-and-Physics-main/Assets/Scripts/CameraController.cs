using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _worldOffset;
    [SerializeField] private Vector3 _cameraLookOffset;

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (_target == null) return;
        transform.position = _target.position + _worldOffset;
        transform.LookAt(_target.position + _cameraLookOffset);
    }
}
