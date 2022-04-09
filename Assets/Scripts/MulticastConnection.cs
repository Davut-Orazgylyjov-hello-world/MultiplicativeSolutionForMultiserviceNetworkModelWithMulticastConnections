using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulticastConnection : MonoBehaviour
{

    // [Header("Users")] public GameObject[] users;
    // [Header("Server")] public GameObject[] servers;
    [Header("Connections")] public Transform aConnection, bConnection;
    private LineRenderer _lineRendererConnection;


    private void Start()
    {
        _lineRendererConnection = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        Connection();
    }

    private void Connection()
    {
        _lineRendererConnection.SetPosition(0, aConnection.position);
        _lineRendererConnection.SetPosition(1, bConnection.position);
    }
}
