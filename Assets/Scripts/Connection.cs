using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{

    public GameObject prefabUIWindow;
    
    public Transform spawnUI;

    public GameObject visualSelected;

    public GameObject visualConnectionIdle;

    public GameObject visualDisconnectionIdle;
    
    public Connection[] connections;

    public NetworkConnection[] networkConnections;

    public GameObject prefabNetwork;
    
    

    public void OpenUIWindow()
    {
      
        GameObject windowUI = Instantiate(prefabUIWindow, spawnUI);
        windowUI.GetComponent<ConnectionUIWindow>().AddMotherConnection(this);
        

        NetworkManager.networkManager.TakeUIWindowConnection(windowUI);
        SelectedActive(true);
    }

    public void SelectedActive(bool active)
    {
        visualSelected.SetActive(active);
    }

    public void VisualConnectionIdle(bool active)
    {
        visualConnectionIdle.SetActive(active);
    }

    public void VisualDisconnectionIdle(bool active)
    {
        visualDisconnectionIdle.SetActive(active);
    }

    public void AddConnection(Connection newConnection)
    {
        //check have we connected network with this connection
        foreach (var connection in connections)
        {
            if (connection != null)
                if (connection == newConnection)
                {
                    SoundEffects.soundEffects.PlayError();
                    return;
                }
        }
        
        newConnection.SetConnection(this);
        SetConnection(newConnection);
        SoundEffects.soundEffects.PlayConnection();
        
        NetworkManager.networkManager.noCreateUIMenu = false;
        NetworkManager.networkManager.stateNetworkConnection = ConnectionState.Nothing;

        VisualConnectionIdle(false);
        
        Debug.Log("Added new connection");
    }

    private void SetConnection(Connection setConnection)
    {
        //find clear connection
        for (int i = 0; i < connections.Length; i++)
        {
            if (connections[i] == null)
            {
                connections[i] = setConnection;
                GameObject objNet = Instantiate(prefabNetwork, transform);
                networkConnections[i] = objNet.GetComponent<NetworkConnection>();
                networkConnections[i].aConnection = transform;
                networkConnections[i].bConnection = connections[i].transform;
                networkConnections[i].Connection();
                return;
            }
        }
    }



    public void RemoveConnection(Connection removeConnection)
    {
        VisualDisconnectionIdle(false);

        removeConnection.DeleteConnection(this);
        DeleteConnection(removeConnection);
        
        SoundEffects.soundEffects.PlayDisconnection();
        
        NetworkManager.networkManager.noCreateUIMenu = false;
        NetworkManager.networkManager.stateNetworkConnection = ConnectionState.Nothing;
        
        Debug.Log($"Removed connection {removeConnection.gameObject.name}");
    }

    private void DeleteConnection(Connection removeConnection)
    {
        for (int i = 0; i < connections.Length; i++)
        {
            if (connections[i] == removeConnection)
            {
                connections[i] = null;
                Destroy(networkConnections[i].gameObject);
                networkConnections[i] = null;
                return;
            }
        }
    }

    public bool HaveConnections()
    {
        foreach (var connection in connections)
        {
            if (connection != null)
                return true;
        }
        
        return false;
    }
    
}
