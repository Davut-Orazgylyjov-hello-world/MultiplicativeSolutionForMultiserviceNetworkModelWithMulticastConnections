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

    public Transform spawnConnections;

    public bool noCreateUIMenu;
    public Connection connectionUsing;




    public ConnectionState stateNetworkConnection;

    private int[,] _sizeNetwork;

    private GameObject _sceneUIWindowConnection;

    private string _alphabetRussian = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

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

                net.transform.position = new Vector3(i * range, 0, j * range);
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
    

    public void AddedNewUser(User takeUser)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == null)
            {
                users[i] = takeUser;
                UpdateGameUI();
                NetworkInformation.netInfo.GetAllPhysicalPathsNetwork();
                break;
            }
        }
    }

    public void RemoveUser(User removeUser)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == removeUser)
            {
                users[i] = null;
                SortUsers();
                UpdateGameUI();
                NetworkInformation.netInfo.GetAllPhysicalPathsNetwork();
                return;
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
                UpdateGameUI();
                NetworkInformation.netInfo.GetAllPhysicalPathsNetwork();
                break;
            }
        }
    }

    public void RemoveSourceInformation(SourceInformation removeSourceInformation)
    {
        for (int i = 0; i < sourceInformation.Length; i++)
        {
            if (sourceInformation[i] == removeSourceInformation)
            {
                sourceInformation[i] = null;
                SortSourceInformation();
                UpdateGameUI();
                NetworkInformation.netInfo.GetAllPhysicalPathsNetwork();
                return;
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
                UpdateGameUI();
                NetworkInformation.netInfo.GetAllPhysicalPathsNetwork();
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
                SortNetworkConnection();
                UpdateGameUI();
                NetworkInformation.netInfo.GetAllPhysicalPathsNetwork();
                return;
            }
        }
    }

    private void UpdateGameUI()
    {

        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == null)
                break;

            if (i < _alphabetRussian.Length)
                users[i].SetInfoUI($"{_alphabetRussian[i]}");
            else
                users[i].SetInfoUI($"{_alphabetRussian[0] + "" + (i - _alphabetRussian.Length)}");
        }



        for (int i = 0; i < sourceInformation.Length; i++)
        {
            if (sourceInformation[i] == null)
            {
                NetworkInformation.netInfo.SetS(i);
                break;
            }

            sourceInformation[i].SetInfoUI($"{i + 1}");
        }


        for (int i = 0; i < networkConnection.Length; i++)
        {
            if (networkConnection[i] == null)
            {
                NetworkInformation.netInfo.SetL(i);
                break;
            }

            networkConnection[i].SetInfoUI($"{i + 1}");
        }
    }
    
    
    private void SortUsers()
    {
        for (int i = 0; i < users.Length - 1; i++)
        {
            if (users[i] == null)
            {
                bool endSort = true;
                
                for (int j = i + 1; j < users.Length; j++)
                {
                    if (users[j] != null)
                    {
                        users[i] = users[j];
                        users[j] = null;
                        endSort = false;
                        break;
                    }
                }
                
                if(endSort)
                    break;
            }
        }
    }
    private void SortSourceInformation()
    {
        for (int i = 0; i < sourceInformation.Length - 1; i++)
        {
            if (sourceInformation[i] == null)
            {
                bool endSort = true;
                
                for (int j = i + 1; j < sourceInformation.Length; j++)
                {
                    if (sourceInformation[j] != null)
                    {
                        sourceInformation[i] = sourceInformation[j];
                        sourceInformation[j] = null;
                        endSort = false;
                        break;
                    }
                }
                
                if(endSort)
                    break;
            }
        }
    }
    private void SortNetworkConnection()
    {
        for (int i = 0; i < networkConnection.Length - 1; i++)
        {
            if (networkConnection[i] == null)
            {
                bool endSort = true;
                
                for (int j = i + 1; j < networkConnection.Length; j++)
                {
                    if (networkConnection[j] != null)
                    {
                        networkConnection[i] = networkConnection[j];
                        networkConnection[j] = null;
                        endSort = false;
                        break;
                    }
                }
                
                if(endSort)
                    break;
            }
        }
    }
}
