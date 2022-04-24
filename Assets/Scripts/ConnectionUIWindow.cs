using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionUIWindow : MonoBehaviour
{
    public GameObject
        buttonDisconnectNet,
        buttonRemoveUser,
        buttonRemoveSource;


    private Connection _motherConnection;
    private CursorController _cursorController;


    public void AddMotherConnection(Connection connection, bool haveConnections, bool haveSources, bool haveUsers)
    {
        _motherConnection = connection;
        _cursorController = CursorController.cursorController;

        buttonDisconnectNet.SetActive(haveConnections);
        buttonRemoveUser.SetActive(haveUsers);
        buttonRemoveSource.SetActive(haveSources);
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
        _motherConnection.AddUser();

        EndUIWindowsConnection();
    }

    public void CommandAddSource()
    {
        _motherConnection.AddSourceInformation();

        EndUIWindowsConnection();
    }

    public void CommandDeleteUser()
    {
        _motherConnection.DeleteUser();

        EndUIWindowsConnection();
    }

    public void CommandDeleteSource()
    {
        _motherConnection.DeleteSourceInformation();

        EndUIWindowsConnection();
    }

    private void EndUIWindowsConnection()
    {
        NetworkManager.networkManager.RemoveUIWindowConnection();

        _cursorController.StopCoroutineDelayRemoveUIWindow();
    }
}
