using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{

    public GameObject prefabUIWindow;
    
    public Transform spawnUI;

    public GameObject visualSelected;

    public Connection[] connections;

    public NetworkConnection[] networkConnections;

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

        //find clear connection
        for (int i = 0; i < connections.Length; i++)
        {
            Debug.Log(2);

            if (connections[i] == null)
            {
                connections[i] = newConnection;


                SoundEffects.soundEffects.PlayConnection();
                Debug.Log("Added new connection");

                NetworkManager.networkManager.noCreateUIMenu = false;
                NetworkManager.networkManager.stateNetworkConnection = ConnectionState.Nothing;
                return;
            }
        }
    }

    public void RemoveConnection(Connection newConnection)
    {
        Debug.Log($"Removed connection {newConnection.gameObject.name}");
    }
    
}
