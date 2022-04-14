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
        //   _cursorController()
        Debug.Log("ConnectNet");

        NetworkManager.networkManager.noCreateUIMenu = true;
        NetworkManager.networkManager.connectionUsing = _motherConnection;
        NetworkManager.networkManager.stateNetworkConnection = ConnectionState.Create;
        
        EndUIWindowsConnection();
    }
    
    public void CommandDisconnectNet()
    {
        
        Debug.Log("DisconnectNet");
        
        EndUIWindowsConnection();
    }
    
    public void CommandDestroyConnection()
    {
        Debug.Log("DestroyConnection");
        
        EndUIWindowsConnection();
    }
    
    public void CommandAddUser()
    {
        Debug.Log("AddUser");
        
        EndUIWindowsConnection();
    }
    
    public void CommandAddSource()
    {
        Debug.Log("AddSource");

        EndUIWindowsConnection();
    }

    private void EndUIWindowsConnection()
    {
        NetworkManager.networkManager.RemoveUIWindowConnection();
        
        _cursorController.StopCoroutineDelayRemoveUIWindow();
    }
}
