using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConnectionState
{
    Nothing = 0,
    Create = 1,
    Remove = 2,
}

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager networkManager;

    public float range;

    public int xSize;
    public int ySize;


    [Header("network")] public GameObject networkPrefab;
    //Here set massive of created networks;

    public Transform spawnConnections;

    public bool noCreateUIMenu;
    public Connection connectionUsing;
    
    
 

    public ConnectionState stateNetworkConnection;

    private int[,] _sizeNetwork;

    private GameObject _sceneUIWindowConnection;

    private void Awake()
    {
        networkManager = this;
    }

    private void Start()
    {
        CreateNetwork();
    }

    private void CreateNetwork()
    {
        _sizeNetwork = new int[xSize, ySize];

        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                GameObject net = Instantiate(networkPrefab, spawnConnections);

                net.transform.position = new Vector3(i*range, 0, j*range);
                net.name = $"Connection_x{i}y{j}";
            }
        }
    }

    public void TakeUIWindowConnection(GameObject connectionUI)
    {
        if (_sceneUIWindowConnection != null)
        {
            RemoveUIWindowConnection();
        }

        _sceneUIWindowConnection = connectionUI;
    }

    public void RemoveUIWindowConnection()
    {
        if (_sceneUIWindowConnection != null)
            _sceneUIWindowConnection.GetComponent<ConnectionUIWindow>().DeselectUIWindow();
        
        Destroy(_sceneUIWindowConnection);
        _sceneUIWindowConnection = null;
    }

    // public void AddedNetworkConnection()
    // {
    //     Debug.Log("NetworkConnection Added");
    // }
}
