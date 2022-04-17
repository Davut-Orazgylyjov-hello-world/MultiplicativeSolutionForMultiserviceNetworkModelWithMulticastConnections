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
    [Header("Users")] public User[] users;
    [Header("SourcesInformation")] public SourceInformation[] sourceInformation;
    [Header("NetworkConnection")] public NetworkConnection[] networkConnection;
    
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

    public void AddedNewUser(User takeUser)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == null)
            {
                users[i] = takeUser;
                break;
            }
        }
    }

    public void AddedNewSourceInformation(SourceInformation takeSourceInformation)
    {
        for (int i = 0; i < sourceInformation.Length; i++)
        {
            if (sourceInformation[i] == null)
            {
                sourceInformation[i] = takeSourceInformation;
                break;
            }
        }
    }

    public void AddedNewNetworkConnection(NetworkConnection takeNetworkConnection)
    {
        for (int i = 0; i < networkConnection.Length; i++)
        {
            if (networkConnection[i] == null)
            {
                networkConnection[i] = takeNetworkConnection;
                break;
            }
        }
    }

    public void RemoveConnection(NetworkConnection removeConnect)
    {
        for (int i = 0; i < networkConnection.Length; i++)
        {
            if (networkConnection[i] == removeConnect)
            {
                Destroy(networkConnection[i].gameObject);
                networkConnection[i] = null;
                return;
            }
        }
    }
}
