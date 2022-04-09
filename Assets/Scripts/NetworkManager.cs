using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager networkManager;
    

    public int xSize;
    public int ySize;


    [Header("network")] public GameObject networkPrefab;
    //Here set massive of created networks;
    
    public Transform spawnConnections;
    
    private int[,] _sizeNetwork;

    public GameObject _sceneUIWindowConnection;

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
                 GameObject net = Instantiate(networkPrefab,spawnConnections);

                 net.transform.position = new Vector3(i,0,j);
                 net.name = $"Connection_x{i}y{j}";
            }
        }
    }

    public void TakeUIWindowConnection(GameObject connectionUI)
    {
        _sceneUIWindowConnection = connectionUI;
    }
}
