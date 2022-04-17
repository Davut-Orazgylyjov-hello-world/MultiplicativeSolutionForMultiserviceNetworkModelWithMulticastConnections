using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionUIWindow : MonoBehaviour
{
    private Connection _motherConnection; 
    private CursorController _cursorController;


    public void AddMotherConnection(Connection connection)
    {
        _motherConnection = connection;
        _cursorController = CursorController.cursorController;
    }
    
    

    public void DeselectUIWindow()
    {
        _motherConnection.SelectedActive(false);
    }
    
    public void CommandConnectNet()
    {
        Debug.Log("ConnectNet");

        _motherConnection.VisualConnectionIdle(true);

        NetworkManager.networkManager.noCreateUIMenu = true;
        NetworkManager.networkManager.connectionUsing = _motherConnection;
        NetworkManager.networkManager.stateNetworkConnection = ConnectionState.Create;
        
        EndUIWindowsConnection();
    }
    
    public void CommandDisconnectNet()
    {
        if (_motherConnection.HaveConnections())
        {
            Debug.Log("DisconnectNet");

            _motherConnection.VisualDisconnectionIdle(true);

            NetworkManager.networkManager.noCreateUIMenu = true;
            NetworkManager.networkManager.connectionUsing = _motherConnection;
            NetworkManager.networkManager.stateNetworkConnection = ConnectionState.Remove;
            
            EndUIWindowsConnection();
        }
        else
        {
            SoundEffects.soundEffects.PlayError();
        }
    }
    
    
    public void CommandAddUser()
    {
        Debug.Log("AddUser");
        
        _motherConnection.AddUser();
        
        EndUIWindowsConnection();
    }
    
    public void CommandAddSource()
    {
        Debug.Log("AddSource");

        _motherConnection.AddSourceInformation();
        
        EndUIWindowsConnection();
    }

    private void EndUIWindowsConnection()
    {
        NetworkManager.networkManager.RemoveUIWindowConnection();
        
        _cursorController.StopCoroutineDelayRemoveUIWindow();
    }
}
