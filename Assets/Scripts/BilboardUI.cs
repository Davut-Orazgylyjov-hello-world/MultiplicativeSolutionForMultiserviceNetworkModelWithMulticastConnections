using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardUI : MonoBehaviour
{
    private Camera _playerCamera;
    private Transform _transform;

    private void Awake()
    {
        _playerCamera = Camera.main;
        _transform = _playerCamera.transform;
    }

    private void LateUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        var rotation = _transform.rotation;
        
        transform.LookAt(transform.position + rotation * 
            Vector3.forward, rotation * Vector3.up);
    }
}
