using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkConnection : MonoBehaviour
{
    [Header("Connections")] public Transform aConnection, bConnection;
    private LineRenderer _lineRendererConnection;


    private void Awake()
    {
        _lineRendererConnection = GetComponent<LineRenderer>();
    }


    // private void Update()
    // {
    //     Connection();
    // }

    public void Connection()
    {
        _lineRendererConnection.SetPosition(0, aConnection.position);
        _lineRendererConnection.SetPosition(1, bConnection.position);
    }
}
