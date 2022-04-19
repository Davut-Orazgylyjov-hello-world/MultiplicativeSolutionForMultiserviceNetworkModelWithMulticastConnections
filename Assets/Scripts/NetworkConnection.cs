using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkConnection : MonoBehaviour
{
    [Header("Connections")] public Transform aConnection, bConnection;
    private LineRenderer _lineRendererConnection;

    public InfoUI infoUI;

    private void Awake()
    {
        _lineRendererConnection = GetComponent<LineRenderer>();
    }

    public void Connection()
    {
        _lineRendererConnection.SetPosition(0,  bConnection.position);

        _lineRendererConnection.SetPosition(1,  aConnection.position);
        NetworkManager.networkManager.AddedNewNetworkConnection(this);

        infoUI.SetPositionBetweenTwoTransformsUI(aConnection, bConnection);
    }

    public void Disconnection()
    {
        NetworkManager.networkManager.RemoveConnection(this);
    }

    public void SetInfoUI(string info)
    {
        infoUI.UpdateInfoUI(info);
    }

}
